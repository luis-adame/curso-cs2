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
		public Boolean MenuAdministrador()
        {
			Console.Clear();
			Console.WriteLine("Elige una opcion:");
			Console.WriteLine("1. Agregar Producto");
			Console.WriteLine("2. Editar Producto");
			Console.WriteLine("3. Eliminar Producto");
			Console.WriteLine("4. Consultar Producto");
			Console.WriteLine("5. Consultar Productos");
			Console.WriteLine("6. Reportes");
			Console.WriteLine("7. Ordenes");
			Console.WriteLine("8. Salir");

			switch (Console.ReadLine())
			{
				case "1":
					AgregarProducto();
					break;
				case "2":
					EditarProducto();
					break;
				case "3":
					EliminarProducto();
					break;
				case "4":
					ConsultarProducto();
					break;
				case "5":
					ConsultarProductos();
					break;
				case "6":
					//MenuDeReportes();
					break;
				case "7":
					while(MenuOrdenes());
					break;
				case "8":
					return false;
				default:
					break;
			}

			return true;
		}

		private void AgregarProducto()
		{
			Console.Clear();
			Console.WriteLine("REGISTRAR PRODUCTO");
			Console.WriteLine("Seleccione Departamento");

			foreach (var departamento in _departmentService.GetDepartments())
			{
				Console.WriteLine($"{departamento.Id}\t{departamento.Name}");
			}

			var idDepartamentoCaptura = Console.ReadLine();

			if (!int.TryParse(idDepartamentoCaptura, out int idDepartamento))
				return;
			else if (_departmentService.GetDepartment(idDepartamento) == null)
				return;

			Console.Clear();
			Console.WriteLine("REGISTRAR PRODUCTO");
			Console.WriteLine("Seleccione Subdepartamento");

            foreach (var subdepartamento in _departmentService.GetSubdepartments(idDepartamento))
            {
				Console.WriteLine($"{subdepartamento.Id}\t{subdepartamento.Name}");
			}

			var idSubdepartamentoCaptura = Console.ReadLine();

			if (!int.TryParse(idSubdepartamentoCaptura, out int idSubdepartamento))
				return;
			else if (_departmentService.GetSubdepartment(idSubdepartamento) == null)
				return;

			Console.Clear();
			Console.WriteLine("REGISTRAR PRODUCTO");
			Console.WriteLine("Capture los datos del nuevo producto");

			Console.WriteLine("Nombre: ");
			var nameInput = Console.ReadLine();

			Console.WriteLine("Precio: ");
			var priceInput = Console.ReadLine();

			Console.WriteLine("Descripcion: ");
			var descriptionInput = Console.ReadLine();

			Console.WriteLine("Marca: ");
			var brandInput = Console.ReadLine();

			Console.WriteLine("Sku: ");
			var skuInput = Console.ReadLine();

			try
			{
				if (!decimal.TryParse(priceInput, out decimal priceAux))
					throw new ApplicationException("El precio no es válido");

				var product = new Product(nameInput, priceAux, descriptionInput, brandInput, skuInput);
				product.AddSubdepartment(_departmentService.GetSubdepartment(idSubdepartamento));

				_departmentService.GetSubdepartment(idSubdepartamento).AddProduct(product);
				_productService.AddProduct(product);

				Console.WriteLine("Producto agregado correctamente.");

				Console.ReadKey();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void EditarProducto()
		{
			Console.Clear();
			Console.WriteLine("EDITAR PRODUCTO");
			Console.WriteLine("Capture los valores de producto");

			Console.WriteLine("Id: ");
			var idInput = Console.ReadLine();

			Console.WriteLine("Nombre: ");
			var nameInput = Console.ReadLine();

			Console.WriteLine("Precio: ");
			var priceInput = Console.ReadLine();

			Console.WriteLine("Descripcion: ");
			var descriptionInput = Console.ReadLine();

			try
			{
				if (!int.TryParse(idInput, out int idAux))
				{
					throw new ApplicationException("El Id no es válido");
				}

				if (!decimal.TryParse(priceInput, out decimal priceAux))
				{
					throw new ApplicationException("El precio no es válido");
				}

				_productService.UpdateProduct(idAux, nameInput, priceAux, descriptionInput);
				Console.WriteLine("Producto editado correctamente.");

				Console.ReadKey();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void ConsultarProducto()
		{
			Console.Clear();
			Console.WriteLine("CONSULTA DE PRODUCTO");
			Console.WriteLine("Capture Id de producto");

			var idInput = Console.ReadLine();

			try
			{
				if (!int.TryParse(idInput, out int idAux))
					throw new ApplicationException("El Id no es válido");

				Product a = _productService.GetProduct(idAux);

				if (a != null)
					Console.WriteLine(a);
				else
					Console.WriteLine("No se encontró producto");

				Console.ReadKey();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			
		}

		private void EliminarProducto()
		{
			Console.Clear();
			Console.WriteLine("BAJA DE PRODUCTO");
			Console.WriteLine("Capture Id de Producto a eliminar");

			var idCaptura = Console.ReadLine();

			try
			{
				if (!int.TryParse(idCaptura, out int idAux))
					throw new ApplicationException("El Id no es válido");

				_productService.DeleteProduct(idAux);
				Console.WriteLine("Producto eliminado correctamente");

				Console.ReadKey();
			}
			catch (Exception e)
            {
				Console.WriteLine(e.Message);
            }
		}

		private void ConsultarProductos()
		{
			Console.Clear();
			Console.WriteLine("LISTA DE PRODUCTOS");

			List<Product> listaProductos = _productService.GetProducts();

			foreach (var a in listaProductos)
			{
				Console.Write($"Id:{a.Id}\tNombre:{a.Name}\tPrecio:{a.Price}\tStock:{a.Stock}\n");
			}

			Console.ReadKey();
		}
	}
}
