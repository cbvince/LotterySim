using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    class SetNHLDraftOrder
    {

     


        private static List<NHLDraftPick> NHLDefaultDraftPicks()
        {
            var nhlDraftPicksWithTeams = new List<NHLDraftPick>();
        
            var i = 1;
          

            foreach (var team in GetNHLTeams.GetOrderedTeams())
            {
                nhlDraftPicksWithTeams.Add(new NHLDraftPick { PickNumber = i++, OriginalTeam = team, Team = team });
            }

            return nhlDraftPicksWithTeams;

        }
    }
}
