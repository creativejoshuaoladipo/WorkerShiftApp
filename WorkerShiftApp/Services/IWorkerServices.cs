using System.Collections.Generic;
using System.Threading.Tasks;
using WorkerShiftApp.Models;

namespace WorkerShiftApp.Services
{
    public interface IWorkerServices
    {
        Task<List<Worker>> AddWorker(Worker obj);
       Task<List<Shift>> AddShift(Shift obj);
        Task<List<WorkerShift>> AssignWorkerToShift(WorkerShift obj);


    }
}
