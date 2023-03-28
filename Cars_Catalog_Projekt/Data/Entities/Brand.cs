﻿namespace Cars_Catalog_Projekt.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        { }

        public Brand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
