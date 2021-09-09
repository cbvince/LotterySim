using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    class NFLPickSwap
    {

    

        private static void SwapNFLPicks(List<NFLTeam.NFLDraftPick> picks, string fromTeamName, string toTeamName, int roundNumber)
        {
            
            var entries = GetNFLTeams.GetEntriesFromStandings();
            var fromEntry = entries.Where(p => p.team.displayName == fromTeamName).FirstOrDefault();
            var toEntry = entries.Where(p => p.team.displayName == toTeamName).FirstOrDefault();
        
            var pickToUpdate = picks.Where(p => p.DraftRound == roundNumber && p.Team.team.displayName == fromTeamName).FirstOrDefault();

            pickToUpdate.Team = toEntry;
            pickToUpdate.OriginalTeam = fromEntry;
            pickToUpdate.PickSwapType = PickSwapType.Swapped;
        }

        public static void NFLSeasonPickSwaps(List<NFLTeam.NFLDraftPick> picks)
        {
           
            SwapNFLPicks(picks, "Chicago Bears", "New York Giants", 1);
            SwapNFLPicks(picks, "Indianapolis Colts", "Philadelphia Eagles", 1);
            SwapNFLPicks(picks, "Miami Dolphins", "Philadelphia Eagles", 1);
            SwapNFLPicks(picks, "Seattle Seahawks", "New York Jets", 1);
            SwapNFLPicks(picks, "San Francisco 49ers", "Miami Dolphins", 1);
            SwapNFLPicks(picks, "Los Angeles Rams", "Detroit Lions", 1);

            SwapNFLPicks(picks, "Carolina Panthers", "New York Jets", 2);
            SwapNFLPicks(picks, "Tennessee Titans", "Atlanta Falcons", 2);

            SwapNFLPicks(picks, "Miami Dolphins", "New York Giants", 3);
            SwapNFLPicks(picks, "Carolina Panthers", "New York Jets", 3);
            SwapNFLPicks(picks, "San Francisco 49ers", "Miami Dolphins", 3);
            SwapNFLPicks(picks, "New Orleans Saints", "Houston Texans", 3);

            SwapNFLPicks(picks, "Houston Texans", "Carolina Panthers", 4);
            SwapNFLPicks(picks, "Detroit Lions", "Cleveland Browns", 4);
            SwapNFLPicks(picks, "New York Jets", "Seattle Seahawks", 4);
            SwapNFLPicks(picks, "New York Giants", "Baltimore Ravens", 4);
            SwapNFLPicks(picks, "Carolina Panthers", "New York Jets", 4);
            SwapNFLPicks(picks, "Chicago Bears", "New York Giants", 4);
            SwapNFLPicks(picks, "Pittsburgh Steelers", "Miami Dolphins", 4);
            SwapNFLPicks(picks, "Arizona Cardinals", "Baltimore Ravens", 4);
            SwapNFLPicks(picks, "Minnesota Vikings", "New York Jets", 4);
            SwapNFLPicks(picks, "Los Angeles Rams", "Houston Texans", 4);

            SwapNFLPicks(picks, "Pittsburgh Steelers", "New York Jets", 5);
            SwapNFLPicks(picks, "New England Patriots", "Las Vegas Raiders", 5);
            SwapNFLPicks(picks, "Kansas City Chiefs", "Baltimore Ravens", 5);
            SwapNFLPicks(picks, "Houston Texans", "Chicago Bears", 5);
            SwapNFLPicks(picks, "Washington", "Philadelphia Eagles", 5);
            SwapNFLPicks(picks, "Detroit Lions", "Denver Broncos", 5);
            SwapNFLPicks(picks, "Baltimore Ravens", "New York Giants", 5);



            SwapNFLPicks(picks, "Tampa Bay Buccaneers", "New York Jets", 6);
            SwapNFLPicks(picks, "San Francisco 49ers", "New York Jets", 6);
            SwapNFLPicks(picks, "Baltimore Ravens", "Kansas City Chiefs", 6);
            SwapNFLPicks(picks, "Kansas City Chiefs", "Minnesota Vikings", 6);
            SwapNFLPicks(picks, "Green Bay Packers", "Houston Texans", 6);
            SwapNFLPicks(picks, "Pittsburgh Steelers", "Jacksonville Jaguars", 6);
            SwapNFLPicks(picks, "Las Vegas Raiders", "Carolina Panthers", 6);
            SwapNFLPicks(picks, "Kansas City Chiefs", "Minnesota Vikings", 6);
            SwapNFLPicks(picks, "Miami Dolphins", "Baltimore Ravens", 6);
            SwapNFLPicks(picks, "New York Jets", "Houston Texans", 6);
            SwapNFLPicks(picks, "Carolina Panthers", "Buffalo Bills", 6);
            SwapNFLPicks(picks, "Seattle Seahawks", "Jacksonville Jaguars", 6);
            SwapNFLPicks(picks, "Indianapolis Colts", "Philadelphia Eagles", 6);
            SwapNFLPicks(picks, "Denver Broncos", "San Francisco 49ers", 6);
            SwapNFLPicks(picks, "New York Jets", "Minnesota Vikings", 6);


            SwapNFLPicks(picks, "Miami Dolphins", "Los Angeles Rams", 7);
            SwapNFLPicks(picks, "New York Jets", "Pittsburgh Steelers", 7);
            SwapNFLPicks(picks, "New England Patriots", "Miami Dolphins", 7);
            SwapNFLPicks(picks, "Tennessee Titans", "Miami Dolphins", 7);
            SwapNFLPicks(picks, "Las Vegas Raiders", "New England Patriots", 7);
            SwapNFLPicks(picks, "Houston Texans", "New England Patriots", 7);
            SwapNFLPicks(picks, "Minnesota Vikings", "Kansas City Chiefs", 7);
            SwapNFLPicks(picks, "Chicago Bears", "Houston Texans", 7);
            SwapNFLPicks(picks, "Houston Texans", "Green Bay Packers", 7);
            SwapNFLPicks(picks, "Seattle Seahawks", "Houston Texans", 7);
            SwapNFLPicks(picks, "Carolina Panthers", "Las Vegas Raiders", 7);
            SwapNFLPicks(picks, "New England Patriots", "Baltimore Ravens", 7);
            SwapNFLPicks(picks, "Baltimore Ravens", "Miami Dolphins", 7);
            SwapNFLPicks(picks, "New England Patriots", "Kansas City Chiefs", 7);
            SwapNFLPicks(picks, "Philadelphia Eagles", "Indianapolis Colts", 7);
            SwapNFLPicks(picks, "Detroit Lions", "Denver Broncos", 7);




















        }


    }
}
