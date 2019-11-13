using System;
namespace Shelter.Shared
{
    public class Caretaker : Employee
    {
        public Caretaker() : base() {

        }

        public Caretaker(int id, string firstName, string lastName, DateTime dateOfBirth, DateTime employeedSince, bool hasMultipleAnimals) :base(id, firstName, lastName, dateOfBirth, employeedSince) {
            HasMultipleAnimals = hasMultipleAnimals;
        }

        public bool HasMultipleAnimals { get; set; }
    }
}