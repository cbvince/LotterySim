using LotterySim.Business.NBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    public class PickProtections
    {
        public static void PickProtection(List<NBATeam> teams)
        {
            DetermineProtection(teams, 30, 4, "Houston", "Oklahoma City", "OKC gets 2 best of OKC/HOU/MIA, HOU gets worst & can swap with BKN");
            DetermineProtection(teams, 30, 3, "Minnesota", "Golden State", "Protected 1-3 - Russell/Wiggins trade");
            DetermineProtection(teams, 30, 4, "Chicago", "Orlando", "Protected 1-4 - Vucevic/Carter trade");
            DetermineProtection(teams, 30, 14, "Portland", "Houston", "Protected 1-14 - Ariza/Covington trade");
            DetermineProtection(teams, 30, 9, "Milwaukee", "Houston", "Protected 1-9 - Houston can swap 2nd round pick with Milwaukee 1st");
            DetermineProtection(teams, 30, 0, "Dallas", "New York", "Unprotected - Kristaps Porzingis trade");
            DetermineProtection(teams, 30, 16, "Detroit", "Houston", "Protected 1-16 - Wood for Stewart/Ariza trade");
            DetermineProtection(teams, 8, 0, "Los Angeles", "New Orleans", "Protected 8-30 - Anthony Davis for Ingram/Ball/Hart trade");
            DetermineProtection(teams, 14, 8, "Utah", "Memphis", "Protected 1-7, 15-30 - Mike Conley trade");
            DetermineProtection(teams, 30, 20, "Golden State", "Oklahoma City", "Protected 1-20 - Kelly Oubre trade");
            DetermineProtectionOKCSwaps(teams);
        }


        private static void DetermineProtection(List<NBATeam> teams,int lowerprotectionthreshold, int upperprotectionthreshold, string originalteam, string newteam, string picktradedetails = "")
        {

            var teamToConvey = teams.FirstOrDefault(p => p.OriginalTeamName == originalteam);
            var newTeam = teams.FirstOrDefault(p => p.OriginalTeamName == newteam);

            teamToConvey.TeamPickOwedToName = newteam;
            teamToConvey.PickTradeDetails = picktradedetails;

            if (teamToConvey.PickNumber > upperprotectionthreshold && teamToConvey.PickNumber <= lowerprotectionthreshold)
            
            {
                SwapPick(teamToConvey, newTeam);
            }

            else
            {
                ProtectPick(teamToConvey);
            }

        }

        //OKC gets 3 best of OKC/HOU/MIA, HOU gets worst & can swap with BKN
        private static void DetermineProtectionOKCSwaps(List<NBATeam> teams)
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
                    SwapPick(team, okc);
                    team.PickTradeDetails = "OKC gets 2 best of OKC/HOU/MIA, HOU gets worst & can swap with BKN";
                }
            }

            else
            {
                foreach (var team in teams.Where(p => p.OriginalTeamName == "Boston" || p.OriginalTeamName == "Oklahoma City" || p.OriginalTeamName == "Miami" || p.OriginalTeamName == "Houston"))
                {
                    SwapPick(team, okc);
                    team.PickTradeDetails = "OKC gets 2 best of OKC/HOU/MIA, HOU gets worst & can swap with BKN";


                }
                SwapPick(lowestPickSwapTeam, houston);
            }


        }

        private static void SwapPick(NBATeam fromTeam, NBATeam toTeam)
        {
            if (fromTeam == toTeam)
            {
                return;
            }


            fromTeam.TeamPickOwedToName = toTeam.OriginalTeamName;
            fromTeam.NewTeamName = toTeam.OriginalTeamName;
            fromTeam.TeamName = string.Format("{0} to {1}", fromTeam.OriginalTeamName, toTeam.OriginalTeamName);
            fromTeam.PickSwapType = PickSwapType.Swapped;
        }

        private static void ProtectPick(NBATeam fromTeam)
        {
            fromTeam.NewTeamName = null;
            fromTeam.PickSwapType = PickSwapType.Protected;
        }

    
        public static List<NBATeam> OutGoingPicks(NBATeam team)
        {
            return LotterySim.Business.GetNBATeams.GetLotteryTeams().Where(p => p.OriginalTeamName == team.OriginalTeamName && p.PickSwapType == PickSwapType.Swapped).OrderBy(p => p.PickNumber).ToList();
        }
        public static List<NBATeam> IncomingPicks(NBATeam team)
        {
            return LotterySim.Business.GetNBATeams.GetLotteryTeams().Where(p => (p.OriginalTeamName == team.OriginalTeamName && p.NewTeamName == null) || p.NewTeamName == team.OriginalTeamName).OrderBy(p => p.PickNumber).ToList();
        }
        public static List<NBATeam> NonConveyedPicks(NBATeam team)
        {
            return LotterySim.Business.GetNBATeams.GetLotteryTeams().Where(p => p.TeamPickOwedToName == team.OriginalTeamName && p.PickSwapType == PickSwapType.Protected).ToList();
        }


    }
}
