using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectLibrary
{
    public class APIClass
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        private static readonly string BaseAddress = "http://api.airvisual.com/v2/";

        private static readonly string ApiKey = "017ba53d-e828-4795-8e07-54dc4ecd813b"; //leased for a year, 1 req/sec, 60 req/min

        public static DataModel GetCountries()
        {
            Uri url = new Uri(BaseAddress + "countries?key=" + ApiKey); //ex. http://api.airvisual.com/v2/countries?key=017ba53d-e828-4795-8e07-54dc4ecd813b
            try
            {
                //Console.WriteLine($"GetCountries uri: {url}");
                string data = ApiClient.GetStringAsync(url).Result;
                var res = JsonConvert.DeserializeObject<DataModel>(data);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read API data! Most likely a 429 error. Try again in a few seconds. Exception: {e}");
                return new DataModel();
            }
        }

        public static DataModel GetStates(string country)
        {
            try
            {
                //Console.WriteLine($"GetStates uri: {url}");
                string data = ApiClient.GetStringAsync(BaseAddress + "states?country=" + country + "&key=" + ApiKey).Result;
                var res = JsonConvert.DeserializeObject<DataModel>(data);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read API data! Most likely a 429 error. Try again in a few seconds. Exception: {e}");
                return new DataModel();
            }
        }

        public static DataModel GetCities(string country, string state)
        {
            try
            {
                //Console.WriteLine($"GetCities uri: {url}");
                string data = ApiClient.GetStringAsync(BaseAddress + "cities?state=" + state + "&country=" + country + "&key=" + ApiKey).Result;
                var res = JsonConvert.DeserializeObject<DataModel>(data);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read API data! Most likely a 429 error. Try again in a few seconds. Exception: {e}");
                return new DataModel();
            }
        }

        public static CityDataModel GetCityData(string country, string state, string city)
        {
            try
            {
                //Console.WriteLine($"GetCityData uri: {url}");
                string data = ApiClient.GetStringAsync(BaseAddress + "city?city=" + city + "&state=" + state + "&country=" + country + "&key=" + ApiKey).Result;
                var res = JsonConvert.DeserializeObject<CityDataModel>(data);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read API data! Most likely a 429 error. Try again in a few seconds. Exception: {e}");
                return new CityDataModel();
            }
        }
    }
}
