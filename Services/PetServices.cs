
using Microsoft.AspNetCore.Http.HttpResults;
using SQLitePCL;

namespace Challenge_5_Pet_Adoption_API
{
    public class PetServices : IPetServices
    {
         private static List<Pet> manafest = [
            new Pet {Id = 1, Name = "John", Species = "Dog", Breed = "Bulldog", IsAdopted = true, IsDeleted = false},
            new Pet {Id = 2, Name = "Pepper", Species = "Cat", Breed = "Tortoiseshell", IsAdopted = true, IsDeleted = false},
            new Pet {Id = 3, Name = "Sam", Species = "Bird", Breed = "Blue-and-Gold Macaw", IsAdopted = true, IsDeleted = false},
            new Pet {Id = 4, Name = "Ben", Species = "Turtle", Breed = "Wood Turtle", IsAdopted = true, IsDeleted = false},
            new Pet {Id = 5, Name = "Jane", Species = "Lizard", Breed = "Bearded Dragon", IsAdopted = true, IsDeleted = false},
            new Pet {Id = 6, Name = "Tim", Species = "Fish", Breed = "Goldfish", IsAdopted = true, IsDeleted = false}
        ];

        static int newId = 7;
        
        private AppDbContext _db;

        public PetServices(AppDbContext db)
        {
            _db = db;
            //Makes Constructor run automatically
        }

        public List<Pet> GetAll()
        {
            return _db.Pets
                .Where(c => c.IsAdopted && !c.IsDeleted)
                .ToList();
        }

        public Pet AddPet(Pet newPet)
        {
            newPet.Id = 0;

            _db.Pets.Add(newPet);
            _db.SaveChanges(); //Saves Changes Made

            _db.SaveChanges();

            return newPet;
        }

        public Pet GetById(int id)
        {
            Pet? item = _db.Pets.FirstOrDefault(c => c.Id == id);

            return item;
        }

        public bool Update(int id, Pet item)
        {
            Pet? existing = _db.Pets.FirstOrDefault(i => i.Id == id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = item.Name;
            existing.Species = item.Species;
            existing.Breed = item.Breed;

            _db.SaveChanges();

            return true;
        }

        public bool IsRemove(int id)
        {
            var remove = _db.Pets.FirstOrDefault(c => c.Id == id);

            if(remove == null)
            {
                return false;
            }

            remove.IsAdopted = false;
            remove.IsDeleted = true;
            
            _db.SaveChanges();

            return true;
        }

        public bool IsAdopt(int id)
        {
            var adopt = _db.Pets.FirstOrDefault(c => c.Id == id);

            if(adopt == null)
            {
                return false;
            }

            adopt.IsDeleted = false;
            adopt.IsAdopted = true;
            
            _db.SaveChanges();

            return true;
        }
        
    }
}