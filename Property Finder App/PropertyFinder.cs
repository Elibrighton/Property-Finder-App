using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Property_Finder_App
{
    public class PropertyFinder
    {
        private const string realEstateDomain = "http://www.realestate.com.au/buy/";
        private const string source = "location-search";

        public Dictionary<PropertyType, string> PropertyTypes;
        public Dictionary<Bed, string> Beds;
        public Dictionary<Location, string> Locations;
        public Dictionary<Price, string> Prices;

        public PropertyFinder()
        {
            Locations = GetLocations();
            PropertyTypes = GetPropertyTypes();
            Beds = GetBeds();
            Prices = GetPrices();
        }

        public enum Location
        {
            BrisbaneGreaterRegion,
            Toowong,
            Indooroopilly
        }

        public enum PropertyType
        {
            All,
            House,
            ApartmentAndUnit,
            Townhouse,
            Villa,
            Land,
            Acreage,
            Rural,
            BlockOfUnits,
            RetirementLiving
        }

        public enum Bed
        {
            Any,
            Studio,
            One,
            Two,
            Three,
            Four,
            Five
        }

        public enum Price
        {
            MinAny,
            MaxAny,
            FiftyThousand,
            OneHundredThousand,
            OneHundredAndFiftyThousand,
            TwoHundredThousand,
            TwoHundredAndFiftyThousand,
            ThreeHundredThousand,
            ThreeHundredAndFiftyThousand,
            FourHundredThousand,
            FourHundredAndFiftyThousand,
            FiveHundredThousand,
            FiveHundredAndFiftyThousand,
            SixHundredThousand,
            SixHundredAndFiftyThousand,
            SevenHundredThousand,
            SevenHundredAndFiftyThousand,
            EightHundredThousand,
            EightHundredAndFiftyThousand,
            NineHundredThousand,
            NineHundredAndFiftyThousand,
            OneMillion
        }

        public Dictionary<Price, string> GetPrices()
        {
            return new Dictionary<Price, string>()
            {
                { Price.MinAny, "0" },
                { Price.MaxAny, "any" },
                { Price.FiftyThousand, "50000" },
                { Price.OneHundredThousand, "100000" },
                { Price.OneHundredAndFiftyThousand, "150000" },
                { Price.TwoHundredThousand, "200000" },
                { Price.TwoHundredAndFiftyThousand, "250000" },
                { Price.ThreeHundredThousand, "300000" },
                { Price.ThreeHundredAndFiftyThousand, "350000" },
                { Price.FourHundredThousand, "400000" },
                { Price.FourHundredAndFiftyThousand, "450000" },
                { Price.FiveHundredThousand, "500000" },
                { Price.FiveHundredAndFiftyThousand, "550000" },
                { Price.SixHundredThousand, "600000" },
                { Price.SixHundredAndFiftyThousand, "650000" },
                { Price.SevenHundredThousand, "700000" },
                { Price.SevenHundredAndFiftyThousand, "750000" },
                { Price.EightHundredThousand, "800000" },
                { Price.EightHundredAndFiftyThousand, "850000" },
                { Price.NineHundredThousand, "900000" },
                { Price.NineHundredAndFiftyThousand, "950000" },
                { Price.OneMillion, "1000000" },
            };
        }

        public Dictionary<Location, string> GetLocations()
        {
            return new Dictionary<Location, string>()
            {
                { Location.BrisbaneGreaterRegion, "Brisbane - Greater Region, QLD; " },
                { Location.Toowong, "Toowong, QLD 4066; " },
                { Location.Indooroopilly, "Indooroopilly, QLD 4068; " }
            };
        }

        public Dictionary<Bed, string> GetBeds()
        {
            return new Dictionary<Bed, string>()
            {
                { Bed.Any, "any" },
                { Bed.Studio, "studio" },
                { Bed.One, "1" },
                { Bed.Two, "2" },
                { Bed.Three, "3" },
                { Bed.Four, "4" },
                { Bed.Five, "5" }
            };
        }

        public Dictionary<PropertyType, string> GetPropertyTypes()
        {
            return new Dictionary<PropertyType, string>()
            {
                { PropertyType.All, string.Empty },
                { PropertyType.House, "house" },
                { PropertyType.ApartmentAndUnit, "unit+apartment" },
                { PropertyType.Townhouse, "townhouse" },
                { PropertyType.Villa, "villa" },
                { PropertyType.Land, "land" },
                { PropertyType.Acreage, "acreage" },
                { PropertyType.Rural, "rural" },
                { PropertyType.BlockOfUnits, "unitblock" },
                { PropertyType.RetirementLiving, "retire" }
            };
        }

        public string GetBuyUrl(PropertyType propertyType, Bed minBeds, Price minPrice, Price maxPrice, Location location, Bed maxBeds, int listing)
        {
            return string.Concat(realEstateDomain,
                                        GetPropertyTypes(propertyType),
                                        GetMinBeds(minBeds),
                                        GetPriceRange(minPrice, maxPrice),
                                        GetLocation(location), 
                                        "/",
                                        GetListing(listing),
                                        GetParameters(minBeds, maxBeds, source));
        }

        public string GetParameters(Bed minBeds, Bed maxBeds, string source)
        {
            var parameters = "?";

            if (minBeds != Bed.Any)
            {
                parameters += GetMaxBeds(maxBeds);
                parameters += "&";
            }

            parameters += GetSource(source);

            return parameters;
        }

        public string GetSource(string source)
        {
            return string.Concat("source=", source);
        }

        public string GetPriceRange(Price minPrice, Price maxPrice)
        {
            var priceRange = string.Empty;

            if (!(minPrice == Price.MinAny && maxPrice == Price.MaxAny))
            {
                priceRange = string.Concat("between-", Prices[minPrice], "-", Prices[maxPrice], "-").ToLower();
            }

            return priceRange;
        }

        public string GetMaxBeds(Bed maxBeds)
        {
            return string.Concat("maxBeds=", Beds[maxBeds]);
        }

        public string GetListing(int listing)
        {
            return string.Concat("list-", listing.ToString());
        }

        public string GetLocation(Location location)
        {
            var value = string.Empty;

            if (Locations.ContainsKey(location))
            {
                value = string.Concat("in-", Locations[location].Replace(",", "%2c").Replace(" ", "+").Replace(";", "%3b").ToLower());
            }

            return value;
        }

        public string GetMinBeds(Bed minBeds)
        {
            var value = string.Empty;

            if (Beds.ContainsKey(minBeds))
            {
                switch (minBeds)
                {
                    case Bed.Studio:
                        value = string.Concat("with-", Beds[minBeds], "-");
                        break;
                    case Bed.One:
                        value = string.Concat("with-", Beds[minBeds], "-bedroom-");
                        break;
                    case Bed.Two:
                    case Bed.Three:
                    case Bed.Four:
                    case Bed.Five:
                        value = string.Concat("with-", Beds[minBeds], "-bedrooms-");
                        break;
                    default:
                        break;
                }
            }

            return value;
        }

        public string GetPropertyTypes(PropertyType propertyType)
        {
            var value = string.Empty;

            if (PropertyTypes.ContainsKey(propertyType))
            {
                if (propertyType != PropertyType.All)
                {
                    value = string.Concat("property-", PropertyTypes[propertyType], "-");
                }
            }

            return value;
        }

        public string GetWebResponse(string url)
        {
            var responseFromServer = string.Empty;

            try
            {
                // Create a request for the URL.   
                WebRequest request = WebRequest.Create(url);

                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                WebResponse response = request.GetResponse();

                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.  
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);

                // Read the content.  
                responseFromServer = reader.ReadToEnd();

                // Display the content.  
                Console.WriteLine(responseFromServer);

                // Clean up the streams and the response.  
                reader.Close();
                response.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return responseFromServer;
        }

        public int GetTotalHomes(string paragraph)
        {
            var totalHomes = 0;
            var patialMatchValue = RegexHelper.GetRegexMatchValue(paragraph, @"\d*\stotal\sresults");

            if (!string.IsNullOrEmpty(patialMatchValue))
            {
                totalHomes = Convert.ToInt32(RegexHelper.GetRegexMatchValue(patialMatchValue, @"^\d*"));
            }

            return totalHomes;
        }
    }
}
