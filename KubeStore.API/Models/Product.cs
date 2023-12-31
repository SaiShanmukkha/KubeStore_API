﻿namespace KubeStore.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public string Images { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

    }
}
