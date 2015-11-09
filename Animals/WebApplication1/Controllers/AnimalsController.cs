using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using Repository;

namespace WebApplication1.Controllers
{
    public class AnimalsController : ApiController
    {
        private readonly Mappers _mappers = new Mappers();
        private readonly GetRepository _respository;

        public AnimalsController()
        {
            _respository = new GetRepository();
        }

        public IHttpActionResult Get()
        {
            var animals = _respository.GetAnimals();
            return Ok(_mappers.MapEntityToDto(animals));
        }
    }
}