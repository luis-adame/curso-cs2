using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
		private Boolean MenuDeReportes()
		{
			Console.Clear();
			Console.WriteLine("Elige una opcion:");
			Console.WriteLine("1. Top 5 de productos mas caros ordenados por precio mas alto");
			Console.WriteLine("2. Productos con 5 unidades o menos ordenados por unidades");
			Console.WriteLine("3. Nombre de productos por marcas ordenados por nombre de productos");
			Console.WriteLine("4. Agrupacion de departamentos con subdepartamentos y nombres de productos");
			Console.WriteLine("5. Regresar");

			switch (Console.ReadLine())
			{
				case "1": Top5ProductosMasCaros();
					break;
				case "2": Stock5OMenos();
					break;
				case "3": OrdenaMarcaYNombre();
					break;
				case "4":
					break;
				case "5": return false;
					
				default:
					break;
			}

			return true;
		}

		private void Top5ProductosMasCaros()
		{
			var data = _reportService.Top5Expensives();

			foreach (var dto in data)
			{
				Console.WriteLine($"{dto.Name} {dto.Price}");
			}

			Console.ReadLine();
		}

		private void Stock5OMenos()
        {
			var data = _reportService.StockUnder5();

            foreach (var dto in data)
            {
				Console.WriteLine($"{dto.Name} {dto.Stock}");
            }

			Console.ReadLine();
        }

		private void OrdenaMarcaYNombre()
		{
			var data = _reportService.OrderByBrandNName();

			foreach (var dto in data)
			{
				Console.WriteLine($"{dto.Brand} {dto.Name}");
			}

			Console.ReadLine();
		}
	}
}
