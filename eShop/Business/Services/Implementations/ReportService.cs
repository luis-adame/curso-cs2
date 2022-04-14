using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ordenes de compra con el estado pagado de los últimos 7 días.
//Ordenes de compra que abastecieron la silla.
//Ordenes de compra pendientes de pagar del proveedor Levis.
//Producto con unidades mas compradas.


namespace Business.Services.Implementations
{
    public class ReportService
    {
		private List<Product> ProductList = TestData.ProductList;

		public List<ProductReportDto> Top5Expensives()
		{
			return ProductList
				.OrderByDescending(c => c.Price)
				.Take(5)
				.Select(c => new ProductReportDto
				{
					Name = c.Name,
					Price = c.Price
				}).ToList();
		}

        public List<UnitReportDto> StockUnder5()
        {
            return ProductList
				.OrderBy(x => x.Stock)
				.Where(x => x.Stock <= 5)
				.Select(x => new UnitReportDto
                {
					Name = x.Name,
					Stock = x.Stock
                }).ToList();
        }

        public List<BProductReportDto> OrderByBrandNName()
        {
            return ProductList
				.OrderBy(x => x.Brand)
				.ThenBy(x => x.Name)
				.Select(x => new BProductReportDto
                {
					Name= x.Name,
					Brand = x.Brand
                }).ToList();
		}

		public List<PurchaseOrder> Pagados7(List<PurchaseOrder> listaCompras)
        {
			return listaCompras
				.Where(x => x.PurchaseDate >= DateTime.Now.AddDays(-7))
				.Where(x => x.Status == Data.Enums.PurchaseOrderStatus.Ready)
				.ToList();
        }

		public List<PurchaseOrder> StockComprado(List<PurchaseOrder> listaCompras, string producto)
        {
			return new List<PurchaseOrder>();
		}

		public List<PurchaseOrder> PendientesProveedor(List<PurchaseOrder> listaCompras, string proveedor)
        {
			return listaCompras
				.Where(x => x.Provider.Name.Equals(proveedor))
				.Where(x => x.Status == Data.Enums.PurchaseOrderStatus.Pending)
				.ToList();
		}

		public Product MasComprado(List<PurchaseOrder> listaCompras)
        {
			return null;
        }
	}
}
