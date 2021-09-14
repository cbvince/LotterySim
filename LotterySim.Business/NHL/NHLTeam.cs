using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    class NHLTeam
    {

        public class Rootobject
        {
            public string copyright { get; set; }
            public Record[] records { get; set; }
        }

        public class Record
        {
            public string standingsType { get; set; }
            public League league { get; set; }
            public Division division { get; set; }
            public Conference conference { get; set; }
            public Teamrecord[] teamRecords { get; set; }
        }

        public class League
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Division
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Conference
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Teamrecord
        {
            public Team team { get; set; }
            public Leaguerecord leagueRecord { get; set; }
            public int regulationWins { get; set; }
            public int goalsAgainst { get; set; }
            public int goalsScored { get; set; }
            public int points { get; set; }
            public string divisionRank { get; set; }
            public string divisionL10Rank { get; set; }
            public string divisionRoadRank { get; set; }
            public string divisionHomeRank { get; set; }
            public string conferenceRank { get; set; }
            public string conferenceL10Rank { get; set; }
            public string conferenceRoadRank { get; set; }
            public string conferenceHomeRank { get; set; }
            public string leagueRank { get; set; }
            public string leagueL10Rank { get; set; }
            public string leagueRoadRank { get; set; }
            public string leagueHomeRank { get; set; }
            public string wildCardRank { get; set; }
            public int row { get; set; }
            public int gamesPlayed { get; set; }
            public Streak streak { get; set; }
            public string clinchIndicator { get; set; }
            public float pointsPercentage { get; set; }
            public string ppDivisionRank { get; set; }
            public string ppConferenceRank { get; set; }
            public string ppLeagueRank { get; set; }
            public DateTime lastUpdated { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Leaguerecord
        {
            public int wins { get; set; }
            public int losses { get; set; }
            public int ot { get; set; }
            public string type { get; set; }
        }

        public class Streak
        {
            public string streakType { get; set; }
            public int streakNumber { get; set; }
            public string streakCode { get; set; }
        }

    }
}
