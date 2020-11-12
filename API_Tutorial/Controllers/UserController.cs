using API_Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Model;
using Microsoft.AspNetCore.Http;


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
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // GET api/<UserController>/5
        [HttpGet("{pkUid}")]
        public async Task<IActionResult> Get(int pkUid)
        {
            try
            {
                var response = await _userService.GetUserLogin(pkUid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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
        [HttpPut]
        public async Task<IActionResult> Put(IEnumerable<UserLoginModel> models)
        {
            try
            {
                var response = await _userService.UpdateRangeUserLogin(models);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
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

        [HttpPatch("{pkUid}")]
        public async Task<IActionResult> Patch(int pkUid, UserLoginModel model)
        {
            try
            {
                var response = await _userService.UpdateUserLogin(pkUid, model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestModel model)
        {
            try
            {
                var response = await _userService.Authenticate(model, IP_Address());
                SetTokenCookie(response.Value.RefreshToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        private string IP_Address()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(3)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
