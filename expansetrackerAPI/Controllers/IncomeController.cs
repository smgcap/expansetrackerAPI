using expansetrackerAPI.Data;
using expansetrackerAPI.Interfaces;
using expansetrackerAPI.Models.Income;
using expansetrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace expansetrackerAPI.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService) {
            this._incomeService = incomeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
            IEnumerable<IncomeSource> incomeSources = _incomeService.GetAllIncomeSources();
            return Ok(incomeSources);
        }
        public IActionResult Get(int id)
        {
            IncomeSource incomeSource = _incomeService.GetIncomeSourceById(id);
            if (incomeSource == null)
            {
                return NotFound();
            }
            return Ok(incomeSource);
        }
        public IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody] IncomeSource incomeSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _incomeService.AddIncomeSource(incomeSource);
                return CreatedAtRoute("DefaultApi", new { id = incomeSource.IncomeSourceID }, incomeSource);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public IActionResult Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] IncomeSource incomeSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incomeSource.IncomeSourceID)
            {
                return BadRequest("Id mismatch between URL and payload");
            }

            try
            {
                _incomeService.UpdateIncomeSource(incomeSource);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _incomeService.DeleteIncomeSource(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
