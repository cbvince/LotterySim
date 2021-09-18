using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
     public class NHLDraftPick
    {
        public int DraftRound { get; set; }
        public int PickNumber { get; set; }

        public NHLTeam.Teamrecord  OriginalTeam { get; set; }

        public NHLTeam.Teamrecord Team { get; set; }

        public PickSwapType PickSwapType { get; set; }
    }
}
