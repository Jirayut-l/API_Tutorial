using API_Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using API_Model;


namespace API_Tutorial.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _userService.GetAllUserLogin();
                if (!response.Success) return BadRequest();
                return Ok(response.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(UserLoginModel model)
        {
            try
            {
                var response = await _userService.CreateUserLogin(model);
                if (response.Success) return Ok(response);
                
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPatch]
        public void Patch()
        {

        }
    }
}
