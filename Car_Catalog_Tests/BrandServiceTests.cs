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
using System.Runtime;
using System.Xml.Linq;

namespace Car_Catalog_Tests
{
    public class BrandServiceTests
    {
        private ApplicationContext context;
        private BrandRepository brandRepository;
        private BrandService brandService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDb");

            context = new ApplicationContext(options.Options);
            brandRepository = new BrandRepository(context);
            brandService = new BrandService(brandRepository);
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

        public void VerifyBrandProperties(int id, string name)
        {
            Brand dbBrand = brandRepository.GetBrandById(id);
            Assert.AreEqual(id, dbBrand.Id);
            Assert.AreEqual(name, dbBrand.Name);

        }

        [Test]
        public void GetByIdShouldReturnCorrectBrand()
        {
            int id = 1;
            string name = "Brand";

            Brand brand = new Brand(id, name);
            brandRepository.AddBrand(brand);
            Assert.NotNull(brandService.GetBrandById(id));
            VerifyBrandProperties(id,name);
        }

        [Test]
        public void GetAllShouldReturnAllBrands()
        {
            Brand brand = new Brand(10, "NewBrand");
            brandService.AddBrand(brand);
            Assert.True(brandRepository.GetAll().Count() > 0);
        }

        [Test]
        public void CreateShouldWorkCorrectly()
        {
            int id = 2;
            string name = "Brand one";

            Brand brand = new Brand(id, name);
            brandService.AddBrand(brand);

            VerifyBrandProperties(id, name);
        }

        [Test]
        public void EditShouldWorkCorrectly()
        {
            int id = 3;
            Brand brand = new Brand(id,"BrandToEdit");
            brandRepository.AddBrand(brand);

            string name = "EditedBrand";

            brand.Name = name;

            brandService.EditBrand(brand);
            VerifyBrandProperties(id, name);
        }

        [Test]
        public void DeleteShouldRemoveBrandCorrectly()
        {
            int id = 4;
            string name = "Brand";

            Brand brand = new Brand(id,name);
            brandRepository.AddBrand(brand);

            brandService.DeleteBrand(id);

            Brand deletedBrand = brandRepository.GetBrandById(id);
            Assert.IsNull(deletedBrand);
        }


        
    }
}
