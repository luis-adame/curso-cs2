using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TestData
    {
        public static List<Product> ProductList = new List<Product>
        {
            new Product(0, "Tv Smart N5200", 10.5m, "Television Smart 50", "Samsung", "123456"),
            new Product(1, "Tv 234N", 20.05m, "Television LED", "Sharp ", "123456"),
            new Product(2, "Remote Control MM1", 20.05m, "Control remoto", "Samsung ", "123456"),
            new Product(3, "Microondas 2 en 1", 10.5m, "Microondas horno y calentador", "Oster", "4321"),
            new Product(4, "Lavadora SN032", 20.05m, "Lavadora a 3 velocidades", "Mabe ", "4321")
        };

        public static List<Department> DepartmentList = new List<Department>
        {
            new Department("Electronicos", new List<Subdepartment>
            {
                new Subdepartment("Tvs"),
                new Subdepartment("Celulares"),
                new Subdepartment("Audio")
            }),
            new Department("Muebles", new List<Subdepartment>
            {
                new Subdepartment("Cocina"),
                new Subdepartment("Comedor"),
                new Subdepartment("Sala")
            }),
            new Department("Alimentos", new List<Subdepartment>
            {
                new Subdepartment("Lacteos"),
                new Subdepartment("Carnes frias"),
                new Subdepartment("Pastas")
            })
        };

        public static List<Provider> GetProviders()
        {
            var providers = new List<Provider>();

            var p1 = new Provider(1, "Gamesa", "proveedor@gamesa.com");
            p1.AddAddress("islas 123", "Mexicali");
            p1.AddPhoneNumber("6865555555");
            providers.Add(p1);

            var p2 = new Provider(2, "Levis", "proveedor@levis.com");
            p1.AddAddress("islas levis 123", "tijuana");
            p1.AddPhoneNumber("6645555555");
            providers.Add(p2);

            var p3 = new Provider(2, "mercado cuchita", "proveedor@chuchita.com");
            p1.AddAddress("islas chu 123", "tijuana");
            p1.AddPhoneNumber("6645555551");
            providers.Add(p3);

            return providers;
        }

        public static void InitProductList()
        {
            var subdepartamento = DepartmentList.SelectMany(x => x.Subdepartments).FirstOrDefault(x => x.Name.Equals("Tvs"));

            if (subdepartamento != null) {
                foreach (var producto in ProductList)
                {
                    subdepartamento.AddProduct(producto);
                    producto.AddSubdepartment(subdepartamento);
                    producto.AddStock(50);
                }
            }
        }
    }
}
