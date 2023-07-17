using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers.Hitman
{
    /**
     * Invoke:
     * - ZMessageManager::GetOnlineMessages @ 008D5730
     * - ZMessageManager::GetNewOnlineMessages @ 005EE400
     * Callback:
     * - ZMessageManager::OnGetMessagesComplete @ 9D8CF0
     * - ZMessageManager::OnGetNewMessagesComplete @ 00961A30
     * ReturnType: ZOFeed
     */
    public partial class HitmanController
    {
        [EdmFunctionImport(
            "GetMessages",
            HttpMethods.GET,
            $"Collection({SchemaNamespace}.Message)"
        )]
        public class GetMessagesRequest : IEdmFunctionImport
        {
            [NormalizedString]
            [SFunctionParameter("userId", EdmTypes.String)]
            public string UserId { get; set; }

            [SFunctionParameter("tabgroup", EdmTypes.Int32)]
            public int TabGroup { get; set; }

            [NormalizedString]
            [SFunctionParameter("languageId", EdmTypes.String)]
            public string LanguageId { get; set; }

            [SFunctionParameter("skip", EdmTypes.Int32)]
            public int Skip { get; set; }

            [SFunctionParameter("limit", EdmTypes.Int32)]
            public int Limit { get; set; }
        }

        [HttpGet]
        [Route("GetMessages")]
        public IActionResult GetMessages([FromQuery] GetMessagesRequest request)
        {
            var templateDataKeyValues = new Dictionary<string, string>
            {
                ["{ContractId}"] = _mockedContractWithoutCompetition.Id.ToString(),
                ["{ContractName}"] = _mockedContractWithoutCompetition.DisplayId,
                ["{userid}"] = "userid: LennardF1989",
                ["{CompetitionCreatorName}"] = "CompetitionCreatorName: LennardF1989",
                ["{WinnerName}"] = "WinnerName: LennardF1989",
                ["{WinnerScore}"] = "WinnerScore: 101",
                ["{PlayerScore}"] = "PlayerScore: 101",
                ["{NumberOfParticipants}"] = "NumberOfParticipants: 47",
                ["{TrophiesEarned}"] = "TrophiesEarned: 47"
            };

            var templateData = string.Join(
                "|||",
                templateDataKeyValues.Select(x => $"{x.Key}|||{x.Value}")
            );

            var messages = Enum
                .GetNames<EMessageTextTemplate>()
                .OrderBy(x => x)
                .Skip(request.Skip)
                .Take(request.Limit)
                .Select(x => (EMessageTextTemplate)Enum.Parse(typeof(EMessageTextTemplate), x))
                .Select((textTemplateId, i) =>
                {
                    var actualTemplateData = textTemplateId switch
                    {
                        EMessageTextTemplate.None =>
                            "Diana, she..." +
                            "|||" +
                            "Always talks about him.<BR><BR>Way back when they first worked together.",
                        EMessageTextTemplate.Silverballer => MasterCraftedSilverballer(
                            "Kill Diana with a Silverballer", 
                            "Or maybe don't?",
                            _mockedContractWithoutCompetition.Id
                        ),
                        _ => templateData
                    };

                    return new Message
                    {
                        Id = 5000 + i,
                        FromId = "LennardF1989",
                        IsRead = true,
                        Category = EMessageCategory.Medal,
                        TextTemplateId = textTemplateId,
                        TemplateData = actualTemplateData,
                        TimestampUTC = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };
                })
                .ToList();

            return JsonFeedResponse(messages);
        }

        private string MasterCraftedSilverballer(string title, string body, string contractId = null)
        {
            return contractId == null 
                ? $"Silverballer|||{title}||{{baller}}|||{{baller}}||||{body}" 
                : $"{{ContractId}}|||{contractId}|||Silverballer|||{title}||{{baller}}|||{{baller}}||||{body}";
        }
    }
}
