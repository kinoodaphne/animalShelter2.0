using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelter.MVC.Models;
using Shelter.MVC.Context;
using Shelter.Shared;

namespace Shelter.MVC.Controllers
{
    [Route("/v1/shelters")]
    public class ApiController : Controller
    {
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger, ShelterContext context)//, ShelterDataAccess dataAccess)
        {
            _dataAccess = new ShelterDataAccess(context);
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }
        

        [HttpGet("full")]
        public IActionResult GetAllSheltersFull()
        {
            
            return Ok(_dataAccess.GetAllSheltersFull());
        }



        [HttpGet("{id}")]
        public IActionResult GetShelter(int id)
        {
            var shelter = _dataAccess.GetShelterById(id); ;
            return shelter == default(Shelter.Shared.Shelter) ? (IActionResult)NotFound() : Ok(shelter);
        }

        [HttpGet("{id}/animals")]
        public IActionResult GetSheltersAnimals(int id)
        {
            
            var animals = _dataAccess.GetAnimals(id);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
        }

        [HttpGet("{shelterId}/animals/{animalId}")]
        public IActionResult GetAnimalDetails(int shelterId, int animalId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shelter.Shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
        }


    }
}
