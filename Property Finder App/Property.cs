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
        public string Price { get; set; }
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

        public string GetPrice()
        {
            //<p class="priceText">Auction</p>

            return response.GetParagraphClassValue("priceText");
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
        
        public int GetCarSpaces()
        {
            //<li>Garage Spaces:<span>2</span></li>

            var carSpaces = 0;
            var carSpacesText = response.GetLiValue("Garage\\sSpaces:");
            if (!string.IsNullOrEmpty(carSpacesText))
            {
                carSpaces = Convert.ToInt32(carSpacesText);
            }

            return carSpaces;
        }
    }
}
