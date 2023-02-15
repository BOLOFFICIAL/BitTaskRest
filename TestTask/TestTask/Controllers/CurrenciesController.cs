using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Windows.Forms;
using XAct.Library.Settings;

namespace TestTask.Controllers
{
    public class Currency
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class CurrenciesController : ApiController
    {
        DB dB = new DB("Task");

        public List<Currency> lst = new List<Currency>()
        {
            new Currency()
            {
                Name = "USD",
                Id = 0
            },

            new Currency()
            {
                Name = "RUB",
                Id = 1
            },
        };

        [HttpGet, Route("Currencies")]

        public IEnumerable<Currency> Currencies()
        {

            MessageBox.Show(dB.GetConnection().ToString());
            return lst;
        }

        [HttpGet, Route("Currencies/{id}")]

        public Currency Currency(int id)
        {
            Currency Cur = lst[id];

            return Cur;
        }

        [HttpPost, Route("Currencies/new/{name}/{id}")]

        public IHttpActionResult NewCurrency(string name, int id)
        {
            if (id==1) 
            {
                return BadRequest();
            }
            lst.Add(new Currency() { Name = name, Id = id });
            string text = Request.Content.ReadAsStringAsync().Result;
            return Ok();
        }
    }
}
