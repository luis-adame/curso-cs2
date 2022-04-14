using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class CartService : ICartService
    {
        Cart carroCliente = new Cart();

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void removeProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
