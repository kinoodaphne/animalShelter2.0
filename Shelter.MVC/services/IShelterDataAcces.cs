using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;
using Shelter.MVC.Context;

namespace Shelter.MVC
{
  public interface IShelterDataAccess
  {
    IEnumerable<Shelter.Shared.Shelter> GetAllShelters();
    IEnumerable<Shelter.Shared.Shelter> GetAllSheltersFull();
    Shelter.Shared.Shelter GetShelterById(int id);

    IEnumerable<Animal> GetAnimals(int shelterId);
    Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        Shared.Shelter AddShelter(Shared.Shelter shelter);
        List <Cat> GetCatsByShelter(int id);
        List <Dog> GetDogsByShelter(int id);
        List <Other> GetOthersByShelter(int id);
        void addCat(Cat animal);
        void addDog(Dog animal);
        void addOther(Other animal);
        void removeAnimal(int shelterId, int animalId);
    }

  public class ShelterDataAccess : IShelterDataAccess
  {
    private ShelterContext _context;

    public ShelterDataAccess(ShelterContext context)
    {
      _context = context;
    }

    public IEnumerable<Shelter.Shared.Shelter> GetAllShelters()
    {
      return _context.Shelters;
    }

    public IEnumerable<Shelter.Shared.Shelter> GetAllSheltersFull()
    {
      return _context.Shelters
        .Include(shelter=> shelter.Animals);
    
    }


    public IEnumerable<Animal> GetAnimals(int shelterId)
    {
      return _context.Shelters
        .Include(shelter => shelter.Animals)
        .FirstOrDefault(x => x.Id == shelterId)?.Animals;
    }

    public Shelter.Shared.Shelter GetShelterById(int id)
    {
      return _context.Shelters.FirstOrDefault(x => x.Id == id);
    }

    public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
    {
        return _context.Animals
        .FirstOrDefault(x => x.Id == shelterId && x.Id == animalId);
    }

    public Shared.Shelter AddShelter(Shared.Shelter shelter)
    {
        _context.Shelters.Add(shelter);
        _context.SaveChanges();
        return shelter;
    }

        public List<Cat> GetCatsByShelter(int id)
        {
            return _context.Cats.ToList();
        }

        public List<Dog> GetDogsByShelter(int id)
        {
            return _context.Dogs.ToList();
        }

        public List<Other> GetOthersByShelter(int id)
        {
            return _context.Others.ToList();
        }

        public void addCat(Cat animal)
        {
            _context.Cats.Add(animal);
            _context.SaveChanges();
        }

        public void addDog(Dog animal)
        {
            _context.Dogs.Add(animal);
            _context.SaveChanges();
        }

        public void addOther(Other animal)
        {
            _context.Others.Add(animal);
            _context.SaveChanges();
        }

        public void removeAnimal(int shelterId, int animalId)
        {
            var animal = _context.Animals.FirstOrDefault(x => x.Id == animalId && x.ShelterId == shelterId);
            _context.Animals.Remove(animal);
            _context.SaveChanges();

        }
    }
}