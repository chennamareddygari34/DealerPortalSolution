using DealerPortalApp.Interfaces;
using DealerPortalApp.Models.DTOs;
using DealerPortalApp.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DealerPortalApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        #region  Login
        [HttpPost("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            

            try
            {
                var result = _service.Login(userDTO);
                if (result == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                return Ok(result);

            }
            catch (InvalidUserName ex)
            {
                return BadRequest(ex.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region  Add Registration
        [HttpPost("Register")]
        public ActionResult Register(UserDTO userDTO)
        {
            var result = _service.Register(userDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        #endregion
    }
}
