using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Portfolio_API.Controllers
{
    public class PortfolioController : ApiController
    {

        class DummyData
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }


        public IHttpActionResult Get()
        {
            try
            {
                var results = new List<DummyData>
                {
                    {
                        new DummyData
                        {
                            ID = 1,
                            Name = "Portfolio 1"
                        }
                    },
                    {
                        new DummyData
                        {
                            ID = 2,
                            Name = "Portfolio 1"
                        }
                    }
                };
                

                return Ok(results);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
