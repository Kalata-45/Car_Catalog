using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories;
using Cars_Catalog_Projekt.Repositories.Interfaces;
using Cars_Catalog_Projekt.Services.Interfaces;

namespace Cars_Catalog_Projekt.Services
{
    public class BrandService : IBrandService
    {
        private IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void AddBrand(Brand brand)
        {
            brandRepository.AddBrand(brand);

            //throw new NotImplementedException();
        }

        public void DeleteBrand(int id)
        {
            brandRepository.DeleteBrand(id);


            //throw new NotImplementedException();
        }

        public void EditBrand(Brand brand)
        {
            brandRepository.EditBrand(brand);

            //throw new NotImplementedException();
        }

        public Brand GetBrandById(int id)
        {
            return brandRepository.GetBrandById(id);

            //throw new NotImplementedException();
        }
    }
}
