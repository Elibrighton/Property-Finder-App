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
    public class Search
    {
        public Dictionary<PropertyType, string> PropertyTypes;
        public Dictionary<Bed, string> Beds;
        public Dictionary<Location, string> Locations;
        public Dictionary<Price, string> Prices;
        public Dictionary<Bathroom, string> Bathrooms;
        public Dictionary<CarSpace, string> CarSpaces;
        public Dictionary<ConstructionType, string> ConstructionTypes;
        public string Url { get; private set; }

        private const string realEstateDomain = "http://www.realestate.com.au/";
        private const string buyController = "buy/";
        private const string source = "location-search";

        private PropertyType propertyType;
        private Bed minBeds;
        private int minLand;
        private Price minPrice;
        private Price maxPrice;
        private Location location;
        private ConstructionType constructionType;
        private CarSpace minCarSpaces;
        private Bathroom minBathrooms;
        private Bed maxBeds;
        private bool isIncludingSurroundingSuburbs;
        private bool isExcludingPropertiesUnderContract;
        
        public Search()
        {
            Locations = GetLocations();
            PropertyTypes = GetPropertyTypes();
            Beds = GetBeds();
            Prices = GetPrices();
            Bathrooms = GetBathrooms();
            CarSpaces = GetCarSpaces();
            ConstructionTypes = GetConstructionTypes();

        }

        public enum ConstructionType
        {
            Any,
            NewConstruction,
            EstablishedProperty
        }

        public enum CarSpace
        {
            Any,
            OnePlus,
            TwoPlus,
            ThreePlus,
            FourPlus,
            FivePlus
        }

        public enum Bathroom
        {
            Any,
            OnePlus,
            TwoPlus,
            ThreePlus,
            FourPlus,
            FivePlus
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

        public Dictionary<ConstructionType, string> GetConstructionTypes()
        {
            return new Dictionary<ConstructionType, string>()
            {
                { ConstructionType.Any, string.Empty },
                { ConstructionType.NewConstruction, "new" },
                { ConstructionType.EstablishedProperty, "established" }
            };
        }

        public Dictionary<CarSpace, string> GetCarSpaces()
        {
            return new Dictionary<CarSpace, string>()
            {
                { CarSpace.Any, string.Empty },
                { CarSpace.OnePlus, "1" },
                { CarSpace.TwoPlus, "2" },
                { CarSpace.ThreePlus, "3" },
                { CarSpace.FourPlus, "4" },
                { CarSpace.FivePlus, "5" },
            };
        }

        public Dictionary<Bathroom, string> GetBathrooms()
        {
            return new Dictionary<Bathroom, string>()
            {
                { Bathroom.Any, string.Empty },
                { Bathroom.OnePlus, "1" },
                { Bathroom.TwoPlus, "2" },
                { Bathroom.ThreePlus, "3" },
                { Bathroom.FourPlus, "4" },
                { Bathroom.FivePlus, "5" },
            };
        }

        public Dictionary<Price, string> GetPrices()
        {
            return new Dictionary<Price, string>()
            {
                { Price.MinAny, "0" },
                { Price.MaxAny, "Any" },
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

        public void Set(PropertyType propertyType, Bed minBeds, int minLand, Price minPrice, Price maxPrice, Location location, ConstructionType constructionType, CarSpace minCarSpaces, Bathroom minBathrooms, Bed maxBeds, bool isIncludingSurroundingSuburbs, bool isExcludingPropertiesUnderContract)
        {
            this.propertyType = propertyType;
            this.minBeds = minBeds;
            this.minLand = minLand;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            this.location = location;
            this.constructionType = constructionType;
            this.minCarSpaces = minCarSpaces;
            this.minBathrooms = minBathrooms;
            this.maxBeds = maxBeds;
            this.isIncludingSurroundingSuburbs = isIncludingSurroundingSuburbs;
            this.isExcludingPropertiesUnderContract = isExcludingPropertiesUnderContract;
        }

        public void SetUrl(string url)
        {
            Url = url;
        }

        public void GenerateUrl()
        {
            var parameters = GetParameters(constructionType,
                                            minCarSpaces,
                                            minBathrooms,
                                            minBeds,
                                            maxBeds,
                                            isIncludingSurroundingSuburbs,
                                            isExcludingPropertiesUnderContract,
                                            source);

            Url = string.Concat(realEstateDomain,
                                        buyController,
                                        GetPropertyTypesQuery(propertyType),
                                        GetMinBedsQuery(minBeds),
                                        GetMinLandQuery(minLand),
                                        GetPriceRangeQuery(minPrice, maxPrice),
                                        GetLocationQuery(location),
                                        "/",
                                        GetListingQuery(1),
                                        parameters);
        }

        public string GetMinLandQuery(int minLand)
        {
            var minLandQuery = string.Empty;

            if (minLand > 0)
            {
                minLandQuery = string.Concat("size-", minLand, "-");
            }

            return minLandQuery;
        }

        public string GetParameters(ConstructionType constructionType, CarSpace minCarSpaces, Bathroom minBathrooms, Bed minBeds, Bed maxBeds, bool isIncudingSurroundingSuburbs, bool isExcludingPropertiesUnderContract, string source)
        {
            var parameters = "?";

            if (constructionType != ConstructionType.Any)
            {
                parameters += GetConstructionTypeQuery(constructionType);
                parameters += "&";
            }

            if (minCarSpaces != CarSpace.Any)
            {
                parameters += GetMinCarSpacesQuery(minCarSpaces);
                parameters += "&";
            }

            if (minBathrooms != Bathroom.Any)
            {
                parameters += GetMinBathroomsQuery(minBathrooms);
                parameters += "&";
            }

            if (minBeds != Bed.Any)
            {
                parameters += GetMaxBedsQuery(maxBeds);
                parameters += "&";
            }

            if (!isIncudingSurroundingSuburbs)
            {
                parameters += GetSurroundingSuburbsQuery();
                parameters += "&";
            }

            if (isExcludingPropertiesUnderContract)
            {
                parameters += GetPropertiesUnderContractQuery();
                parameters += "&";
            }

            parameters += GetSourceQuery(source);

            return parameters;
        }

        public string GetSurroundingSuburbsQuery()
        {
            return "includeSurrounding=false";
        }

        public string GetPropertiesUnderContractQuery()
        {
            return "misc=ex-under-contract";
        }

        public string GetConstructionTypeQuery(ConstructionType constructionType)
        {
            return string.Concat("newOrEstablished=", ConstructionTypes[constructionType]);
        }

        public string GetMinCarSpacesQuery(CarSpace minCarSpaces)
        {
            return string.Concat("numParkingSpaces=", CarSpaces[minCarSpaces]);
        }

        public string GetMinBathroomsQuery(Bathroom minBathrooms)
        {
            return string.Concat("numBaths=", Bathrooms[minBathrooms]);
        }

        public string GetSourceQuery(string source)
        {
            return string.Concat("source=", source);
        }

        public string GetPriceRangeQuery(Price minPrice, Price maxPrice)
        {
            var priceRangeQuery = string.Empty;

            if (!(minPrice == Price.MinAny && maxPrice == Price.MaxAny))
            {
                priceRangeQuery = string.Concat("between-", Prices[minPrice], "-", Prices[maxPrice], "-").ToLower();
            }

            return priceRangeQuery;
        }

        public string GetMaxBedsQuery(Bed maxBeds)
        {
            return string.Concat("maxBeds=", Beds[maxBeds]);
        }

        public string GetListingQuery(int listing)
        {
            return string.Concat("list-", listing.ToString());
        }

        public string GetLocationQuery(Location location)
        {
            var locationQuery = string.Empty;

            if (Locations.ContainsKey(location))
            {
                locationQuery = string.Concat("in-", Locations[location].Replace(",", "%2c").Replace(" ", "+").Replace(";", "%3b").ToLower());
            }

            return locationQuery;
        }

        public string GetMinBedsQuery(Bed minBeds)
        {
            var minBedsQuery = string.Empty;

            if (Beds.ContainsKey(minBeds))
            {
                switch (minBeds)
                {
                    case Bed.Studio:
                        minBedsQuery = string.Concat("with-", Beds[minBeds], "-");
                        break;
                    case Bed.One:
                        minBedsQuery = string.Concat("with-", Beds[minBeds], "-bedroom-");
                        break;
                    case Bed.Two:
                    case Bed.Three:
                    case Bed.Four:
                    case Bed.Five:
                        minBedsQuery = string.Concat("with-", Beds[minBeds], "-bedrooms-");
                        break;
                    default:
                        break;
                }
            }

            return minBedsQuery;
        }

        public string GetPropertyTypesQuery(PropertyType propertyType)
        {
            var propertyTypesQuery = string.Empty;

            if (PropertyTypes.ContainsKey(propertyType))
            {
                if (propertyType != PropertyType.All)
                {
                    propertyTypesQuery = string.Concat("property-", PropertyTypes[propertyType], "-");
                }
            }

            return propertyTypesQuery;
        }

        public string GetWebResponse()
        {
            var responseFromServer = string.Empty;

            try
            {
                // Create a request for the URL.   
                WebRequest request = WebRequest.Create(Url);

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

        //public Listing GetListing(string url)
        //{
        //    //// get url
        //    //// get web response
        //    //var listing = new Listing();
        //    //var totalListings = listing.TotalListings;
        //    //var properties = listing.Properties;
        //    //var listedPropertyUrls = new List<string>();

        //    //foreach (var property in properties)
        //    //{
        //    //    listedPropertyUrls.Add(property.Url);
        //    //}

        //    //for (int i = 1; i < totalListings; i++)
        //    //{
        //    //    // get url with next list number
        //    //    // get web response
        //    //    listing = new Listing(string.Empty);
        //    //    properties = listing.Properties;

        //    //    foreach (var property in properties)
        //    //    {
        //    //        listedPropertyUrls.Add(property.Url);
        //    //    }
        //    //}

        //    //foreach (var url in listedPropertyUrls)
        //    //{
        //    //    // get web response
        //    //    var property = new Property(string.Empty);
        //    //}
        //}
    }
}
