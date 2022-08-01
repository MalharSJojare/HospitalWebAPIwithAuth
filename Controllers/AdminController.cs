using HospitalWebApi.Hospital;
using HospitalWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HospitalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IConfiguration config;
        private IRepository _rp;
        public AdminController(IRepository repository, IConfiguration configuration)
        {
            config = configuration;
            _rp = repository;
        }
        [AllowAnonymous]
        [HttpPost("Admin")]
        public IActionResult Admin(TblAdmin tblAdmin) 
        {
            try 
            {
                _rp.CreateAdmin(tblAdmin);
                return Ok();
            }
            catch(Exception e) 
            {
                return BadRequest();
            }
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(TblAdmin tblAdmin) 
        {
            if (tblAdmin.EmailId== "" || tblAdmin.Password== "")
            {
                return BadRequest();
            }
            try
            {

                IActionResult response = Unauthorized();
                //_rp.Login(, password);
                //TblAdmin tblAdmin = new() { EmailId = userName, Password = password };
                TblAdmin admin = _rp.AuthenticateUser(tblAdmin);
               // Authenticate user = ap.AuthenticateUser(login);         //authenticatin the user first

                if (admin != null)
                {
                    var tokenString = _rp.GenerateJSONWebToken(admin, config);        //generating token only if the user is authenticated
                    response = Ok(tokenString);

                }
                
                return response;
            }
            catch (Exception e)
            {
             //   _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }
        }
    }
}
