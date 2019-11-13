
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelter.MVC.Models;
using Shelter.Shared;

namespace Shelter.MVC.Controllers
{
    public class ShelterController : Controller
    {
        private readonly ILogger<ShelterController> _logger;

        public ShelterController(ILogger<ShelterController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Create view model and add view AnimalDatabase.Shelter in it
            return View(AnimalDatabase.Shelter);
        }

        public IActionResult Detail(int id) {

            // Select a specific animal with their id and display a detailspage for this animal

            var targetAnimal = AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (targetAnimal == default(Animal))
			{
				return NotFound();
			}
			return View(targetAnimal);
        }

        public IActionResult Delete(int id)
		{
			var targetAnimal = AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (targetAnimal == default(Animal))
			{
				return NotFound();
			}
			return View(targetAnimal);
		}

		[HttpPost]
		public IActionResult DoDelete(int id)
		{
			var targetAnimal = AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
			if (targetAnimal == default(Animal))
			{
				return NotFound();
			}
			AnimalDatabase.Shelter.Animals.Remove(targetAnimal);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Update(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }

        [HttpPost]
        public IActionResult DoUpdate(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            var newName = Request.Form["name"];
            AnimalDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id).Name = newName;
            return RedirectToAction(nameof(Index));

        }
    }
}