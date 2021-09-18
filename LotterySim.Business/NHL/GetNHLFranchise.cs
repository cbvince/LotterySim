using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    class GetNHLFranchise
    {

        private static NHLFranchise.Rootobject GenerateNHLStandings()
        {

            string endPoint = "https://records.nhl.com/site/api/franchise?include=teams.id&include=teams.active&include=teams.triCode&include=teams.placeName&include=teams.commonName&include=teams.logos&include=teams.conference.name&include=teams.division.name";
            string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(1440, endPoint, "nhlFranchise");
            var franchiseData = JsonConvert.DeserializeObject<NHLFranchise.Rootobject>(strJSON);
            return franchiseData;

        }

        private static List<NHLFranchise.Team> GetNHLFranchiseTeams()
            {

            var nhlFranchiseData = GenerateNHLStandings().data;
            var nhlFranchiseTeams = new List<NHLFranchise.Team>();

            foreach (var data in nhlFranchiseData)
            {
                nhlFranchiseTeams.AddRange(data.teams);
            }

            return nhlFranchiseTeams;

            }

        public static List<NHLFranchise.Logo> GetNHLFranchiseLogos()
        {
            var nhlFranchiseTeams = GetNHLFranchiseTeams();
            var nhlFranchiseTeamLogos = new List<NHLFranchise.Logo>();
            
            foreach (var nhlFranchiseTeam in nhlFranchiseTeams)
            {
                nhlFranchiseTeamLogos.Add(nhlFranchiseTeam.logos.OrderByDescending(p => p.id).LastOrDefault());
            }
            return nhlFranchiseTeamLogos;
        }




    }
}
