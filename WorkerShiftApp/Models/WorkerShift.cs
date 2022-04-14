using System;
namespace WorkerShiftApp.Models

{
    public class WorkerShift
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ShiftId { get; set; }
        public DateTime ShiftDay { get; set; }
    }
}
