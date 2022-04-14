using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public string Department { get; private set; }
        public Subdepartment Subdepartment { get; private set; }


        public Product(int id, string name, decimal price, string description, string brand, string sku, int stock = 1)
        {
            if (price < 0)
                throw new InvalidOperationException("El precio no puede ser menor a cero");

            if (price == 0)
                throw new InvalidOperationException("El precio no puede ser cero");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede estar vacio");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("La descripcion no puede estar vacio");

            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException("La marca no puede estar vacio");

            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException("El sku no puede estar vacio");

            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Sku = sku;
            Stock = stock;
        }
        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void AddSubdepartment(Subdepartment subdepartment)
        {
            if (subdepartment == null)
                throw new ArgumentNullException("Se requiere un subdepartamento");

            Subdepartment = subdepartment;
        }

        public override string ToString()
        {
            return $"Id:{Id}\tNombre:{Name}\tPrecio:{Price}\tDescripcion{Description}\tMarca:{Brand}\t{Subdepartment?.Name}\t{Subdepartment?.Department?.Name}";
        }

        public void AddStock(int quantity)
        {
            Stock += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            Stock -= quantity;
        }
    }
}
