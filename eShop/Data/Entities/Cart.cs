using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Cart
    {
        private List<Product> ProductList = new List<Product>();

        public void AddProduct(Product productoNuevo)
        {
            ProductList.Add(productoNuevo);
        }

        public void RemoveProduct(Product producto)
        {
            ProductList.Remove(producto);
        }

        public void ClearCart()
        {
            ProductList.Clear();
        }

        public List<Product> GetProductsInCart()
        {
            return ProductList;
        }
    }
}
