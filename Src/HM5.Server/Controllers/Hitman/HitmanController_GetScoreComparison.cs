﻿using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke: ZLeaderboard::GetScoreComparison @ 00458D00
     * Callback: ZLeaderboard::GetScoreComparisonCallback @ 00624360
     * ReturnType: ZOEntry
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetScoreComparison",
            HttpMethods.GET,
            $"{SchemaNamespace}.ScoreComparison")
        ]
        public class GetScoreComparisonRequest : IEdmFunctionImport
        {
            [SFunctionParameter("leaderboardtype", EdmTypes.Int32)]
            public int LeaderboardType { get; set; }

            [NormalizedString]
            [SFunctionParameter("leaderboardid", EdmTypes.String)]
            public string LeaderboardId { get; set; }

            [NormalizedString]
            [SFunctionParameter("userid", EdmTypes.String)]
            public string UserId { get; set; }
        }

        [HttpGet]
        [Route("GetScoreComparison")]
        public IActionResult GetScoreComparison([FromQuery] GetScoreComparisonRequest request)
        {
            return JsonEntryResponse(_hitmanServer.GetScoreComparison(request));
        }
    }
}
