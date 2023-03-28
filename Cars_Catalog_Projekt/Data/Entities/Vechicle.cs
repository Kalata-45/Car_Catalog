namespace Cars_Catalog_Projekt.Data.Entities
{
    public class Vechicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Displacement { get; set; }
        public int Performance { get; set; }
        public string DriveType { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public int DoorsCount { get; set; }

        public Vechicle()
        { }

        public Vechicle(int id, int modelId, int year, string color, int displacement, 
            int performance, string driveType, string fuel, string transmission, int doorsCount)
        {
            Id = id;
            ModelId = modelId;
            Year = year;
            Color = color;
            Displacement = displacement;
            Performance = performance;
            DriveType = driveType;
            Fuel = fuel;
            Transmission = transmission;
            DoorsCount = doorsCount;
                

        }


    }
}
