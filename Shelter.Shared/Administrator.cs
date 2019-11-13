using System;
namespace Shelter.Shared
{
    public class Administrator : Employee
    {
        public Administrator() : base() {

        }

        public Administrator(int id, string firstName, string lastName, DateTime dateOfBirth, DateTime employeedSince, DateTime administratorSince) :base(id, firstName, lastName, dateOfBirth, employeedSince) {
            AdministratorSince = administratorSince;
        }

        public DateTime AdministratorSince { get; set; }
    }
}