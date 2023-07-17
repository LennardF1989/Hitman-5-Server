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

        [HttpGet("all")]
        public IActionResult GetContracts()
        {
            const int pageSize = 1000;

            var contracts = _contractsService.GetContracts(new HitmanController.SearchForContracts2Request
            {
                LevelIndex = -1,
                CheckpointId = -1,
                Difficulty = -1,
                ContractId = string.Empty,
                StartIndex = 0,
                Range = pageSize
            });

            return Json(contracts.Select(x => new
            {
                x.Id,
                Name = x.DisplayId,
                x.Description,
                Level = _contractsService.GetLevelName(x),
                Targets = x.Targets.Targets
                    .Select(y => y.Name)
                    .ToList(),
                Difficulty = _contractsService.GetDifficultyName(x),
                Score = x.UserScore
            }));
        }

        [HttpGet("share/{contractId}")]
        public IActionResult GetShareLink(string contractId)
        {
            var contractLink = _contractsService.GetShareableContractLink(contractId);

            return Json($"http://localhost/contracts/create/{contractLink}");
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
