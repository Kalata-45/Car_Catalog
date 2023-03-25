using Cars_Catalog_Projekt.Data.Entities;

namespace Cars_Catalog_Projekt.Repositories.Interfaces
{
    public interface IVechicleRepository
    {
        // Get all available 
        IEnumerable<Vechicle> GetAllVechicles();

        // Get Vechicle by id
        Vechicle GetVechicleById(int id);

        // Edit existing item
        void EditVechicle(Vechicle vechicle);

        // Delete existing item
        void DeleteVechicle(int id);

        // Add new item
        void AddVechicle(Vechicle vechicle);
    }
}
