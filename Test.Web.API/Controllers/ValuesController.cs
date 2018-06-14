using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Web.API.Models;

namespace Test.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Fields

        private TestContext db;

        #endregion

        #region Constructor

        public ValuesController(TestContext contex)
        {
            db = contex;
        }

        #endregion

        #region Methods

        // GET api/values
        [Authorize]
        [Route("getlist")]
        [HttpGet]
        public IEnumerable<DateInterval> Get(string DateFrom, string DateTo)
        {
            return db.DateIntervals.Where(x => x.DateTo >= Convert.ToDateTime(DateFrom) && x.DateFrom <= Convert.ToDateTime(DateTo)).ToList();

            //return Ok(data);
        }

        // POST api/values
        [Authorize]
        [Route("saveinterval")]
        [HttpPost]
        public IActionResult Post()
        {
            var from = Request.Form["from"];
            var to = Request.Form["to"];

            DateTime dateFrom = Convert.ToDateTime(from);
            DateTime dateTo = Convert.ToDateTime(to);

            DateInterval interval = new DateInterval
            {
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            db.DateIntervals.Add(interval);
            db.SaveChanges();

            return Ok("Интервал сохранен");
        }
        
        #endregion
    }
}
