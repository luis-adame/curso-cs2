using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        public Boolean MenuCliente()
        {
            Console.Clear();
            Console.WriteLine("MENU COMPRAS CLIENTE");
            Console.WriteLine("1. Agregar productos al Carro");
            Console.WriteLine("2. Quitar productos del carro");
            Console.WriteLine("3. Realizar Compra");
            Console.WriteLine("4. Salir");

            switch (Console.ReadLine())
            {
                case "1": while (MenuBusqueda()) ;
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4": 
                    return false;
                default:
                    break;
            }

            return true;
        }

        private Boolean MenuBusqueda()
        {
            Console.Clear();
            Console.WriteLine("Seleccione el tipo de Búsqueda");
            Console.WriteLine("1. Por Departamento");
            Console.WriteLine("2. Por Subdepartamento");
            Console.WriteLine("3. Por Producto");
            Console.WriteLine("4. Salir");

            switch (Console.ReadLine())
            {
                case "1": ProductosPorDepartamento();
                    break;
                case "2": ProductosPorSubdepartamentos();
                    break;
                case "3": SeleccionaProducto(_productService.GetProducts());
                    break;
                case "4":
                    return false;
                default:
                    break;
            }

            return true;
        }

        public void ProductosPorDepartamento()
        {
            Console.Clear();
            Console.WriteLine("Seleccione un Departamento");

            var listaDepartamentos = _departmentService.GetDepartments();

            foreach (var dept in listaDepartamentos)
            {
                Console.WriteLine($"Id:{dept.Id}\tNombre:{dept.Name}");
            }

            var idCaptura = Console.ReadLine();
            try
            {
                if (!int.TryParse(idCaptura, out int idDepartamento))
                    throw new ApplicationException("No se encontró Departamento");

                var listaProductos = _productService.GetProductsByDepartment(idDepartamento);

                SeleccionaProducto(listaProductos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void ProductosPorSubdepartamentos()
        {
            Console.Clear();
            Console.WriteLine("Seleccione un Subdepartamento");

            var listaSubdepartamentos = _departmentService.GetSubdepartments();

            foreach (var subdepartamento in listaSubdepartamentos)
            {
                Console.WriteLine($"Id:{subdepartamento.Id}\tNombre:{subdepartamento.Name}");
            }

            var idCaptura = Console.ReadLine();
            try
            {
                if (!int.TryParse(idCaptura, out int idSubdepartamento))
                    throw new ApplicationException("No se encontró Subdepartamento");

                var listaProductos = _productService.GetProductsBySubdepartment(idSubdepartamento);

                SeleccionaProducto(listaProductos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SeleccionaProducto(List<Product> lista)
        {
            Console.Clear();
            Console.WriteLine("Seleccione un Producto");

            //var listaProductos = _productService.GetProducts();

            foreach (var producto in lista)
            {
                Console.WriteLine(producto);
            }

            var idCaptura = Console.ReadLine();

            try
            {
                if (!int.TryParse(idCaptura, out int idProducto))
                    throw new ApplicationException("No se encontró Subdepartamento");

                //Aqui se agrega el producto al carro
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListaCarrito()
        {

        }

        public void RealizarCompra()
        {

        }
    }
}
