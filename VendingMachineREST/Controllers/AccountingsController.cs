using Microsoft.AspNetCore.Mvc;
using VendingMachineREST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachineREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingsController : ControllerBase
    {
        private AccountingsRepository _accountingsRepository;

        public AccountingsController(AccountingsRepository accountingsRepository)
        {
            _accountingsRepository = accountingsRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET: api/<AccountingsController>
        [HttpGet]
        public ActionResult<IEnumerable<Accounting>> Get()
        {
            return Ok(_accountingsRepository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<AccountingsController>
        [HttpPost]
        public ActionResult<Accounting> Post([FromBody] Accounting newAccounting)
        {
            try
            {
                Accounting addedAccounting = _accountingsRepository.Add(newAccounting);
                return Created($"/api/accountings/{addedAccounting.Id}", addedAccounting);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
