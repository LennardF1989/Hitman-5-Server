using HM5.Server.Interfaces;
using HM5.Server.Models;
using HM5.Server.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Sniper
{
    [Route("sniper")]
    public partial class SniperController : BaseController
    {
        private readonly List<SniperScoreEntry> _mockedGetScoresResponse = new()
        {
            new SniperScoreEntry
            {
                UserId = "76561197989140534",
                Rank = 1,
                Score = 1989
            },
            new SniperScoreEntry
            {
                UserId = "76561198025604927",
                Rank = 2,
                Score = 1989
            },
            new SniperScoreEntry
            {
                UserId = "76561198215015615",
                Rank = 3,
                Score = 1989
            },
            new SniperScoreEntry
            {
                UserId = "76561198161220058",
                Rank = 4,
                Score = 1989
            }
        };

        public const string SchemaNamespace = "Sniper";

        private readonly IMetadataService _metadataService;

        public SniperController(
            ISimpleLogger simpleLogger,
            IMetadataServiceForSniper metadataService
        )
            : base(simpleLogger)
        {
            _metadataService = metadataService;
        }

        public static List<EdmFunctionImport> GetEdmFunctionImports()
        {
            return new List<EdmFunctionImport>
            {
                _sendTemplatedMessage,
                _setMessageReadStatus,
                _getMessages,
                _getNewMessageCount,
                _updateUserProfile,
                _putScore,
                _getScores,
                _getPerformanceIndexAll
            };
        }

        public static List<Type> GetEdmEntityTypes()
        {
            return new List<Type>
            {
                typeof(SniperScoreEntry),
                typeof(SniperMessage)
            };
        }
    }
}