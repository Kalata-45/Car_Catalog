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

        /*private Brand CreateBrand(int id, string name)
        {
            Brand brand = new Brand();

           
        }*/

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

        /*[Test] ToDO
        public void EditShouldWorkCorrectly()
        {
            int id = 3;
            int brandId = 2;
            Vechicle vechicle = new Vechicle(id, "vechicleToEdit", brandId);
            vechicleRepository.Addvechicle(vechicle);

            string name = "EditedModel";

            vechicle.Name = name;

            modelService.EditModel(vechicle);
            VerifyModelProperties(id, name, brandId);
        }*/

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
