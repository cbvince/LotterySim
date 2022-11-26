using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.Common
{
	public static class DraftPickHelper
	{
		public static void CheckPickProtections(List<PickProtection> pickProtections, List<IDraftPick> draftPicks)
		{
			foreach (PickProtection pickProtection in pickProtections)
			{

				IDraftPick pickToSwap = draftPicks.Where(p => p.Team.TeamName == pickProtection.FromTeam).FirstOrDefault();

				if (pickToSwap != null)
				{
					if (pickToSwap.PickNumber > pickProtection.LowerPickProtectionThreshold && pickToSwap.PickNumber < pickProtection.UpperPickProtectionThreshold)
					{
						pickToSwap.TeamPickOwedTo = draftPicks.Select(p => p.Team).Where(p => p.TeamName == pickProtection.ToTeam).FirstOrDefault();
						pickToSwap.PickSwapType = PickSwapType.Swapped;
					}
					else
					{
						pickToSwap.PickSwapType = PickSwapType.Protected;
					}
				}
			}
		}

		public static List<IDraftPick> GenerateDraftPicks<T>(List<ITeam> teams, int totalRounds)
			where T : IDraftPick, new()
		{
			int roundsGenerated = 0;
			List<IDraftPick> picks = new List<IDraftPick>();

			while (roundsGenerated < totalRounds)
			{
				int i = 1;

				foreach (ITeam team in teams)
				{
					T draftPick = new T();
					draftPick.PickNumber = i++;
					draftPick.Team = team;
					picks.Add(draftPick);
				}
				roundsGenerated++;
			}
			return picks;
		}
	}
}
