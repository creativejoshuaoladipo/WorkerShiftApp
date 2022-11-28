using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WorkerShiftApp.Models;
using WorkerShiftApp.Services;
using Xunit;

namespace WorkersShiftApp.Test
{
    public class UnitTests
    {
        
        [Fact]
        public async Task AddNewWorker_InputWorker_ReturnListOfWorkers()
        {
            //Arrange
            Worker obj = new Worker() { Id = 1 , Name = "Joshua"};

            //Act
            WorkerServices _workerServices   = new WorkerServices();
            var result = await _workerServices.AddWorker(obj);


            //Assert
            Assert.Contains(result, item => (item.Id == obj.Id && obj.Name == "Joshua"));

           
        }

        [Fact]
        public async Task AddWorkerWithTheSameId_InputWorker_ReturnListOfWorkers()
        {
            //Arrange
            Worker obj = new Worker() { Id = 1, Name = "Joshua" };

            //Act
            WorkerServices _workerServices = new WorkerServices();


            //Assert
            //1st Add
            var result = await _workerServices.AddWorker(obj);

            //2nd Add- Ought to throw an Exception Error Message
            await Assert.ThrowsAsync<Exception>(()=> _workerServices.AddWorker(obj));


        }


        [Fact]
        public async Task AddShift_InputShift_ReturnListOfWorkers()
        {
            //Arrange
            Shift obj = new Shift() { Id= 1, StartHour = 0, EndHour = 8 };

            //Act
            WorkerServices _workerServices = new WorkerServices();
            var result = await _workerServices.AddShift(obj); //And A New Shift


            //Assert
            Assert.Contains(result, item => ( obj.Id==item.Id && obj.StartHour == item.StartHour && obj.EndHour == item.EndHour));


        }

        [Fact]
        public async Task AddShiftWithTheSameId_InputShift_ReturnListOfWorkers()
        {
            //Arrange
            Shift obj = new Shift() {  Id = 1, StartHour = 0, EndHour = 8 };

            //Act
            WorkerServices _workerServices = new WorkerServices();
            await _workerServices.AddShift(obj); //Add The First Shift

            Shift obj2 = new Shift() { Id = 1, StartHour = 8, EndHour = 16 };

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _workerServices.AddShift(obj2)); //Add the Second Shift with the Same Id as the first ;-

        }

        [Fact]
        public async Task AddWorkerShift_InputWorkerShift_ReturnListOfWorkers()
        {
            //Arrange
            Worker worker = new Worker() { Id = 1, Name = "Joshua" };
            Shift shift = new Shift() { Id = 1, StartHour = 0, EndHour = 8 };
            WorkerShift obj = new WorkerShift() { Id= 1, WorkerId = worker.Id, ShiftId = shift.Id, ShiftDay = DateTime.Now.AddDays(2)};


            //Act
            WorkerServices _workerServices = new WorkerServices();
            var result = await _workerServices.AssignWorkerToShift(obj); //And A New Shift

            //Assert
            Assert.Contains(result, item => (obj.Id == item.Id && obj.ShiftId == item.ShiftId && item.ShiftDay == obj.ShiftDay));


        }

        [Fact]
        public async Task AddWorkerShiftWithTheSameId_InputWorkerShift_ReturnListOfWorkers()
        {
            //Arrange
            Worker worker = new Worker() { Id = 1, Name = "Joshua" };
            Shift shift = new Shift() { Id = 1, StartHour = 0, EndHour = 8 };
            WorkerShift obj = new WorkerShift() { Id = 1, WorkerId = worker.Id, ShiftId = shift.Id, ShiftDay = DateTime.Now.AddDays(2) };


            //Act
            WorkerServices _workerServices = new WorkerServices();
            var result = await _workerServices.AssignWorkerToShift(obj); //And A New Shift

            Worker worker2 = new Worker() { Id = 1, Name = "Joshua" };
            await _workerServices.AddWorker(worker2); //Add The First Shift


            Shift shift2 = new Shift() { Id = 2, StartHour = 9, EndHour = 17 };
            await _workerServices.AddShift(shift2); //Add The First Shift

            WorkerShift obj2 = new WorkerShift() { Id = 1, WorkerId = worker.Id, ShiftId = shift.Id, ShiftDay = DateTime.Now.AddDays(2) };

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _workerServices.AssignWorkerToShift(obj2)); //Add the Second Shift with the Same Id as the first ;-

        }

        [Fact]
        public async Task AddWorkerShiftWithTheSameShiftDay_InputWorkerShift_ReturnListOfWorkers()
        {
            //Arrange
            Worker worker = new Worker() { Id = 1, Name = "Joshua" };
            Shift shift = new Shift() { Id = 1, StartHour = 0, EndHour = 8 };
            WorkerShift obj = new WorkerShift() { Id = 1, WorkerId = worker.Id, ShiftId = shift.Id, ShiftDay = DateTime.Now.AddDays(2) };


            //Act
            WorkerServices _workerServices = new WorkerServices();
            var result = await _workerServices.AssignWorkerToShift(obj); //And A New Shift

            Worker worker2 = new Worker() { Id = 1, Name = "Joshua" };
            await _workerServices.AddWorker(worker2); //Add The First Shift


            Shift shift2 = new Shift() { Id = 2, StartHour = 9, EndHour = 17 };
            await _workerServices.AddShift(shift2); //Add The First Shift

            WorkerShift obj2 = new WorkerShift() { Id = 1, WorkerId = worker.Id, ShiftId = shift.Id, ShiftDay = DateTime.Now.AddDays(2) };

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _workerServices.AssignWorkerToShift(obj2)); //Add the Second Shift with the Same Id as the first ;-

        }



    }
}
