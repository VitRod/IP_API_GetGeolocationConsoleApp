using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// In order to work with this  API it is  needed to download  from NuGet such packages: IP-API by Luke Preiner  and Microsoft.AspNet.WebApi.Client
// After that errors  will disappear and  application will work.
//

namespace IP_API_GetGeolocationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // IP API URL
            var Ip_Api_Url = "http://ip-api.com/json/106.159.39.132"; // 106.159.39.132 - This is a sample IP address. You can pass yours if you want to test          

            // Use HttpClient to get the details from the Json response
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Pass API address to get the Geolocation details 
                httpClient.BaseAddress = new Uri(Ip_Api_Url);
                HttpResponseMessage httpResponse = httpClient.GetAsync(Ip_Api_Url).GetAwaiter().GetResult();
                // If API is success and receive the response, then get the location details
                if (httpResponse.IsSuccessStatusCode)
                {
                    var geolocationInfo = httpResponse.Content.ReadAsAsync<LocationDetails_IpApi>().GetAwaiter().GetResult();
                    if (geolocationInfo != null)
                    {
                        Console.WriteLine("Query: " + geolocationInfo.query);
                        Console.WriteLine("Country: " + geolocationInfo.country);
                        Console.WriteLine("Country Code: " + geolocationInfo.countryCode);
                        Console.WriteLine("Region: " + geolocationInfo.regionName);
                        Console.WriteLine("Region: " + geolocationInfo.region);
                        Console.WriteLine("City: " + geolocationInfo.city);
                        
                        Console.WriteLine("Isp: " + geolocationInfo.isp);
                        Console.WriteLine("Organization: " + geolocationInfo.org);
                        Console.WriteLine("Latitude: " + geolocationInfo.lat);
                        Console.WriteLine("Longitude: " + geolocationInfo.lon);
                  
                        Console.WriteLine("Timezone: " + geolocationInfo.timezone);
                        Console.WriteLine("Zip: " + geolocationInfo.zip);
                        Console.WriteLine("Status: " + geolocationInfo.status);
                        Console.ReadKey();
                    }
                }
            }
        }
    }

    public class LocationDetails_IpApi
    {
        public string query { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string isp { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string org { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string zip { get; set; }
    }
}