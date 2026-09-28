using Microsoft.AspNetCore.Mvc;

namespace Challenge_5_Pet_Adoption_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        
        private readonly IPetServices _pet;

        public PetController(IPetServices pet)
        {
            _pet = pet;
        }

        //Get All Pets
        [HttpGet("GetAllPets")]

        public ActionResult<List<Pet>> GetAll()
        {
            List<Pet> Pets = _pet.GetAll();
            return Ok(Pets);
        }

        //Add Pet
        [HttpPost("Create")]

        public ActionResult<Pet> Create([FromBody] Pet newPet)
        {
            Pet createdPet = _pet.AddPet(newPet);
            return CreatedAtAction(
                nameof(GetAll),
                createdPet
            );
        }

        //Search by ID
        [HttpGet("GetById/{Id}")]

        public ActionResult<Pet> GetById(int id)
        {
            Pet item = _pet.GetById(id);

            if (item == null)
            {
                return NotFound("This Pet is not here....");
            }

            return Ok(item);
        }

        //Update Pet Info
        [HttpPut("update/{id}")]

        public ActionResult<bool> Update(int id, Pet item)
        {
            bool updated = _pet.Update(id, item);

            if (updated == false)
            {
                return NotFound("This pet is not here.....");
            }

            return NoContent();
        }

        //Soft Delete Pet
        [HttpDelete("SoftRemove/{id}")]

        public ActionResult<string> SoftDelete(int id)
        {
            bool remove = _pet.IsRemove(id);

            if (remove == false)
            {
                return NotFound("This Pet is not here....");
            }

            return Ok("The Pet has been Removed from the Database");
        }

        [HttpPost("AdoptPet/{id}")]

        public ActionResult<string> AdoptPet(int id)
        {
            bool adopt = _pet.IsAdopt(id);

            if (adopt == null)
            {
                return NotFound("This Pet is not here...");
            }

            return Ok("This Pet has been Adopted!");
        }


    }
}