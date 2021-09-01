using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NFL
{
    public class NFLTeam
    {

        public class Rootobject
        {
            public string uid { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public Child[] children { get; set; }
            public Link2[] links { get; set; }
            public Season[] seasons { get; set; }
        }

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
            public List<NFLDraftPick> DraftPicks { get { return _draftPicks; }}

            private readonly List<NFLDraftPick> _draftPicks = new List<NFLDraftPick>();

       
        }

        public class NFLDraftPick
        {
            public int DraftRound { get; set; }
            public int PickNumber { get; set; }


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

    }
}






