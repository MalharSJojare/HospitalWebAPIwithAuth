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
    public class ReportController : ControllerBase
    {
        private IRepository _rp;
        public ReportController(IRepository repository) 
        {
            _rp = repository;
        }
        [Authorize]
        [HttpPost("Report")]
        public IActionResult Report(TblReport tblReport) 
        {
            try
            {
                _rp.CreateReport(tblReport);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPut("Report")]
        public IActionResult Report(int id,TblReport tblReport)
        {
            try
            {
                _rp.EditReport(id,tblReport);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet("Report/{id}")]
        public TblReport Report([FromRoute]int id)
        {
            if(id!=0)
            {
                return _rp.SelectReport(id);
            }
            else
            {
                return null;
            }
        }
        [Authorize]
        [HttpGet("Report")]
        public List<TblReport> Report()
        {
           return _rp.SelectReportList(); 
        }
        [Authorize]
        [HttpDelete("Report/{id}")]
        public IActionResult DeleteReport([FromRoute] int id)
        {
            try
            {
                _rp.DeleteReport(id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
