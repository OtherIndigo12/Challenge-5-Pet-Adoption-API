using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_5_Pet_Adoption_API
{
    public interface IWorkersServices
    {
        List<Workers> GetAll();
        
        bool Update(int id, Workers item);

        bool IsWorking(int id);


    }
}