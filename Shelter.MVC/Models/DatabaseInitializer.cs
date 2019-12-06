using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shelter.MVC.Context;

namespace Shelter.Shared
{
  public interface IDatabaseInitializer
  {
    void Initialize();
  }

  public class DatabaseInitializer : IDatabaseInitializer
  {
    private AnimalContext _context;
    private ILogger<DatabaseInitializer> _logger;
    public DatabaseInitializer(AnimalContext context, ILogger<DatabaseInitializer> logger)
    {
      _context = context;
      _logger = logger;
    }
    public void Initialize()
    {
      try
      {
        if (_context.Database.EnsureCreated())
        {
          AddData();
        }
      }
      catch (Exception ex)
      {
        _logger.LogCritical(ex, "Error occurred while creating database");

      }
    }

    private void AddData()
    {
      var shelter1 = new Shelter()
      {
        Name = "Puppytier",
        Animals = new List<Animal> {
          new Dog { 
              Name = "Jupiler", 
              Race = "shitzu", 
              DateOfBirth =  new DateTime(2019, 09, 09), 
              IsChecked = true, 
              KidFriendly = true, 
              Since = DateTime.Now,
              ShelterId = 1,
              Barker = false
             },
          new Dog {
              Name = "Jupiler", 
              Race = "shitzu", 
              DateOfBirth =  new DateTime(2019, 09, 09), 
              IsChecked = true, 
              KidFriendly = true, 
              Since = DateTime.Now,
              ShelterId = 1,
              Barker = false
             },
          new Cat { 
              Name = "Jupiler", 
              Race = "shitzu", 
              DateOfBirth =  new DateTime(2019, 09, 09), 
              IsChecked = true, 
              KidFriendly = true, 
              Since = DateTime.Now,
              ShelterId = 1,
              Declawed = false
           }
        }
      };
      _context.Shelters.Add(shelter1);
      

      _context.SaveChanges();
    }
  }
}