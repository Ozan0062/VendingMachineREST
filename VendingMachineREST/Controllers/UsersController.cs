using Microsoft.AspNetCore.Mvc;
using VendingMachineREST.Models;


namespace VendingMachineREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository _usersRepository;

        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: api/<UsersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? email, [FromQuery] string? mobileNumber)
        {
            return Ok(_usersRepository.GetAll(firstName, lastName, email, mobileNumber));
        }

        // POST api/<UsersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<User?> Post([FromBody] User newUser)
        {
            if ( _usersRepository.GetUsersPhonenumber().Contains(newUser.MobileNumber))
            {
                return BadRequest("Phone number already exists");
            }
            User? addedUser = _usersRepository.Add(newUser);
            try
            {
                return Created($"/api/users/{addedUser?.Id}", addedUser);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
