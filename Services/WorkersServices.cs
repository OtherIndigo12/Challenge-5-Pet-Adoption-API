using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;

namespace Challenge_5_Pet_Adoption_API
{
    public class WorkersServices : IWorkersServices
    {
        private static List<Workers> manafest2 = [
            new Workers {Id = 1, FirstName = "John", LastName = "Doe", Email = "JDoe@PetCare.co", Salary = 50, JobPosition = "Janitor", isWorking = true},
            new Workers {Id = 2, FirstName = "Eric", LastName = "Smith", Email = "ESmith@PetCare.co", Salary = 60, JobPosition = "Security", isWorking = true},
            new Workers {Id = 3, FirstName = "Jessie", LastName = "Doe", Email = "JDoe@PetCare.co", Salary = 70, JobPosition = "Pet Caretaker", isWorking = true},
            new Workers {Id = 4, FirstName = "Bill", LastName = "Johnson", Email = "BJohnson@PetCare.co", Salary = 70, JobPosition = "Pet Caretaker", isWorking = false}
        ];

        public List<Workers> GetAll()
        {
            return manafest2;
        }

        public bool Update(int id, Workers item)
        {
            Workers working = manafest2.FirstOrDefault(i => i.Id == id);

            if (working == null)
            {
                return false;
            }

            working.JobPosition = item.JobPosition;
            working.Salary = item.Salary;

            return true;
        }

        public bool IsWorking(int id)
        {
            Workers workingmore = manafest2.FirstOrDefault(i => i.Id == id);

            if (workingmore == null)
            {
                return false;
            }

            return true;
        }


    }
}