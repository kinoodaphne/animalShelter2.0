using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelter.MVC.Models;
using Shelter.shared;

namespace Shelter.MVC.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Shelter(){
            
            return Json(AnimalDatabase.Shelter);
            
        }
    }
}