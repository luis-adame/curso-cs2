using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Department Department { get; private set; }
        public List<Product> Products { get; set; }
        private static int idSeed = 1;

        public Subdepartment(string name)
        {
            if (string.IsNullOrEmpty(name) == null)
                throw new ArgumentNullException("El nombre no puede estar vacio");

            Name = name;
            Products = new List<Product>();
            Id = idSeed++;
        }

        public void AddDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("Se requiere un Departamento");

            Department = department;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
