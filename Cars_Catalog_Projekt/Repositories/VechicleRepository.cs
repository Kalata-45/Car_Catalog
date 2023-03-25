using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Repositories.Interfaces;

namespace Cars_Catalog_Projekt.Repositories
{
    public class VechicleRepository : IVechicleRepository
    {
        private ApplicationContext context;

        public VechicleRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void AddVechicle(Vechicle vechicle)
        {
            context.Vechicles.Add(vechicle);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteVechicle(int id)
        {
            context.Vechicles.Remove(GetVechicleById(id));
            context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void EditVechicle(Vechicle vechicle)
        {
            context.Vechicles.Update(vechicle);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Vechicle> GetAllVechicles()
        {
            return context.Vechicles.ToList();
            //throw new NotImplementedException();
        }

        public Vechicle GetVechicleById(int id)
        {
            return context.Vechicles.FirstOrDefault(v => v.Id == id);
            
            //throw new NotImplementedException();
        }
    }
}
