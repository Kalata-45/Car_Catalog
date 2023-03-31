using Cars_Catalog_Projekt.Data.Entities;

namespace Cars_Catalog_Projekt.Repositories.Interfaces
{
    public interface IModelRepository
    {
        // Get Model by id
        CarModel GetModelById(int id);

        // Get All
        IEnumerable<CarModel> GetAll();

        // Edit existing item
        void EditModel(CarModel model);

        // Delete existing item
        void DeleteModel(int id);

        // Add new item
        void AddModel(CarModel model);
    }
}
