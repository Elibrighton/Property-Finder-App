using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class Property
    {
        public Address Address { get; set; }
        public int PropertyNo { get; set; }
        public string Url { get; private set; }
        public int Price { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int LandSize { get; set; }
        public int CarSpaces { get; set; }

        private const string realEstateDomain = "http://www.realestate.com.au/";

        private string response;

        public Property(string response)
        {
            if (string.IsNullOrEmpty(response)) throw new ArgumentNullException("Property response is null");

            this.response = response;
            Address = new Address(response);
            PropertyNo = GetPropertyNo();
            Price = GetPrice();
            PropertyType = GetPropertyType();
            Bedrooms = GetBedrooms();
            Bathrooms = GetBathrooms();
            LandSize = GetLandSize();
            CarSpaces = GetCarSpaces();
        }

        public void SetUrl(string url)
        {
            Url = url;
        }

        public int GetPropertyNo()
        {
            //<span class="property_id">Property No. 125115106</span>

            var propertyNo = 0;
            var spanValue = response.GetSpanClassValue("property_id");

            if (!string.IsNullOrEmpty(spanValue))
            {
                var propertyNoText = RegexHelper.GetRegexMatchValue(spanValue, @"\d*$");

                if (!string.IsNullOrEmpty(propertyNoText))
                {
                    propertyNo = Convert.ToInt32(propertyNoText);
                }
            }

            return propertyNo;
        }

        public int GetPrice()
        {
            //<p class="priceText">Auction</p>

            var price = 0;
            var spanValue = response.GetParagraphClassValue("priceText");

            if (!string.IsNullOrEmpty(spanValue))
            {
                var priceText = RegexHelper.GetRegexMatchValue(spanValue, @"\$\d*,\d*,?(\d?){3}");

                if (!string.IsNullOrEmpty(priceText))
                {
                    priceText = priceText.Replace("$", "").Replace(",", "");
                    price = Convert.ToInt32(priceText);
                }
            }

            return price;
        }

        public string GetPropertyType()
        {
            //<li>Property Type:<span>House</span></li>

            return response.GetLiValue("Property\\sType:");
        }

        public int GetBedrooms()
        {
            //<li>Bedrooms:<span>3</span></li>
            var bedrooms = 0;
            var bedroomsText = response.GetLiValue("Bedrooms:");

            if (!string.IsNullOrEmpty(bedroomsText))
            {
                bedrooms = Convert.ToInt32(bedroomsText);
            }

            return bedrooms;
        }

        public int GetBathrooms()
        {
            //<li>Bathrooms:<span>2</span></li>

            var bathrooms = 0;
            var bathroomsText = response.GetLiValue("Bathrooms:");

            if (!string.IsNullOrEmpty(bathroomsText))
            {
                bathrooms = Convert.ToInt32(bathroomsText);

                if (bathrooms < 2)
                {
                    bathrooms = bathrooms;
                }
            }

            return bathrooms;
        }

        public int GetLandSize()
        {
            //<li>Land Size:<span>1055 m² (approx)</span></li>

            var landSize = 0;
            var liValue = response.GetLiValue("Land\\sSize:");

            if (!string.IsNullOrEmpty(liValue))
            {
                var landSizeText = RegexHelper.GetRegexMatchValue(liValue, @"^\d*");

                if (!string.IsNullOrEmpty(landSizeText))
                {
                    landSize = Convert.ToInt32(landSizeText);
                }
            }

            return landSize;
        }
        
        public int GetCarportSpaces()
        {
            //<li>Carport Spaces:<span>1</span></li>

            var carportSpaces = 0;
            var carportSpacesText = response.GetLiValue("Carport\\sSpaces:");

            if (!string.IsNullOrEmpty(carportSpacesText))
            {
                carportSpaces = Convert.ToInt32(carportSpacesText);
            }

            return carportSpaces;
        }

        public int GetGarageSpaces()
        {
            //<li>Garage Spaces:<span>2</span></li>

            var garageSpaces = 0;
            var garageSpacesText = response.GetLiValue("Garage\\sSpaces:");

            if (!string.IsNullOrEmpty(garageSpacesText))
            {
                garageSpaces = Convert.ToInt32(garageSpacesText);
            }

            return garageSpaces;
        }

        public int GetOtherCarSpaces()
        {
            //<li>Open Car Spaces:<span>1</span></li>

            var otherCarSpaces = 0;
            var otherCarSpacesText = response.GetLiValue("Open\\sCar\\sSpaces:");

            if (!string.IsNullOrEmpty(otherCarSpacesText))
            {
                otherCarSpaces = Convert.ToInt32(otherCarSpacesText);
            }

            return otherCarSpaces;
        }

        public int GetCarSpaces()
        {
            var carSpaces = GetCarportSpaces();
            carSpaces += GetGarageSpaces();
            carSpaces += GetOtherCarSpaces();

            return carSpaces;
        }
    }
}
