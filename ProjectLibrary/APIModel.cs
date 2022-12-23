using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class DataModel
    {
        public List<Dictionary<string,string>> Data { get; set; }
    }

    public class CityDataModel
    {
        public CurrentDataModel Data { get; set; }
    }

    public class CurrentDataModel
    {
        public WPDataModel Current { get; set; }
    }

    public class WPDataModel
    {
        public AQIModel Pollution { get; set; }
        public WeatherModel Weather { get; set; }
    }

    public class AQIModel
    {
        public string Aqius { get; set; } 
    }

    public class WeatherModel
    {
        public string Tp { get; set; } //temperature
        public string Ic { get; set; } //icon for weather
    }
}
