using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface ICartService
    {
        public void AddProduct(Product product);
        public void removeProduct(Product product);

    }
}
