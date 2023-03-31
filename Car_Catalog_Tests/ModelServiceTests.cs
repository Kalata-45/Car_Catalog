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
    public class ModelServiceTests
    {
        private ApplicationContext context;
        private ModelRepository modelRepository;
        private ModelService modelService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDb");

            context = new ApplicationContext(options.Options);
            modelRepository = new ModelRepository(context);
            modelService = new ModelService(modelRepository);
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

        public void VerifyModelProperties(int id, string name,int brandId)
        {
            CarModel dbModel = modelRepository.GetModelById(id);
            Assert.AreEqual(id, dbModel.Id);
            Assert.AreEqual(name, dbModel.Name);
            Assert.AreEqual(brandId, dbModel.BrandId);

        }

        [Test]
        public void GetByIdShouldReturnCorrectModel()
        {
            int id = 1;
            string name = "Model";
            int brandId = 1;   

            CarModel model = new CarModel(id, name, brandId);
            modelRepository.AddModel(model);
            Assert.NotNull(modelService.GetModelById(id));
            VerifyModelProperties(id, name, brandId);
        }

        [Test]
        public void GetAllShouldReturnAllModelss()
        {
            CarModel model = new CarModel(10, "NewModel", 2);
            modelService.AddModel(model);
            Assert.True(modelRepository.GetAll().Count() > 0);
        }

        [Test]
        public void CreateShouldWorkCorrectly()
        {
            int id = 2;
            string name = "Model one";
            int brandId = 1;

            CarModel model = new CarModel(id, name, brandId);
            modelService.AddModel(model);

            VerifyModelProperties(id, name, brandId);
        }

        [Test]
        public void EditShouldWorkCorrectly()
        {
            int id = 3;
            int brandId = 2;
            CarModel model = new CarModel(id, "ModelToEdit", brandId);
            modelRepository.AddModel(model);

            string name = "EditedModel";

            model.Name = name;

            modelService.EditModel(model);
            VerifyModelProperties(id, name, brandId);
        }

        [Test]
        public void DeleteShouldRemoveBrandCorrectly()
        {
            int id = 4;
            string name = "Model";
            int brandId = 3;

            CarModel model = new CarModel(id, name, brandId);
            modelRepository.AddModel(model);

            modelService.DeleteModel(id);

            CarModel deletedModel = modelRepository.GetModelById(id);
            Assert.IsNull(deletedModel);
        }
    }
}
