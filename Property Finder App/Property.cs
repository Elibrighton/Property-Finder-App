using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class Property
    {
        private const string realEstateDomain = "http://www.realestate.com.au/";

        public Address Address { get; set; }
        public int PropertyNo { get; set; }
        public string Url { get; private set; }
        public string Price { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string LandSize { get; set; }
        public int CarSpaces { get; set; }

        private string response;

        public Property(string response)
        {
            if (string.IsNullOrEmpty(response)) throw new ArgumentNullException("Property response is null");

            this.response = response;
            Address = GetAddress();
            PropertyNo = GetPropertyNo();
            Price = GetPrice();
            PropertyType = GetPropertyType();
            Bedrooms = GetBedrooms();
            Bathrooms = GetBathrooms();
            LandSize = GetLandSize();
            CarSpaces = GetCarSpaces();
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

        public Address GetAddress()
        {
            return new Address(response);
        }

        public void SetUrl(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("Property path is null");

            Url = string.Concat(realEstateDomain, path.Replace("/", ""));
        }

        public string GetPrice()
        {
            return response.GetParagraphClassValue("priceText");
        }

        public string GetPropertyType()
        {
            return response.GetLiValue("Property\\sType:");
        }

        public int GetBedrooms()
        {
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
            var bathrooms = 0;
            var bathroomsText = response.GetLiValue("Bathrooms:");

            if (!string.IsNullOrEmpty(bathroomsText))
            {
                bathrooms = Convert.ToInt32(bathroomsText);
            }

            return bathrooms;
        }

        public string GetLandSize()
        {
            return response.GetLiValue("Land\\sSize:");
        }
        
        public int GetCarSpaces()
        {
            var carSpaces = 0;
            var carSpacesText = response.GetLiValue("Garage\\sSpaces:");
            //<li>Garage Spaces:<span>2</span></li>
            if (!string.IsNullOrEmpty(carSpacesText))
            {
                carSpaces = Convert.ToInt32(carSpacesText);
            }

            return carSpaces;
        }
    }
}
