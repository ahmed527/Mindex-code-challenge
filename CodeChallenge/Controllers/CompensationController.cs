using CodeChallenge.Models;
using CodeChallenge.Services;
using CodeChallenge.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            this._compensationService = compensationService;
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetById(String employeeId)
        {
            _logger.LogDebug($"Received compensation get request for employee '{employeeId}'");

            var compensation = _compensationService.GetById(employeeId);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Compensation compensation)
        {
                _logger.LogDebug($"Received compensation create request for employee '{compensation.Employee.EmployeeId}'");

           await _compensationService.Create(compensation);

            return CreatedAtRoute("", new { id = compensation.Employee.EmployeeId }, compensation);
        }


    }
}
