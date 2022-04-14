using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PurchaseOrder
    {
		public int Id { get; set; }
		public decimal Total { get; private set; }
		public DateTime PurchaseDate { get; set; }
		public Provider Provider { get; set; }
		public List<Product> PurchasedProducts { get; set; }
		public PurchaseOrderStatus Status { get; set; }

		private static int idSeed = 1;

		public PurchaseOrder(Provider provider, List<Product> purchasedProducts, DateTime? purchaseDate = null)
		{
			if (provider == null)
				throw new ArgumentNullException("El proveedor no puede ser vacio");

			if (purchasedProducts == null || !purchasedProducts.Any())
				throw new ArgumentNullException("Hay que agregar productos a la lista");

			Total = purchasedProducts.Sum(c => c.Price * c.Stock);
			Provider = provider;
			PurchasedProducts = purchasedProducts;
			PurchaseDate = purchaseDate ?? DateTime.Now;

			Status = PurchaseOrderStatus.Pending;
			Id = idSeed++;
		}

		public void ChangeOrderStatus(PurchaseOrderStatus status)
        {
			Status = status;
        }
	}
}
