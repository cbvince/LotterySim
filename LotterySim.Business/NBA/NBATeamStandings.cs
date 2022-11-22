using LotterySim.Business.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NBA
{
	public class NBATeamStandings
	{

			public string uid { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string abbreviation { get; set; }
			public string shortName { get; set; }
			public Child[] children { get; set; }
			public Link2[] links { get; set; }
			public Season[] seasons { get; set; }
		

		public class Child
		{
			public string uid { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string abbreviation { get; set; }
			public Standings standings { get; set; }
		}

		public class Standings
		{
			public string id { get; set; }
			public string name { get; set; }
			public string displayName { get; set; }
			public Link[] links { get; set; }
			public int season { get; set; }
			public int seasonType { get; set; }
			public Entry[] entries { get; set; }
		}

		public class Link
		{
			public string language { get; set; }
			public string[] rel { get; set; }
			public string href { get; set; }
			public string text { get; set; }
			public string shortText { get; set; }
			public bool isExternal { get; set; }
			public bool isPremium { get; set; }
		}

		public class Entry
		{
			public Team team { get; set; }
			public Stat[] stats { get; set; }
		}

		public class Team
		{
			public string id { get; set; }
			public string uid { get; set; }
			public string location { get; set; }
			public string name { get; set; }
			public string abbreviation { get; set; }
			public string displayName { get; set; }
			public string shortDisplayName { get; set; }
			public bool isActive { get; set; }
			public Logo[] logos { get; set; }
			public Link1[] links { get; set; }
		}

		public class Logo
		{
			public string href { get; set; }
			public int width { get; set; }
			public int height { get; set; }
			public string alt { get; set; }
			public string[] rel { get; set; }
			public string lastUpdated { get; set; }
		}

		public class Link1
		{
			public string language { get; set; }
			public string[] rel { get; set; }
			public string href { get; set; }
			public string text { get; set; }
			public string shortText { get; set; }
			public bool isExternal { get; set; }
			public bool isPremium { get; set; }
		}

		public class Stat
		{
			public string name { get; set; }
			public string displayName { get; set; }
			public string shortDisplayName { get; set; }
			public string description { get; set; }
			public string abbreviation { get; set; }
			public string type { get; set; }
			public float value { get; set; }
			public string displayValue { get; set; }
			public string id { get; set; }
			public string summary { get; set; }
		}

		public class Link2
		{
			public string language { get; set; }
			public string[] rel { get; set; }
			public string href { get; set; }
			public string text { get; set; }
			public string shortText { get; set; }
			public bool isExternal { get; set; }
			public bool isPremium { get; set; }
		}

		public class Season
		{
			public int year { get; set; }
			public string startDate { get; set; }
			public string endDate { get; set; }
			public string displayName { get; set; }
			public Type[] types { get; set; }
		}

		public class Type
		{
			public string id { get; set; }
			public string name { get; set; }
			public string abbreviation { get; set; }
			public string startDate { get; set; }
			public string endDate { get; set; }
			public bool hasStandings { get; set; }
		}

		public static NBATeamStandings GetStandings()
		{
			//string endPoint = "http://data.nba.net/10s/prod/v1/current/standings_all.json";
			string endPoint = "https://site.api.espn.com/apis/v2/sports/basketball/nba/standings";
			string strJSON = GetTeamDataFromWeb.GetTeamDataFromCache(30, endPoint, "nba");
			return JsonConvert.DeserializeObject<NBATeamStandings>(strJSON);
		}

		public static List<NBATeam> GetTeams()
		{
			NBATeamStandings nbaTeamStandingData = NBATeamStandings.GetStandings();
			List<NBATeam> teams = new List<NBATeam>();

			List<Child> children = nbaTeamStandingData.children.ToList();
			List<Entry> entries = new List<Entry>();

			foreach (Child child in children)
			{
				entries.AddRange(child.standings.entries);
			}

			foreach (Entry entry in entries)
			{
				NBATeam team = new NBATeam();

				team.TeamName = entry.team.location;
				team.TeamID = Convert.ToInt32(entry.team.id);
				team.TeamNickName = entry.team.name;
				team.OriginalTeamName = entry.team.location;
				team.Wins = Convert.ToInt32(entry.stats[10].displayValue);
				team.Losses = Convert.ToInt32(entry.stats[6].displayValue);
				team.WinLossRecord = team.Wins + "-" + team.Losses;
				team.WinPercentage = Decimal.Parse(entry.stats[9].displayValue);
				team.GamesBack = Convert.ToDouble(entry.stats[4].value);
				team.LastTenGamesRecord = entry.stats[16].displayValue;
				team.SetLastTenWinLoss();
				team.ConsecutiveWinLoss = Convert.ToInt32(entry.stats[8].value);
				team.WinLossStreak = entry.stats[8].displayValue;
				team.ConferenceRank = Convert.ToInt32(entry.stats[7].displayValue);
				team.ImageUrl = entry.team.logos[0].href;
				teams.Add(team);
			};

			NBAStandingsHelper.UpdateStandingsData(teams);
			return teams;
		}
	}
}
