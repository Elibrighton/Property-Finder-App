using Property_Finder_App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Finder
{
    public class DistanceFinder
    {
        //private const string googleMapsDomain = "https://www.google.com.au/maps/dir/";
        private const string googleMapsApi = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=";

        public string GetAddressQuery(Address address)
        {
            /*139 Sumners Rd
            Jamboree Heights
            Qld
            4074 
            139+Sumners+Rd,+Jamboree+Heights+QLD+4074*/
            
            if (string.IsNullOrEmpty(address.StreetAddress)) throw new ArgumentNullException("Address Street Address is null");
            if (string.IsNullOrEmpty(address.AddressLocality)) throw new ArgumentNullException("Address Locality is null");
            if (string.IsNullOrEmpty(address.AddressRegion)) throw new ArgumentNullException("Address Region is null");
            if (string.IsNullOrEmpty(address.PostalCode)) throw new ArgumentNullException("Address Postal Code is null");

            return string.Concat(address.StreetAddress, ", ", 
                address.AddressLocality, " ", 
                address.AddressRegion.ToUpper(), " ",
                address.PostalCode).Replace(" ", "+");
        }

        public string GetUrl(Address startingAddress, Address destinationAddress)
        {
            //https://www.google.com.au/maps/dir/Central+Station,+Brisbane+City+QLD/139+Sumners+Rd,+Jamboree+Heights+QLD+4074/
            //https://maps.googleapis.com/maps/api/distancematrix/xml?origins=Central+Station,+Brisbane+City+QLD+4000&destinations=9+Carolina+Parade,+Forest+Lake+QLD+4078

            var startingAddressQuery = string.Empty;
            var destinationAddressQuery = string.Empty;

            try
            {
                startingAddressQuery = GetAddressQuery(startingAddress);
                destinationAddressQuery = GetAddressQuery(destinationAddress);
            }
            catch (ArgumentNullException)
            {
                // leave the address queries as empty
            }
            catch (Exception)
            {

                throw;
            }

            var url = string.Empty;

            if (!string.IsNullOrEmpty(startingAddressQuery) && !string.IsNullOrEmpty(destinationAddressQuery))
            {
                url = string.Concat(googleMapsApi, startingAddressQuery, "&destinations=", destinationAddressQuery);
            }

            return url;
        }

        public float GetDistance(string response)
        {
            var distance = 0.0f;

            var matchValue = RegexHelper.GetRegexMatchValue(response, @"\d\d?\.?\d\skm");

            if (!string.IsNullOrEmpty(matchValue))
            {
                distance = float.Parse(matchValue.Replace(" km", ""), CultureInfo.InvariantCulture.NumberFormat);
            }

            return distance;
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
    }
}
