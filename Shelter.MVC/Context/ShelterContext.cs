using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelter.Shared;

namespace Shelter.MVC.Context {
    public class ShelterContext : DbContext{
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options){

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter.Shared.Shelter> Shelters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Other> Others { get; set; }
    }
}