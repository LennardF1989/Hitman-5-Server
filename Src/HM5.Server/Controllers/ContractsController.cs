using HM5.Server.Controllers.Hitman;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers
{
    [Route("contracts")]
    public class ContractsController : Controller
    {
        private readonly IContractsService _contractsService;

        public ContractsController(IContractsService contractsService)
        {
            _contractsService = contractsService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Contracts.cshtml");
        }

        [HttpGet("all/{page}/{filter=}")]
        public IActionResult GetContracts(int page, string filter = null)
        {
            const int pageSize = 20;

            var contracts = _contractsService.GetContracts(new HitmanController.SearchForContracts2Request
            {
                LevelIndex = -1,
                CheckpointId = -1,
                Difficulty = -1,
                ContractName = filter,
                StartIndex = page * pageSize,
                Range = pageSize
            });

            return Json(contracts.Select(x => new
            {
                x.Id,
                x.UserId,
                Name = x.DisplayId,
                x.Description,
                Level = _contractsService.GetLevelName(x),
                Targets = x.Targets.Targets
                    .Select(y => y.Name)
                    .ToList(),
                Difficulty = _contractsService.GetDifficultyName(x),
                Score = x.HighestScoringFriendScore
            }));
        }

        [HttpGet("share/{contractId}")]
        public IActionResult GetShareLink(string contractId)
        {
            var contractLink = _contractsService.GetShareableContractLink(contractId);

            return Json($"http://localhost:40147/contracts/create/{contractLink}");
        }

        [HttpGet("create/{compressedBase64Contract}")]
        public IActionResult CreateContract(string compressedBase64Contract)
        {
            _contractsService.CreateContract(compressedBase64Contract);

            return RedirectToAction("Index");
        }

        [HttpGet("delete/{contractId}")]
        public IActionResult DeleteContract(string contractId)
        {
            _contractsService.RemoveContract(contractId);

            return RedirectToAction("Index");
        }
    }
}
