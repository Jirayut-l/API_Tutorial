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
        //[Route("get-all")]
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
               return Ok(response);
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
        [HttpDelete("{pkUid}")]
        public async Task<IActionResult> Delete(int pkUid)
        {
            try
            {
                var response = await _userService.DeleteUserLogin(pkUid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public void Patch()
        {

        }
    }
}
