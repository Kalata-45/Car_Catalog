using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Catalog_Projekt.Data.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }

        public CarModel()
        { }

        public CarModel(int id, string name, int brandId)
        {
            Id = id;
            Name = name;
            BrandId = brandId;
        }
    }
}
