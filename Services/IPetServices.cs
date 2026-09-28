using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_5_Pet_Adoption_API
{
    public interface IPetServices
    {
        //Getting whole list
        List<Pet> GetAll();

        //Adding Pet
        Pet AddPet(Pet newpet); //PlaceHolders

        //Updating List
        bool Update (int id, Pet item);

        //Adopting Pet
        bool IsAdopt (int id);

        //Soft Deleting Pet
        bool IsRemove (int id);

        //Search by ID
        Pet GetById(int id);

    }
}