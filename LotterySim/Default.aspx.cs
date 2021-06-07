using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LotterySim.Business;

namespace LotterySim
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            teamStandingsGridView.DataSource = GetTeams.GetLotteryTeams();
            teamStandingsGridView.DataBind();
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
           

            var lotteryTeams = GetTeams.GetLotteryTeams();
            Lottery.RunLottery(lotteryTeams);
            

            lotteryResultsGridView.DataSource = lotteryTeams.OrderBy(p => p.LotteryNumber);
            lotteryResultsGridView.DataBind();
            lotteryResultsLabel.Visible = true;



        }







    }
}
