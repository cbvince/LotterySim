using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace LotterySim.Business.NHL
{
    public static class SetNHLDraftOrder
    {

     


        private static List<NHLDraftPick> NHLDefaultDraftPicks()
        {
            var nhlDraftPicksWithTeams = new List<NHLDraftPick>();
            var nhlOrderedTeams = GetNHLTeams.GetOrderedTeams();


            var i = 1;
          
            foreach (var team in nhlOrderedTeams)
            {
                nhlDraftPicksWithTeams.Add(new NHLDraftPick { PickNumber = i, OriginalTeam = team, Team = team, LotteryOdds = SetNHLPickOdds(i++) });
                team.InitialLotteryRank = i;
            }

            NHLPickSwap.NHLSeasonPickSwaps(nhlDraftPicksWithTeams);

            return nhlDraftPicksWithTeams;

        }

        public static List<NHLDraftPick> NHLDefaultDraftPicksFromCache()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains("nhlDraftPicks"))
            {
                var nhlDraftPicks = cache.GetCacheItem("nhlDraftPicks").Value;
                return (List<NHLDraftPick>)nhlDraftPicks;

            }

            else
            {
                cache.Add("nhlDraftPicks", NHLDefaultDraftPicks(), DateTimeOffset.Now.AddMinutes(1440));
                return NHLDefaultDraftPicksFromCache();
            }

        }

        
        private static string SetNHLPickOdds(int pickNumber)
        {
           
            return pickNumber switch
            {
                1 => "16.6%",
                2 => "12.1%",
                3 => "10.3%",
                4 => "10.3%",
                5 => "8.5%",
                6 => "7.6%",
                7 => "6.7%",
                8 => "5.8%",
                9 => "5.4%",
                10 => "4.5%",
                11 => "3.1%",
                12 => "2.7%",
                13 => "2.2%",
                14 => "1.8%",
                15 => "1.4%",
                16 => "1.0%",
                _ => "--",
            };
            

            





        }
    }
}
