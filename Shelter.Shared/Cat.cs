using System;

namespace Shelter.Shared
{
    public class Cat : Animal
    {
        public Cat() : base() {

        }

        public Cat(int id, string name, string race, DateTime dateOfBirth, bool isChecked, bool kidFriendly, DateTime since, int shelterId, bool declawed) : base(id, name, race, dateOfBirth, isChecked, kidFriendly, since, shelterId) {
            Declawed = declawed;
        }
        public bool Declawed { get; set; }
    }
}