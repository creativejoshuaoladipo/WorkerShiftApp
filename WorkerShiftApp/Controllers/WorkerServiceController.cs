using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkerShiftApp.Helper;
using WorkerShiftApp.Models;
using WorkerShiftApp.Services;

namespace WorkerShiftApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerServiceController : ControllerBase
    {
       private readonly IWorkerServices _workerServices;
        public WorkerServiceController(IWorkerServices workerServices)
        {
             _workerServices = workerServices;
        }
        [HttpPost("AddWorker")]
        public async Task<IActionResult> AddWorker(Worker obj)
        {
            var result = await  _workerServices.AddWorker(obj);
            return Ok( StandardResponse.Ok("The Worker was Successfully Added", result));
        }

        [HttpPost("AddShift")]
        public async Task<IActionResult> AddShift(Shift obj)
        {
            var result = _workerServices.AddShift(obj);
            return Ok(StandardResponse.Ok("The Shift was Successfully Created", result));
        }


        [HttpPost("AssignWorkerToShift")]
        public async Task<IActionResult> AssignWorkerToShift(WorkerShift obj)
        {
            var result = _workerServices.AssignWorkerToShift(obj);
            return Ok(StandardResponse.Ok("The Worker's Shift was Successfully Added", result));
        }
    }
}
