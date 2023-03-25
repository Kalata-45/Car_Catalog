using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories.Interfaces;

namespace Cars_Catalog_Projekt.Repositories 
{
    public class ModelRepository : IModelRepository
    {
        private ApplicationContext context;

        public ModelRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void AddModel(Model model)
        {
            context.Models.Add(model);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteModel(int id)
        {
            context.Models.Remove(GetModelById(id));
            context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void EditModel(Model model)
        {
            context.Models.Update(model);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public Model GetModelById(int id)
        {
            return context.Models.FirstOrDefault(m => m.Id == id);

            //throw new NotImplementedException();
        }
    }
}
