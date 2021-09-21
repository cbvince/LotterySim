using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    class GetNHLTeams
    {
        private static NHLTeam.Rootobject GenerateNHLStandings()
        {

            string endPoint = "https://statsapi.web.nhl.com/api/v1/standings";
            string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(1440, endPoint, "nhl");
            var teamData = JsonConvert.DeserializeObject<NHLTeam.Rootobject>(strJSON);
            return teamData;

        }

        private static List<NHLTeam.Record> GetRecordsFromRootObject()
            {

            var records = new List<NHLTeam.Record>();
            records.AddRange(GenerateNHLStandings().records);

            return records;


            }

        public static List<NHLTeam.Teamrecord> GetTeamRecordsFromRecords()
        {
            var teamRecords = new List<NHLTeam.Teamrecord>();
            var records = GetRecordsFromRootObject();

            foreach (var record in records)

            {

                teamRecords.AddRange(record.teamRecords);
                SetNHLTeamImages(teamRecords);
            }

            return teamRecords;


        }

        public static List<NHLTeam.Teamrecord> GetOrderedTeams()
        {
            var teams = GetTeamRecordsFromRecords();
            var orderedTeams = new List<NHLTeam.Teamrecord>();

            //orderedTeams.AddRange(teams.Where(p => int.Parse(p.divisionRank) > 3).OrderBy(p => p.points));

            //	Playoff teams that did not win their divisions and did not make the conference finals, sorted by points, are assigned the next picks
            //orderedTeams.AddRange(teams.Where(p => int.Parse(p.divisionRank) <= 3).OrderByDescending(p => p.conferenceRank));

            orderedTeams.AddRange(teams.OrderByDescending(p => p.leagueRank));



            return orderedTeams;
        }

        private static void SetNHLTeamImages(List<NHLTeam.Teamrecord> teamRecords)
        {
            var images = GetNHLFranchise.GetNHLFranchiseLogos();

            foreach (var teamRecord in teamRecords)
            {
                teamRecord.team.Image = images.Where(p => p.teamId == teamRecord.team.id).FirstOrDefault().url;
            }
        }





     



   }
}
