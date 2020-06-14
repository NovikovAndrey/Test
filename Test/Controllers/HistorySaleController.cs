using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_Project_Requirements.DBConnection;
using Test_Project_Requirements.GeneralСlasses;
using Test_Project_Requirements.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Project_Requirements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorySaleController : ControllerBase
    {
        ApplicationContext db;
        private DateTime StartDateTime;
        private DateTime EndDateTime;

        public HistorySaleController(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }
        // GET: api/<HistorySaleController>
        [HttpGet("group={group}&StartDT={StartDT}&EndDT={EndDT}")]
        public IEnumerable<Sales> Get(
            string StartDT = null,
            string EndDT = null,
            DateGroupType group = DateGroupType.Day)
        {
            IEnumerable<Sales> Group;
            if (StartDT == null) { StartDateTime = DateTime.MinValue; }
            else { DateTime.TryParseExact(StartDT, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out StartDateTime); }

            if (EndDT == null) { EndDateTime = DateTime.MaxValue; }
            else { DateTime.TryParseExact(EndDT, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out EndDateTime); }

            switch (group)
            {
                case DateGroupType.Week:
                    {
                        Group = MathGroup.GetHistorySalesWeek(db.HistorySales.Where(x => x.DateSale >= StartDateTime).Where(x => x.DateSale <= EndDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                case DateGroupType.Month:
                    {
                        Group = MathGroup.GetHistorySalesMonth(db.HistorySales.Where(x => x.DateSale >= StartDateTime).Where(x => x.DateSale <= EndDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                case DateGroupType.Quarter:
                    {
                        Group = MathGroup.GetHistorySalesQuarter(db.HistorySales.Where(x => x.DateSale >= StartDateTime).Where(x => x.DateSale <= EndDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                default:
                    {
                        Group = MathGroup.GetHistorySalesDay(db.HistorySales.Where(x => x.DateSale >= StartDateTime).Where(x => x.DateSale <= EndDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
            }
            return MathGroup.GetSales(StartDateTime, EndDateTime, group);
        }


        // POST api/<HistorySaleController>
        [HttpPost]
        public IActionResult Post(HistorySale historySale)
        {
            if (ModelState.IsValid)
            {
                db.HistorySales.Add(historySale);
                db.SaveChanges();
                return Ok(historySale);
            }
            return BadRequest(ModelState);
        }
    }
}
