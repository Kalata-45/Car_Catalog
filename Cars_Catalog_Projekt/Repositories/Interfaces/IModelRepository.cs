using Cars_Catalog_Projekt.Data.Entities;

namespace Cars_Catalog_Projekt.Repositories.Interfaces
{
    public interface IModelRepository
    {
        // Get Model by id
        Model GetModelById(int id);

        // Edit existing item
        void EditModel(Model model);

        // Delete existing item
        void DeleteModel(int id);

        // Add new item
        void AddModel(Model model);
    }
}
