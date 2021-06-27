using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    public class PickProtections
    {
        public static void PickProtection(List<Team> teams)
        {
            DetermineProtection(teams, 4, "Houston", "Oklahoma City");
            DetermineProtection(teams, 3, "Minnesota", "Golden State");
            DetermineProtection(teams, 4, "Chicago", "Orlando");
            DetermineProtection(teams, 14, "Portland", "Houston");
            DetermineProtection(teams, 9, "Milwaukee", "Houston");
            DetermineProtection(teams, 0, "Dallas", "New York");
            DetermineProtection(teams, 16, "Detroit", "Houston");
            //DetermineProtection(teams, 0, "Boston", "Oklahoma City");
            DetermineProtectionOKCSwaps(teams);
        }


        private static void DetermineProtection(List<Team> teams, int protectionThreshold, string originalTeam, string newTeam)
        {

            var teamToConvey = teams.FirstOrDefault(p => p.OriginalTeamName == originalTeam);
            teamToConvey.TeamPickOwedToName = newTeam;

            if (teamToConvey.PickNumber > protectionThreshold)

            {
                teamToConvey.TeamName = string.Format("{0} to {1}", originalTeam, newTeam);
                teamToConvey.NewTeamName = newTeam;
                teamToConvey.PickSwapType = PickSwapType.Swapped;
            }


            else
            {
                teamToConvey.TeamName = originalTeam;
                teamToConvey.NewTeamName = null;
                teamToConvey.PickSwapType = PickSwapType.Protected;
            }

        }

        //OKC gets 3 best of OKC/HOU/MIA, HOU gets worst & can swap with BKN
        private static void DetermineProtectionOKCSwaps(List<Team> teams)
        {
            var houston = teams.FirstOrDefault(p => p.OriginalTeamName == "Houston");
            var okc = teams.FirstOrDefault(p => p.OriginalTeamName == "Oklahoma City");
            var miami = teams.FirstOrDefault(p => p.OriginalTeamName == "Miami");
            var boston = teams.FirstOrDefault(p => p.OriginalTeamName == "Boston");
            var highestPickSwapTeam = teams.FirstOrDefault(p => p.OriginalTeamName == "Boston" || p.OriginalTeamName == "Houston" || p.OriginalTeamName == "Oklahoma City" || p.OriginalTeamName == "Miami");
            var lowestPickSwapTeam =
                teams.Where(p => p.OriginalTeamName == "Boston" || p.OriginalTeamName == "Houston" || p.OriginalTeamName == "Oklahoma City" || p.OriginalTeamName == "Miami")
                .OrderByDescending(x => x.PickNumber).FirstOrDefault();


            if (houston.PickNumber <= 4)
            {
                foreach (var team in teams.Where(p => p.OriginalTeamName == "Boston" || p.OriginalTeamName == "Oklahoma City" || p.OriginalTeamName == "Miami"))
                {
                    SwapPicks(team, okc);
                }
            }

            else
            {
                foreach (var team in teams.Where(p => p.OriginalTeamName == "Boston" || p.OriginalTeamName == "Oklahoma City" || p.OriginalTeamName == "Miami" || p.OriginalTeamName == "Houston"))
                {
                    SwapPicks(team, okc);
                    
                }
                SwapPicks(lowestPickSwapTeam, houston);
            }


        }

        private static void SwapPicks(Team fromteam, Team toteam)
        {
            if (fromteam == toteam)
            {
                return;
            }


            fromteam.TeamPickOwedToName = toteam.OriginalTeamName;
            fromteam.NewTeamName = toteam.OriginalTeamName;
            fromteam.TeamName = string.Format("{0} to {1}", fromteam.OriginalTeamName, toteam.OriginalTeamName);
            fromteam.PickSwapType = PickSwapType.Swapped;
        }

        public static List<Team> OutGoingPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => p.OriginalTeamName == team.OriginalTeamName && p.NewTeamName != null).ToList();
        }
        public static List<Team> IncomingPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => (p.OriginalTeamName == team.OriginalTeamName && p.NewTeamName == null) || p.NewTeamName == team.OriginalTeamName).OrderBy(p => p.PickNumber).ToList();
        }
        public static List<Team> NonConveyedPicks(Team team)
        {
            return LotterySim.Business.GetTeams.GetLotteryTeams().Where(p => p.TeamPickOwedToName == team.OriginalTeamName && p.PickSwapType == PickSwapType.Protected).ToList();
        }


    }
}
