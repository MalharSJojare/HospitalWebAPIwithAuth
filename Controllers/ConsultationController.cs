using HospitalWebApi.Hospital;
using HospitalWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private IRepository _rp;
        public ConsultationController(IRepository repository)
        {
            _rp = repository;
        }
        [Authorize]
        [HttpPost("Consultation")]
        public IActionResult Consultation(TblConsultation tblReport)
        {
            try
            {
                _rp.CreateConsultation(tblReport);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPut("Consultation")]
        public IActionResult Consultation(int id, TblConsultation tblReport)
        {
            try
            {
                _rp.EditConsultation(id, tblReport);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet("Consultation/{id}")]
        public TblConsultation Consultation([FromRoute] int id)
        {
            if (id != 0)
            {
                return _rp.SelectConsultation(id);
            }
            else
            {
                return null;
            }
        }
        [Authorize]
        [HttpDelete("Consultation/{id}")]
        public IActionResult DeleteConsultation([FromRoute] int id)
        {
            try
            {
                _rp.DeleteConsultation(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
