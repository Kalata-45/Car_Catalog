using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Data.Entities;


namespace Cars_Catalog_Projekt.Services.Interfaces

{
    public interface IModelService
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
