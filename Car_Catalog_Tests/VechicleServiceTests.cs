using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories;
using Cars_Catalog_Projekt.Services;
using System.Net.Http.Headers;
using Cars_Catalog_Projekt.Repositories.Interfaces;
using Cars_Catalog_Projekt.Services.Interfaces;

namespace Car_Catalog_Tests
{
    public class VechicleServiceTests
    {
        private ApplicationContext context;
        private VechicleRepository vechicleRepository;
        private VechicleService vechicleService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDb");

            context = new ApplicationContext(options.Options);
            vechicleRepository = new VechicleRepository(context);
            vechicleService = new VechicleService(vechicleRepository);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        public void VerifyVechicleProperties(int id, int modelId, int year, string color,
            int displacement, int performance, string driveType, string fuel, string transmission,
            int doorsCount)
        {
            Vechicle dbVechicle = vechicleRepository.GetVechicleById(id);
            Assert.AreEqual(id, dbVechicle.Id);
            Assert.AreEqual(modelId, dbVechicle.ModelId);
            Assert.AreEqual(year, dbVechicle.Year);
            Assert.AreEqual(color, dbVechicle.Color);
            Assert.AreEqual(displacement, dbVechicle.Displacement);
            Assert.AreEqual(performance, dbVechicle.Performance);
            Assert.AreEqual(driveType, dbVechicle.DriveType);
            Assert.AreEqual(fuel, dbVechicle.Fuel);
            Assert.AreEqual(transmission, dbVechicle.Transmission);
            Assert.AreEqual(doorsCount, dbVechicle.DoorsCount);


        }

        [Test]
        public void GetByIdShouldReturnCorrectModel()
        {
            int id = 1;
            int modelId = 1;
            int year = 2000;
            string color = "red";
            int displacement = 1800;
            int performance = 120;
            string driveType = "front";
            string fuel = "diesel";
            string transmission = "manual";
            int doorsCount = 4;

            Vechicle vechicle = new Vechicle(id, modelId, year, color, displacement, performance,
              driveType, fuel, transmission, doorsCount);
            vechicleRepository.AddVechicle(vechicle);
            Assert.NotNull(vechicleService.GetVechicleById(id));
            VerifyVechicleProperties(id, modelId, year, color, displacement, performance,
              driveType, fuel, transmission, doorsCount);
        }

        [Test]
        public void GetAllShouldReturnAllVechicles()
        {
            Vechicle vechicle = new Vechicle(10, 2, 1999, "green", 1900, 130, "front", "diesel", 
                 "manual", 4);
            vechicleService.AddVechicle(vechicle);
            Assert.True(vechicleRepository.GetAllVechicles().Count() > 0);
        }

        [Test]
        public void CreateShouldWorkCorrectly()
        {
            int id = 1;
            int modelId = 1;
            int year = 2000;
            string color = "red";
            int displacement = 1800;
            int performance = 120;
            string driveType = "front";
            string fuel = "diesel";
            string transmission = "manual";
            int doorsCount = 4;

            Vechicle vechicle = new Vechicle(id, modelId, year, color, displacement, performance,
              driveType, fuel, transmission, doorsCount);
            vechicleService.AddVechicle(vechicle);

            VerifyVechicleProperties(id, modelId, year, color, displacement, performance,
              driveType, fuel, transmission, doorsCount);
        }

        [Test] 
        public void EditShouldWorkCorrectly()
        {
            int id = 3;
            Vechicle vechicle = new Vechicle(id, 2, 2000, "yellow", 2100,
                200, "front", "gasoline", "manual", 3 ) ;
            vechicleRepository.AddVechicle(vechicle);

            int modelId = 3;
            int year = 2001;
            string color = "red";
            int displacement = 1900;
            int performance = 90;
            string driveType = "4x4";
            string fuel = "diesel";
            string transmission = "automatic";
            int doorsCount = 4;

            vechicle.ModelId = modelId;
            vechicle.Year = year;
            vechicle.Color = color;
            vechicle.Displacement = displacement;
            vechicle.Performance = performance;
            vechicle.DriveType = driveType;
            vechicle.Fuel = fuel;
            vechicle.Transmission = transmission;
            vechicle.DoorsCount = doorsCount;


            vechicleService.EditVechicle(vechicle);
            VerifyVechicleProperties(id, modelId, year, color, displacement, performance, driveType,
                fuel, transmission, doorsCount);
        }

        [Test]
        public void DeleteShouldRemoveBrandCorrectly()
        {
            int id = 1;
            int modelId = 1;
            int year = 2000;
            string color = "red";
            int displacement = 1800;
            int performance = 120;
            string driveType = "front";
            string fuel = "diesel";
            string transmission = "manual";
            int doorsCount = 4;

            Vechicle vechicle = new Vechicle(id, modelId, year, color, displacement, performance,
              driveType, fuel, transmission, doorsCount);
            vechicleRepository.AddVechicle(vechicle);

            vechicleService.DeleteVechicle(id);

            Vechicle deletedVechicle = vechicleRepository.GetVechicleById(id);
            Assert.IsNull(deletedVechicle);
        }
    }
}
