using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ClientPurchase
    {
        public int Id { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public List<Product> ProductList { get; private set; }
		public decimal Total { get; private set; }
		private static int idSeed = 0;

		public ClientPurchase(List<Product> purchasedProducts, DateTime? purchaseDate = null)
		{
			if (purchasedProducts == null || !purchasedProducts.Any())
				throw new ArgumentNullException("Hay que agregar productos a la lista");

			Total = purchasedProducts.Sum(c => c.Price * c.Stock);
			ProductList = purchasedProducts;
			PurchaseDate = purchaseDate ?? DateTime.Now;

			Id = idSeed++;
		}
	}
}
