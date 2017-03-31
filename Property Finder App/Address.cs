using System;

namespace Property_Finder_App
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string AddressLocality { get; set; }
        public string AddressRegion { get; set; }
        public string PostalCode { get; set; }

        private string response { get; set; }

        public Address(string response)
        {
            if (string.IsNullOrEmpty(response)) throw new ArgumentNullException("Address response is null");

            this.response = response;
            StreetAddress = GetStreetAddress();
            AddressLocality = GetAddressLocality();
            AddressRegion = GetAddressRegion();
            PostalCode = GetPostalCode();
        }

        public string GetStreetAddress()
        {
            return response.GetSpanItemPropValue("streetAddress");
        }

        public string GetAddressLocality()
        {
            return response.GetSpanItemPropValue("addressLocality");
        }

        public string GetAddressRegion()
        {
            return response.GetSpanItemPropValue("addressRegion");
        }

        public string GetPostalCode()
        {
            return response.GetSpanItemPropValue("postalCode");
        }
    }
}
