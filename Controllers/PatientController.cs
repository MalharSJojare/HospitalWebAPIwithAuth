using HospitalWebApi.Hospital;
using HospitalWebApi.Repository;
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
    public class PatientController : ControllerBase
    {
        private IRepository _rp;
        public PatientController(IRepository repository)
        {
            _rp = repository;
        }
        [HttpPost("Patient")]
        public IActionResult Patient(TblPatient tblReport)
        {
            try
            {
                _rp.CreatePatient(tblReport);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("Patient")]
        public IActionResult Patient(int id, TblPatient tblReport)
        {
            try
            {
                _rp.EditPatient(id, tblReport);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("Patient/{id}")]
        public TblPatient Patient([FromRoute] int id)
        {
            if (id != 0)
            {
                return _rp.SelectPatient(id);
            }
            else
            {
                return null;
            }
        }
        [HttpGet("Patient")]
        public List<TblPatient> Patient()
        {
            return _rp.SelectPatientList();
        }
        [HttpDelete("Patient/{id}")]
        public IActionResult DeletePatient([FromRoute] int id)
        {
            try
            {
                _rp.DeletePatient(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
