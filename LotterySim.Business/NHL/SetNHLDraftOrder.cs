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
                nhlDraftPicksWithTeams.Add(new NHLDraftPick { PickNumber = i++, OriginalTeam = team, Team = team });
                team.InitialLotteryRank = i++;
            }

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
    }
}
