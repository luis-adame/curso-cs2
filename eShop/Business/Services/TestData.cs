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
        private static List<Product> ProductList;

        private static List<Department> DepartmentList;

        private static List<Provider> ProviderList;

        public static List<Department> GetDepartmentData()
        {
            if (DepartmentList == null)
            {
                DepartmentList = new List<Department>
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

                foreach (var dept in DepartmentList)
                {
                    foreach (var subdept in dept.Subdepartments)
                    {
                        subdept.AddDepartment(dept);
                    }
                }
            }

            return DepartmentList;
        }
        
        public static List<Product> GetProductData()
        {
            if (ProductList == null)
            {
                ProductList = new List<Product>
                {
                    new Product("Tv Smart N5200", 10.5m, "Television Smart 50", "Samsung", "123456"),
                    new Product("Tv 234N", 20.05m, "Television LED", "Sharp ", "123456"),
                    new Product("Remote Control MM1", 20.05m, "Control remoto", "Samsung ", "123456")
                };

                var subdepartamento = GetDepartmentData().SelectMany(x => x.Subdepartments).FirstOrDefault(x => x.Name.Equals("Tvs"));

                if (subdepartamento != null)
                {
                    foreach (var producto in ProductList)
                    {
                        subdepartamento.AddProduct(producto);
                        producto.AddSubdepartment(subdepartamento);
                        producto.AddStock(50);
                    }
                }

                var productoNuevo = new Product("Microondas 2 en 1", 10.5m, "Microondas horno y calentador", "Oster", "4321");
                subdepartamento = GetDepartmentData().SelectMany(x => x.Subdepartments).FirstOrDefault(x => x.Name.Equals("Cocina"));
                subdepartamento?.AddProduct(productoNuevo);
                productoNuevo.AddSubdepartment(subdepartamento);
                ProductList.Add(productoNuevo);

                productoNuevo = new Product("Sofa New Divine", 20.05m, "Sofa reclinable", "Soniadores", "4321");
                subdepartamento = GetDepartmentData().SelectMany(x => x.Subdepartments).FirstOrDefault(x => x.Name.Equals("Sala"));
                subdepartamento?.AddProduct(productoNuevo);
                productoNuevo.AddSubdepartment(subdepartamento);
                ProductList.Add(productoNuevo);
            }

            return ProductList;
        }

        public static List<Provider> GetProvidersData()
        {
            if (ProviderList == null)
            {
                ProviderList = new List<Provider>();

                var p1 = new Provider("Gamesa", "proveedor@gamesa.com");
                p1.AddAddress("islas 123", "Mexicali");
                p1.AddPhoneNumber("6865555555");
                ProviderList.Add(p1);

                var p2 = new Provider("Levis", "proveedor@levis.com");
                p1.AddAddress("islas levis 123", "tijuana");
                p1.AddPhoneNumber("6645555555");
                ProviderList.Add(p2);

                var p3 = new Provider("mercado cuchita", "proveedor@chuchita.com");
                p1.AddAddress("islas chu 123", "tijuana");
                p1.AddPhoneNumber("6645555551");
                ProviderList.Add(p3);
            }

            return ProviderList;
        }
    }
}
