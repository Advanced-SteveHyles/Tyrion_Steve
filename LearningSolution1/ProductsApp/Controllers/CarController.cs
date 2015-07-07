using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class CarController : ApiController
    {
        private Car[] cars = new Car[]
        {
            new Car {Id=1,  Make="Ford",  Model = "Escort"},
            new Car {Id =2, Make = "Ford",  Model="Transit"},
            new Car {Id =3, Make = "Ford",  Model="Fiesta"},
            new Car {Id =4, Make = "Ford",  Model="Mondeo"},
            new Car {Id =5, Make = "KIA",  Model="Rio"}
        };

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public IHttpActionResult GetCar(int id)
        {
            var car = cars.FirstOrDefault((p) => p.Id == id);
            if (car  == null)
            {
                return NotFound();
            }
            return Ok(car);
        }


         public IEnumerable<Car> GetCarByMake(string make)
        {
            var carlist = cars.Where(p => p.Make == make);
             return carlist;            
        }
    }
}
