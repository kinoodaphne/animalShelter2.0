using System;

namespace Shelter.Shared
{
    public class Other : Animal
    {
        public Other() : base() {

        }

        public Other(int id, string name, string race, string description, DateTime dateOfBirth, bool isChecked, bool kidFriendly, int shelterId, DateTime since) : base(id, name, race, dateOfBirth, isChecked, kidFriendly, since, shelterId) {
            Description = description;
        }
        public string Description { get; set; }
    }
}