using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class GetNFLTeams
    {
        private static List<NFLTeam> GenerateNFLTeamStandings()
        {

            string endPoint = "https://site.api.espn.com/apis/v2/sports/football/nfl/standings";
            string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(1440, endPoint);
            var teamData = JsonConvert.DeserializeObject<List<NFLTeam>>(strJSON);
            return teamData;

        }

            
    }
}

