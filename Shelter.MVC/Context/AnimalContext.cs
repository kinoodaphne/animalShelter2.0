using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelter.Shared;

namespace Shelter.MVC.Context {
    public class AnimalContext : DbContext{
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options){

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter.Shared.Shelter> Shelters { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}