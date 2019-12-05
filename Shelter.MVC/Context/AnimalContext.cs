using System.Data.Entity;
using Shelter.Shared;

namespace Shelter.MVC.Context {
    public class AnimalContext : DbContext{
        public DbSet<Animal> Animals { get; set; }
    }
}