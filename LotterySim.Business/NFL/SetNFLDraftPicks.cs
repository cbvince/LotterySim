using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using LotterySim.Business.Common;

namespace LotterySim.Business.NFL
{
    public static class SetNFLDraftPicks
    {

        private static List<NFLTeam.NFLDraftPick> GenerateDraftPicks()
        {

            var startingPick = 1;
            var entries = GetNFLTeams.GetOrderedEntriesFromCache();
            var draftPicks = new List<NFLTeam.NFLDraftPick>();

            foreach (var entry in entries)
            {
                draftPicks.Add(new NFLTeam.NFLDraftPick { DraftRound = 1, OriginalTeam = entry, Team = entry, PickNumber = startingPick++ });
                SetRemainingRoundDraftOrder(draftPicks, entry);

            }

            NFLPickSwap.NFLSeasonPickSwaps(draftPicks);
            return draftPicks;

        }

        private static List<NFLTeam.NFLDraftPick> GenerateDraftPicksFromCache()
        {

          
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains("nflDraftPicks"))
            {
                var roundPicks = cache.GetCacheItem("nflDraftPicks").Value;
                return (List<NFLTeam.NFLDraftPick>)roundPicks;

            }

            else
            {
                cache.Add("nflDraftPicks", GenerateDraftPicks(), DateTimeOffset.Now.AddMinutes(1440));
                return GenerateDraftPicksFromCache();
            }

        }

        private static void SetRemainingRoundDraftOrder(List<NFLTeam.NFLDraftPick> picks, NFLTeam.Entry entry)
        {

            var firstRoundPickNumber = picks.Where(p => p.DraftRound == 1 && p.Team == entry).FirstOrDefault().PickNumber;
            var i = 2;
            var currentPickNumber = firstRoundPickNumber + 32;

            while (i < 8)
            {
                picks.Add(new NFLTeam.NFLDraftPick() { DraftRound = i++, PickNumber = currentPickNumber, OriginalTeam = entry, Team = entry });
                currentPickNumber += 32;

            }




        }

        public static List<NFLTeam.NFLDraftPick> GetNFlDraftPicksByRound(int roundNumber)
        {

            var roundPicks = GenerateDraftPicksFromCache().Where(p => p.DraftRound == roundNumber).ToList();

            return roundPicks;

        }

        public static List<NFLTeam.NFLDraftPick> GetNFlDraftPicksByTeam(int teamID)
        {

            var picks = GenerateDraftPicksFromCache().Where(p => int.Parse(p.Team.team.id) == teamID).ToList();

            return picks;

        }

    }
}
