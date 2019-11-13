// ANIMAL DATABASE
using System;
using System.Collections.Generic;
using Shelter.MVC.Models;
using Shelter.Shared;

namespace Shelter.MVC.Models
{
  public class AnimalDatabase
  {
    private static bool _isInitialized = false;
    private static Shelter.Shared.Shelter _shelter = null;

    private static void Initialize()
    {
      if (!_isInitialized)
      {
        var shelter = new Shelter.Shared.Shelter()
        {
          Animals = new List<Animal> {
            // (int id, string name, string race, DateTime dateOfBirth, bool isChecked, bool kidFriendly, DateTime since, int shelterId, bool barker)
            new Dog(1, "Sia", "Shitzu", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(2, "Bouncer", "Welsh Terrier", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(3, "Bonbon", "Bernedoodle", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(4, "Roscoe", "Beagle", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(5, "Neon", "Rottweiler", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(6, "Pudge", "Pug", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            new Dog(7, "Bruno", "English Stafford", new DateTime(2019, 09, 09), true, true, new DateTime(2019, 10, 13), 1, false),

            // (int id, string name, string race, DateTime dateOfBirth, bool isChecked, bool kidFriendly, DateTime since, int shelterId, bool declawed)
            new Cat(1, "Jef", "Tabby", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(2, "Marvin", "Bombay", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(3, "Shaggy", "Highland Fold", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(4, "Toturi", "Russian Blue", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(5, "Wiggle", "Chartreux", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(6, "Mila", "American Shorthair", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),

            new Cat(7, "Twizzy", "American Curl", new DateTime(2009, 12, 06), true, true, new DateTime(2019, 10, 13), 1, false),
            
            // (int id, string name, string race, string description, DateTime dateOfBirth, bool isChecked, bool kidFriendly, int shelterId, DateTime since)
            new Other(3, "Hammy", "Gerbil", "This is a hamster", new DateTime(2017, 05, 19), true, true, 1, new DateTime(2019, 10, 13)),
            }
        };

        shelter.Id = 1;
        shelter.Name = "VIDA";

        _shelter = shelter;
        _isInitialized = true;
      }
    }

    public static Shared.Shelter Shelter
    {
      get
      {
        Initialize();
        return _shelter;
      }
    }
  }
}