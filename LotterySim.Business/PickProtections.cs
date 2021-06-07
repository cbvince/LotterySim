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
            }
           
        }
        
        


    }
}
