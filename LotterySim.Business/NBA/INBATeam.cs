﻿using LotterySim.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySim.Business.NBA
{
	public interface INBATeam : ITeam
	{
		public class Rootobject
		{
			public _Internal _internal { get; set; }
			public League league { get; set; }
		}

		public class _Internal
		{
			public string pubDateTime { get; set; }
			public string igorPath { get; set; }
			public string xslt { get; set; }
			public string xsltForceRecompile { get; set; }
			public string xsltInCache { get; set; }
			public string xsltCompileTimeMillis { get; set; }
			public string xsltTransformTimeMillis { get; set; }
			public string consolidatedDomKey { get; set; }
			public string endToEndTimeMillis { get; set; }
		}

		public class League
		{
			public Standard standard { get; set; }
			public Africa africa { get; set; }
			public Sacramento sacramento { get; set; }
			public Vegas vegas { get; set; }
			public Utah utah { get; set; }
		}

		public class Standard
		{
			public int seasonYear { get; set; }
			public int seasonStageId { get; set; }
			public Team[] teams { get; set; }
		}

		public class Team
		{
			public string teamId { get; set; }
			public string win { get; set; }
			public string loss { get; set; }
			public string winPct { get; set; }
			public string winPctV2 { get; set; }
			public string lossPct { get; set; }
			public string lossPctV2 { get; set; }
			public string gamesBehind { get; set; }
			public string divGamesBehind { get; set; }
			public string clinchedPlayoffsCode { get; set; }
			public string clinchedPlayoffsCodeV2 { get; set; }
			public string confRank { get; set; }
			public string confWin { get; set; }
			public string confLoss { get; set; }
			public string divWin { get; set; }
			public string divLoss { get; set; }
			public string homeWin { get; set; }
			public string homeLoss { get; set; }
			public string awayWin { get; set; }
			public string awayLoss { get; set; }
			public string lastTenWin { get; set; }
			public string lastTenLoss { get; set; }
			public string streak { get; set; }
			public string divRank { get; set; }
			public bool isWinStreak { get; set; }
			public Teamsitesonly teamSitesOnly { get; set; }
			public string tieBreakerPts { get; set; }
			public Sortkey sortKey { get; set; }
		}

		public class Teamsitesonly
		{
			public string teamKey { get; set; }
			public string teamName { get; set; }
			public string teamCode { get; set; }
			public string teamNickname { get; set; }
			public string teamTricode { get; set; }
			public string clinchedConference { get; set; }
			public string clinchedDivision { get; set; }
			public string clinchedPlayoffs { get; set; }
			public string streakText { get; set; }
		}

		public class Sortkey
		{
			public int defaultOrder { get; set; }
			public int nickname { get; set; }
			public int win { get; set; }
			public int loss { get; set; }
			public int winPct { get; set; }
			public int gamesBehind { get; set; }
			public int confWinLoss { get; set; }
			public int divWinLoss { get; set; }
			public int homeWinLoss { get; set; }
			public int awayWinLoss { get; set; }
			public int lastTenWinLoss { get; set; }
			public int streak { get; set; }
		}

		public class Africa
		{
			public int seasonYear { get; set; }
			public int seasonStageId { get; set; }
			public object[] teams { get; set; }
		}

		public class Sacramento
		{
			public int seasonYear { get; set; }
			public int seasonStageId { get; set; }
			public Team1[] teams { get; set; }
		}

		public class Team1
		{
			public string teamId { get; set; }
			public string win { get; set; }
			public string loss { get; set; }
			public string winPct { get; set; }
			public string winPctV2 { get; set; }
			public string lossPct { get; set; }
			public string lossPctV2 { get; set; }
			public string gamesBehind { get; set; }
			public string divGamesBehind { get; set; }
			public string clinchedPlayoffsCode { get; set; }
			public string clinchedPlayoffsCodeV2 { get; set; }
			public string confRank { get; set; }
			public string confWin { get; set; }
			public string confLoss { get; set; }
			public string divWin { get; set; }
			public string divLoss { get; set; }
			public string homeWin { get; set; }
			public string homeLoss { get; set; }
			public string awayWin { get; set; }
			public string awayLoss { get; set; }
			public string lastTenWin { get; set; }
			public string lastTenLoss { get; set; }
			public string streak { get; set; }
			public string divRank { get; set; }
			public bool isWinStreak { get; set; }
			public Teamsitesonly1 teamSitesOnly { get; set; }
			public string tieBreakerPts { get; set; }
			public Sortkey1 sortKey { get; set; }
		}

		public class Teamsitesonly1
		{
			public string teamKey { get; set; }
			public string teamName { get; set; }
			public string teamCode { get; set; }
			public string teamNickname { get; set; }
			public string teamTricode { get; set; }
			public string clinchedConference { get; set; }
			public string clinchedDivision { get; set; }
			public string clinchedPlayoffs { get; set; }
			public string streakText { get; set; }
		}

		public class Sortkey1
		{
			public int defaultOrder { get; set; }
			public int nickname { get; set; }
			public int win { get; set; }
			public int loss { get; set; }
			public int winPct { get; set; }
			public int gamesBehind { get; set; }
			public int confWinLoss { get; set; }
			public int divWinLoss { get; set; }
			public int homeWinLoss { get; set; }
			public int awayWinLoss { get; set; }
			public int lastTenWinLoss { get; set; }
			public int streak { get; set; }
		}

		public class Vegas
		{
			public int seasonYear { get; set; }
			public int seasonStageId { get; set; }
			public Team2[] teams { get; set; }
		}

		public class Team2
		{
			public string teamId { get; set; }
			public string win { get; set; }
			public string loss { get; set; }
			public string winPct { get; set; }
			public string winPctV2 { get; set; }
			public string lossPct { get; set; }
			public string lossPctV2 { get; set; }
			public string gamesBehind { get; set; }
			public string divGamesBehind { get; set; }
			public string clinchedPlayoffsCode { get; set; }
			public string clinchedPlayoffsCodeV2 { get; set; }
			public string confRank { get; set; }
			public string confWin { get; set; }
			public string confLoss { get; set; }
			public string divWin { get; set; }
			public string divLoss { get; set; }
			public string homeWin { get; set; }
			public string homeLoss { get; set; }
			public string awayWin { get; set; }
			public string awayLoss { get; set; }
			public string lastTenWin { get; set; }
			public string lastTenLoss { get; set; }
			public string streak { get; set; }
			public string divRank { get; set; }
			public bool isWinStreak { get; set; }
			public Teamsitesonly2 teamSitesOnly { get; set; }
			public string tieBreakerPts { get; set; }
			public Sortkey2 sortKey { get; set; }
		}

		public class Teamsitesonly2
		{
			public string teamKey { get; set; }
			public string teamName { get; set; }
			public string teamCode { get; set; }
			public string teamNickname { get; set; }
			public string teamTricode { get; set; }
			public string clinchedConference { get; set; }
			public string clinchedDivision { get; set; }
			public string clinchedPlayoffs { get; set; }
			public string streakText { get; set; }
		}

		public class Sortkey2
		{
			public int defaultOrder { get; set; }
			public int nickname { get; set; }
			public int win { get; set; }
			public int loss { get; set; }
			public int winPct { get; set; }
			public int gamesBehind { get; set; }
			public int confWinLoss { get; set; }
			public int divWinLoss { get; set; }
			public int homeWinLoss { get; set; }
			public int awayWinLoss { get; set; }
			public int lastTenWinLoss { get; set; }
			public int streak { get; set; }
		}

		public class Utah
		{
			public int seasonYear { get; set; }
			public int seasonStageId { get; set; }
			public Team3[] teams { get; set; }
		}

		public class Team3
		{
			public string teamId { get; set; }
			public string win { get; set; }
			public string loss { get; set; }
			public string winPct { get; set; }
			public string winPctV2 { get; set; }
			public string lossPct { get; set; }
			public string lossPctV2 { get; set; }
			public string gamesBehind { get; set; }
			public string divGamesBehind { get; set; }
			public string clinchedPlayoffsCode { get; set; }
			public string clinchedPlayoffsCodeV2 { get; set; }
			public string confRank { get; set; }
			public string confWin { get; set; }
			public string confLoss { get; set; }
			public string divWin { get; set; }
			public string divLoss { get; set; }
			public string homeWin { get; set; }
			public string homeLoss { get; set; }
			public string awayWin { get; set; }
			public string awayLoss { get; set; }
			public string lastTenWin { get; set; }
			public string lastTenLoss { get; set; }
			public string streak { get; set; }
			public string divRank { get; set; }
			public bool isWinStreak { get; set; }
			public Teamsitesonly3 teamSitesOnly { get; set; }
			public string tieBreakerPts { get; set; }
			public Sortkey3 sortKey { get; set; }
		}

		public class Teamsitesonly3
		{
			public string teamKey { get; set; }
			public string teamName { get; set; }
			public string teamCode { get; set; }
			public string teamNickname { get; set; }
			public string teamTricode { get; set; }
			public string clinchedConference { get; set; }
			public string clinchedDivision { get; set; }
			public string clinchedPlayoffs { get; set; }
			public string streakText { get; set; }
		}

		public class Sortkey3
		{
			public int defaultOrder { get; set; }
			public int nickname { get; set; }
			public int win { get; set; }
			public int loss { get; set; }
			public int winPct { get; set; }
			public int gamesBehind { get; set; }
			public int confWinLoss { get; set; }
			public int divWinLoss { get; set; }
			public int homeWinLoss { get; set; }
			public int awayWinLoss { get; set; }
			public int lastTenWinLoss { get; set; }
			public int streak { get; set; }
		}

	}
}
