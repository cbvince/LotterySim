using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NHL
{
    public class RunNHLLottery
    {

        private static int GetNHLWinningPickTeamRank()
        {
            var random = new Random();
            var lotteryNumber = random.Next(1, 1001);

            return lotteryNumber switch
            {

                > 0 and < 167 => 1,
                >= 167 and < 390 => 2,
                >= 390 and < 493 => 3,
                >= 493 and < 579 => 4,
                >= 579 and < 655 => 5,
                >= 655 and < 722 => 6,
                >= 722 and < 780 => 7,
                >= 780 and < 834 => 8,
                >= 834 and < 879 => 9,
                >= 879 and < 910 => 10,
                >= 910 and < 937 => 11,
                >= 937 and < 959 => 12,
                >= 959 and < 977 => 13,
                >= 977 and < 991 => 14,
                >= 991 and < 1001 => 15,
                _ => throw new Exception("Unable to Determine Lottery Team"),
            };
        }


        private static void RunLotteryRound(List<NHLDraftPick> picks, int pickNumbertoDetermine)
        {
         
            var winningPickNumber = GetNHLWinningPickTeamRank();
            var winningPick = picks.Where(p => p.PickNumber == winningPickNumber).FirstOrDefault();
            
            

            if (winningPickNumber > pickNumbertoDetermine )
            {
                foreach (var pick in picks.Where(p => p.PickNumber <= winningPickNumber && p.PickNumber >= pickNumbertoDetermine))
                {
                    pick.PickNumber++;
                    pick.LotteryMovement--;
                }

                winningPick.LotteryMovement = winningPick.PickNumber - pickNumbertoDetermine;
                winningPick.PickNumber = pickNumbertoDetermine;
            }

        }

        public static List<NHLDraftPick> RunLottery()
        {


            var picks = SetNHLDraftOrder.NHLDefaultDraftPicksFromCache();
          
            List<NHLDraftPick> lotteryPicks = picks.ConvertAll(pick => pick.Clone());

            RunLotteryRound(lotteryPicks, 1);
            RunLotteryRound(lotteryPicks, 2);
            // Redo Pick Swaps as draft order will have changed

 

            return lotteryPicks;
        }




    }
}
