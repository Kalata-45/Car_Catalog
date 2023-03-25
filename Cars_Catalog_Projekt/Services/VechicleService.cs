using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Data;
using Cars_Catalog_Projekt.Services.Interfaces;
using Cars_Catalog_Projekt.Repositories.Interfaces;

namespace Cars_Catalog_Projekt.Services
{
    public class VechicleService : IVechicleService
    {
        private IVechicleRepository vechicleRepository;

        public VechicleService(IVechicleRepository vechicleRepository)
        {
            this.vechicleRepository = vechicleRepository;
        }
        public void AddVechicle(Vechicle vechicle)
        {
            vechicleRepository.AddVechicle(vechicle);
            
            //throw new NotImplementedException();
        }

        public void DeleteVechicle(int id)
        {
            vechicleRepository.DeleteVechicle(id);


            //throw new NotImplementedException();
        }

        public void EditVechicle(Vechicle vechicle)
        {
            vechicleRepository.EditVechicle(vechicle);
            
            //throw new NotImplementedException();
        }

        public IEnumerable<Vechicle> GetAllVechicles()
        {
            return vechicleRepository.GetAllVechicles();
            //throw new NotImplementedException();
        }

        public Vechicle GetVechicleById(int id)
        {
            return vechicleRepository.GetVechicleById(id);

            //throw new NotImplementedException();
        }
    }
}
