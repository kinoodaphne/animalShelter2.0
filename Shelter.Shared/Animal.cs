using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
    public class Animal
    {
        public Animal() {

        }

        public Animal(int id, string name, string race, DateTime dateOfBirth, bool isChecked, bool kidFriendly, DateTime since, int shelterId) {
            Id = id;
            Name = name;
            Race = race;
            DateOfBirth = dateOfBirth;
            IsChecked = isChecked;
            KidFriendly = kidFriendly;
            Since = since;
            ShelterId = shelterId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public DateTime Since { get; set; }
        public int ShelterId { get; set; }
    }
}