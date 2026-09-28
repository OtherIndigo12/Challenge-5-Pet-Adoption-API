using Microsoft.AspNetCore.Mvc;

namespace Challenge_5_Pet_Adoption_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {

        private readonly IWorkersServices _worker;

        public WorkerController(IWorkersServices worker)
        {
            _worker = worker;
        }

        [HttpGet("GetAllWorkers")]

        public ActionResult GetAll()
        {
            return Ok(_worker.GetAll());
        }
    }
}