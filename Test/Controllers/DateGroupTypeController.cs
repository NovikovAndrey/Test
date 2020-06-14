using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_Project_Requirements.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Project_Requirements.Controllers
{
    [Route("api/DateGroupType")]
    [ApiController]
    public class DateGroupTypeController : ControllerBase
    {
        // GET: api/<DateGroupTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> ts = new List<string>(); 
            foreach (string Name in Enum.GetNames(typeof(DateGroupType)))
            {
                ts.Add(Name);
            }
            return ts;
        }
    }
}
