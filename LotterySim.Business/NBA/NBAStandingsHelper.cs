using System.Collections.Generic;
using System.Linq;
using LotterySim.Business.NBA;
using LotterySim.Business.Common;
using System.Data;

namespace LotterySim.Business
{
    public static class NBAStandingsHelper
    {
        public static void UpdateStandingsData(List<NBATeam> teams)
        {
            OrderTeams(teams);
            SetPickNumberFromRanking(teams);
            DetermineGamesBack(teams);
            AddTopFourPickOdds(teams);
            AddTopOnePickOdds(teams);
            PickProtections.PickProtection(teams);
        }

		private static void OrderTeams(List<NBATeam> teams)
		{
			List<NBATeam> lotteryTeams = teams.Where(p => p.ConferenceRank > 8).OrderBy(p => p.WinPercentage).ToList();
			List<NBATeam> playoffTeams = teams.Where(p => p.ConferenceRank <= 8).OrderBy(p => p.WinPercentage).ToList();

            teams.Clear();
            teams.AddRange(lotteryTeams);
            teams.AddRange(playoffTeams);

			int i = 1;

			foreach (NBATeam team in teams)
			{
				team.TeamRank = i++;
			}
		}

		private static void SetPickNumberFromRanking(List<NBATeam> teams)
		{
			foreach (var team in teams)
			{
				team.PickNumber = team.TeamRank;
			}
		}

		private static void DetermineGamesBack(List<NBATeam> teams)
        {
            var highestNumberOfLosses = teams.OrderByDescending(p => p.Losses).FirstOrDefault().Losses;
            var lowestNumberOfWins = teams.OrderBy(p => p.Wins).FirstOrDefault().Wins;
            var winLostDifferenceForWorstTeam = highestNumberOfLosses - lowestNumberOfWins;

            foreach (var team in teams)
            {
                var teamWinLossDifference = team.Losses - team.Wins;

                team.LotteryGamesBack = GenericStandingDataMethods.GetGamesBack(highestNumberOfLosses, lowestNumberOfWins, teamWinLossDifference);
            }
        }

        private static void AddTopFourPickOdds(List<NBATeam> teams)
        {
            foreach (var team in teams)
            {
                switch (team.TeamRank)
                {
                    case 1:
                    case 2:
                    case 3:
                        team.TopFourPickOdds = "52.1%";
                        break;
                    case 4:
                    case 5:
                        team.TopFourPickOdds = "45.1%";
                        break;
                    case 6:
                        team.TopFourPickOdds = "37.2%";
                        break;
                    case 7:
                        team.TopFourPickOdds = "31.9%";
                        break;
                    case 8:
                    case 9:
                    case 10:
                        team.TopFourPickOdds = "20.3%";
                        break;
                    case 11:
                        team.TopFourPickOdds = "8.5%";
                        break;
                    case 12:
                        team.TopFourPickOdds = "8.0%";
                        break;
                    case 13:
                        team.TopFourPickOdds = "4.8%";
                        break;
                    case 14:
                        team.TopFourPickOdds = "2.4%";
                        break;
                }
            }
        }

        private static void AddTopOnePickOdds(List<NBATeam> teams)
        {
            foreach (var team in teams)
            {
                switch (team.TeamRank)
                {
                    case 1:
                    case 2:
                    case 3:
                        team.TopPickOdds = "14.0%";
                        break;
                    case 4:
                    case 5:
                        team.TopPickOdds = "11.5%";
                        break;
                    case 6:
                        team.TopPickOdds = "9.0%";
                        break;
                    case 7:
                        team.TopPickOdds = "7.5%";
                        break;
                    case 8:
                    case 9:
                    case 10:
                        team.TopPickOdds = "4.5%";
                        break;
                    case 11:
                        team.TopPickOdds = "1.8%";
                        break;
                    case 12:
                        team.TopPickOdds = "1.7%";
                        break;
                    case 13:
                        team.TopPickOdds = "1.0%";
                        break;
                    case 14:
                        team.TopPickOdds = "0.5%";
                        break;


                }
            }
        }

		public static string GetWinLossStreakColor(NBATeam team)
		{
			if (team.ConsecutiveWinLoss > 3 && team.ConsecutiveWinLoss < 5) return "text-warning";
			if (team.ConsecutiveWinLoss >= 5) return "text-danger";
			if (team.ConsecutiveWinLoss < -3) return "text-success";
			return "";
		}

		public static string GetLast10WinLossColor(NBATeam team)
		{
			if (team.LastTenLosses >= 7) return "text-success";
			if (team.LastTenLosses <= 3) return "text-danger";
			return "";
		}
	}
}
