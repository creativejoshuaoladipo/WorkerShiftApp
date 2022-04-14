using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkerShiftApp.Models;

namespace WorkerShiftApp.Services
{
    public class WorkerServices : IWorkerServices
    {
        List<Worker> workers = new List<Worker>();
        List<Shift> shifts = new List<Shift>();
        List<WorkerShift> workersShifts = new List<WorkerShift>();
        bool workerflag = false;
        bool workerShitFlag = false;

        public async Task<List<Worker>> AddWorker(Worker obj)
        {
            foreach (var item in workers)
            {
                if (item.Id == obj.Id)
                {
                    throw new Exception($"Worker with {item.Id} already exist");
                }
            }
            workers.Add(obj); // You can print out the List of Workers
            return workers;
        }
        public async Task<List<Shift>> AddShift(Shift obj)
        {
            foreach (var item in shifts)
            {
                if (item.Id == obj.Id)
                {
                    throw new Exception($"Shift with {item.Id} already exist");
                }
            }
            shifts.Add(obj);

            return shifts;
        }

        public async Task<List<WorkerShift>> AssignWorkerToShift(WorkerShift obj)
        {
            foreach (var item in workersShifts)
            {
                if (item.WorkerId == obj.WorkerId && item.ShiftDay.ToShortDateString() == obj.ShiftDay.ToShortDateString())
                {
                    throw new Exception($"WorkerShift with id: {item.Id} already has a shift for that day,  Pick another day");
                }
            }

            workersShifts.Add(obj);

            return workersShifts;
        }
           
        }
    }

