namespace Cars_Catalog_Projekt.Data.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandsId { get; set; }

        public Model(int id, string name, int brandsId)
        {
            Id = id;
            Name = name;
            BrandsId = brandsId;
        }



    }
}
