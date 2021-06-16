using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    class PickProtections
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
        }


        private static void DetermineProtection(List<Team> teams, int protectionThreshold, string originalTeam, string newTeam)
        {
           
            var teamToConvey = teams.FirstOrDefault(p => p.OriginalTeamName == originalTeam);

            if (teamToConvey.PickNumber > protectionThreshold)

            {
                teamToConvey.TeamName = string.Format("{0} to {1}", originalTeam, newTeam);      
                teamToConvey.NewTeamName = newTeam;
            }

           
            else
            {
               teamToConvey.TeamName = originalTeam;
                teamToConvey.NewTeamName = null;
            }
           
        }
        
        


    }
}
