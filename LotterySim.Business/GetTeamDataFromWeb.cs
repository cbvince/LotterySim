using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    public class GetTeamDataFromWeb
    {
        private static string GetTeamData(string endPoint)
        {
            var client = new RestClient(endPoint);
            client.Timeout = 20000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content).ToString();

        }

        public static string GetTeamDataFromCache(int cacheFrequencyMinutes, string endPoint, string teamType)
        {

            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(teamType))
            {
                var teams = cache.GetCacheItem(teamType).Value.ToString();
                return teams;
            }

            else
            {
                cache.Add(teamType, GetTeamData(endPoint), DateTimeOffset.Now.AddMinutes(cacheFrequencyMinutes));
                return GetTeamDataFromCache(cacheFrequencyMinutes, endPoint, teamType);
            }



        
        
        }
    }
}
