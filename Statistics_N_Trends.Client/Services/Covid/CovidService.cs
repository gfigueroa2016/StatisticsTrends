using Statistics_N_Trends.Client.Shared.Covid;
using System;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace Statistics_N_Trends.Client.Services.Covid
{
    public class CovidService
    {
        static readonly HttpClient Http = new HttpClient();

        public async Task<DailyReport> GetAllCaseCount(string country = null)
        {
            try
            {
                return await Http.GetFromJsonAsync<DailyReport>(string.Format("https://covid19-stats-api.herokuapp.com/api/v1/cases?country={0}", country));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DailyReport> GetAllCaseCount()
        {
            try
            {
                return await Http.GetFromJsonAsync<DailyReport>(string.Format("https://covid19-stats-api.herokuapp.com/api/v1/cases?country="));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CountryCount>> GetAllCaseCountByCountryAndType(string country, string type)
        {
            try
            {
                return await Http.GetFromJsonAsync<List<CountryCount>>(string.Format("https://covid19-stats-api.herokuapp.com/api/v1/cases/{0}/{1}", country, type));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CountryStateCount>> GetStateCaseCountByCountry(string country, string type)
        {
            try
            {
                return await Http.GetFromJsonAsync<List<CountryStateCount>>(string.Format("https://covid19-stats-api.herokuapp.com/api/v1/cases/state/{0}?country={1}", type, country));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
