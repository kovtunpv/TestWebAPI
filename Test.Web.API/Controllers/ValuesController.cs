using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.Web.API.LogProvider;
using Test.Web.API.Models;

namespace Test.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Fields

        private TestContext db;
        private readonly ILogger<ValuesController> _logger;

        #endregion

        #region Constructor

        public ValuesController(ILogger<ValuesController> logger, TestContext contex)
        {
            db = contex;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET api/values
        [Authorize]
        [Route("getlist")]
        [HttpGet]
        public IEnumerable<DateInterval> Get(string DateFrom, string DateTo)
        {
            if(!String.IsNullOrEmpty(DateFrom) || !String.IsNullOrEmpty(DateTo))
            {
                _logger.LogInformation((int)LoggingEvents.GENERATE_ITEMS, "Отображение списка дат.");
                return db.DateIntervals.Where(x => x.DateTo >= Convert.ToDateTime(DateFrom) && x.DateFrom <= Convert.ToDateTime(DateTo)).ToList();
            }
            else
            {
                return null;
            }
        }

        // POST api/values
        [Authorize]
        [Route("saveinterval")]
        [HttpPost]
        public IActionResult Post()
        {
            var from = Request.Form["from"];
            var to = Request.Form["to"];

            if(!String.IsNullOrEmpty(from) || !String.IsNullOrEmpty(to))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);

                DateInterval interval = new DateInterval
                {
                    DateFrom = dateFrom,
                    DateTo = dateTo
                };

                db.DateIntervals.Add(interval);
                db.SaveChanges();

                _logger.LogInformation((int)LoggingEvents.INSERT_ITEM, "Сохранение интервала в бд.");
                return Ok("Интервал сохранен");
            }
            else
            {
                return Ok("Не коректный интервал");
            }
            
        }
        
        #endregion
    }
}
