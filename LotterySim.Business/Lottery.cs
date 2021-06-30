using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business
{
    public class Lottery
    {


        public static void RunLottery(List<Team> teams)
        {

            for (int i = 0; i < 5; i++)
            {
                while (teams.FirstOrDefault(p => p.LotteryNumber == i) == null)
                {

                    RunLotteryRound(teams, DetermineWinningTeam(), i);
                }
            }
            FillRemainingLotteryOrder(teams);
            SetPickNumberFromLotteryNumber(teams);
            PickProtections.PickProtection(teams);
            DetermineLotteryMovement(teams);
        }

        private static void RunLotteryRound(List<Team> teams, int pickValue, int pickNumber)
        {
            var winner = teams.FirstOrDefault(p => p.TeamRank == pickValue && p.Assigned == false);

            if (winner != null)
            {
                winner.LotteryNumber = pickNumber;
                winner.Assigned = true;
            }


        }

        private static int DetermineWinningTeam()
        {
            Random random = new Random();
            int lotteryNumber = random.Next(1, 1001);
            if (lotteryNumber <= 140) return 1;                         //140
            if (lotteryNumber > 140 && lotteryNumber <= 280) return 2;   //140
            if (lotteryNumber > 280 && lotteryNumber <= 420) return 3;  //140
            if (lotteryNumber > 420 && lotteryNumber <= 545) return 4;  //125
            if (lotteryNumber > 545 && lotteryNumber <= 650) return 5;  //105
            if (lotteryNumber > 650 && lotteryNumber <= 740) return 6;  //90
            if (lotteryNumber > 740 && lotteryNumber <= 815) return 7;  //75
            if (lotteryNumber > 815 && lotteryNumber <= 875) return 8;  //60
            if (lotteryNumber > 875 && lotteryNumber <= 920) return 9;  //45
            if (lotteryNumber > 920 && lotteryNumber <= 950) return 10; //30
            if (lotteryNumber > 950 && lotteryNumber <= 970) return 11; //20
            if (lotteryNumber > 970 && lotteryNumber <= 985) return 12; //15
            if (lotteryNumber > 985 && lotteryNumber <= 995) return 13; //10
            if (lotteryNumber > 995) return 14;                         //5


            return 15;

        }

        private static void FillRemainingLotteryOrder(List<Team> teams)
        {
            var lotteryNumber = 5;
            foreach (var team in teams.Where(p => p.Assigned == false).OrderBy(p => p.TeamRank))
            {
               
                team.LotteryNumber = lotteryNumber++;
                team.Assigned = true;
            }
        }

        private static void DetermineLotteryMovement(List<Team> teams)
        {
            foreach (var team in teams)
            {
                var movementAmount = team.TeamRank - team.LotteryNumber;
                
                if (movementAmount > 0)
                {
                    team.LotteryMovement = string.Format("+{0}", Math.Abs(movementAmount));
                }

                if (movementAmount < 0)
                {
                    team.LotteryMovement = string.Format("-{0}", Math.Abs(movementAmount));
                }

                if (movementAmount == 0)
                {
                    team.LotteryMovement = "";
                }

            }
        }

        public static void SetPickNumberFromLotteryNumber(List<Team> teams)
        {
            foreach (var team in teams)
            {
                team.PickNumber = team.LotteryNumber;
            }
        }


    }


}

