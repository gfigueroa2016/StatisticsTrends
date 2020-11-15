using System;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace Statistics_N_Trends.Client.Services.Climate
{
    public class ClimateService
    {
        static HttpClient Http = new HttpClient();

        public async Task<List<ClimateMonth>> GetClimateData(string city)
        {
            int code = GetCityCode(city);
            if (code != 0)
            {
                var root = await Http.GetFromJsonAsync<Root>(string.Format("http://worldweather.wmo.int/en/json/{0}_en.json", code));
                return root.city.climate.climateMonth;
            }
            else
                return null;
        }

        public string[] GetCities()
        {
            return cities.Keys.OrderBy((s1) => s1).ToArray();
        }

        int GetCityCode(string city)
        {
            var code = 0;
            if (!string.IsNullOrEmpty(city))
                cities.TryGetValue(city, out code);
            return code;
        }

        /// <summary>
        /// Store in dict to keep it simple.
        /// The real list can be found here https://worldweather.wmo.int/en/json/full_city_list.txt
        /// </summary>
        Dictionary<string, int> cities = new Dictionary<string, int>()
        {
            { "Amsterdam", 143 },
            { "London", 32 },
            { "Moscow", 206 },
            { "Singapore", 234 },
            { "New York City", 278 },
            { "Tokyo", 183 },
            { "Rio De Janeiro", 1080 },
            { "Beijing", 237 },
            { "Berlin", 59  },
            { "Paris", 194 },
            { "Seattle", 277 },
            { "Los Angeles",269},
            { "Sydney", 300}
};
    }

    public class ClimateMonth
    {
        public int month { get; set; }
        public string maxTemp { get; set; }
        public string minTemp { get; set; }

        public double MaxT { get { return double.Parse(maxTemp); } }
        public double MinT { get { return double.Parse(minTemp); } }

        public string MonthShort
        {
            get { return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[month - 1]; }
        }
    }

    public class Climate
    {
        public List<ClimateMonth> climateMonth { get; set; }
    }

    public class City
    {
        public string cityName { get; set; }
        public int cityId { get; set; }
        public Climate climate { get; set; }
    }

    public class Root
    {
        public City city { get; set; }
    }
}
