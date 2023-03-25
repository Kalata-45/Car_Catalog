using Cars_Catalog_Projekt.Data.Entities;

namespace Cars_Catalog_Projekt.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        // Get Brand by id
        Brand GetBrandById(int id);

        // Edit existing item
        void EditBrand(Brand brand);

        // Delete existing item
        void DeleteBrand(int id);

        // Add new item
        void AddBrand(Brand brand);
    }
}
