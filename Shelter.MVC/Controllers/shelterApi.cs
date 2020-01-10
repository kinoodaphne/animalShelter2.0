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

namespace Shelter.MVC.Controllers.V1
{
    [Route("/v1/shelters")]
    public class shelterApi : Controller
    {
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<shelterApi> _logger;

        public shelterApi(ILogger<shelterApi> logger, ShelterContext context)//, ShelterDataAccess dataAccess)
        {
            _dataAccess = new ShelterDataAccess(context);
            _logger = logger;
        }

        #region Get

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

        [HttpGet("{shelterId}/cats")]
        public IActionResult GetAllCatsFromShelter(int id)
        {
            var cats = _dataAccess.GetCatsByShelter(id); ;
            return Ok(cats);
        }

        [HttpGet("{shelterId}/dogs")]
        public IActionResult GetAllDogsFromShelter(int id)
        {
            var dogs = _dataAccess.GetDogsByShelter(id); ;
            return Ok(dogs);
        }

        [HttpGet("{shelterId}/others")]
        public IActionResult GetAllOtherFromShelter(int id)
        {
            var others = _dataAccess.GetOthersByShelter(id);
            return Ok(others);
        }

        #endregion

        #region Delete

        [HttpDelete("{shelterId}/animals/{animalId}")]
        public IActionResult Delete(int shelterId, int animalId)
        {
            _dataAccess.removeAnimal(shelterId, animalId);
            return Ok();
        }

#endregion

#region Put

        [HttpPost("create")]
        public IActionResult create([FromBody]Shared.Shelter name)
        {
            
            name =  _dataAccess.AddShelter(name);
            return Created("", name.Id); 
        }
#endregion

#region Post
    
        [HttpPost("{shelterId}/cat")]
        public ActionResult CreateCat(int shelterId, [FromBody]Cat _animal)
        {
            _dataAccess.addCat(_animal);
            return Created("", _animal);
           
        }

        [HttpPost("{shelterId}/dog")]
        public ActionResult CreateDog(int shelterId, [FromBody]Dog _animal)
        {
            _dataAccess.addDog(_animal);
            return Created("", _animal);
        }

        [HttpPost("{shelterId}/other")]
        public ActionResult CreateOther(int shelterId, [FromBody]Other _animal)
        {
            _dataAccess.addOther(_animal);
            return Created("", _animal);
        }
        
#endregion
    }
}
