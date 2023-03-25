using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories.Interfaces;

namespace Cars_Catalog_Projekt.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private ApplicationContext context;

        public BrandRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void AddBrand(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteBrand(int id)
        {
            context.Brands.Remove(GetBrandById(id));
            context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void EditBrand(Brand brand)
        {
            context.Brands.Update(brand);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public Brand GetBrandById(int id)
        {
            return context.Brands.FirstOrDefault(b => b.Id == id);

            //throw new NotImplementedException();
        }
    }
}
