using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories;
using Cars_Catalog_Projekt.Repositories.Interfaces;
using Cars_Catalog_Projekt.Services.Interfaces;

namespace Cars_Catalog_Projekt.Services
{
    public class ModelService : IModelService
    {
        private IModelRepository modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public void AddModel(CarModel model)
        {
            modelRepository.AddModel(model);

            //throw new NotImplementedException();
        }

        public void DeleteModel(int id)
        {
            modelRepository.DeleteModel(id);


            //throw new NotImplementedException();
        }

        public void EditModel(CarModel model)
        {
            modelRepository.EditModel(model);

            //throw new NotImplementedException();
        }

        public CarModel GetModelById(int id)
        {
            return modelRepository.GetModelById(id);

            //throw new NotImplementedException();
        }
    }
}
