using System;
namespace Shelter.Shared
{
    public class Manager : Employee
    {
        public Manager() : base() {

        }

        public Manager(int id, string firstName, string lastName, DateTime dateOfBirth, DateTime employeedSince, DateTime managerSince) :base(id, firstName, lastName, dateOfBirth, employeedSince) {
            ManagerSince = managerSince;
        }

        public DateTime ManagerSince { get; set; }
    }
}