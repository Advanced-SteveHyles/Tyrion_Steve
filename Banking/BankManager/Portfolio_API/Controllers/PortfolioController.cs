using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioManager.DTO;

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
                var results = new List<PortfolioDTO>
                {
                    {
                        new PortfolioDTO
                        {
                            ID = 1,
                            Name = "Portfolio 1"
                        }
                    },
                    {
                        new PortfolioDTO
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
