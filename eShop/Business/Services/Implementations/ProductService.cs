using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private List<Product> ProductList = TestData.ProductList;

        public ProductService()
        {
            TestData.InitProductList();
        }

        public List<Product> GetProducts()
        {
            return ProductList;
        }

        public Product GetProduct(int id)
        {
            return ProductList.FirstOrDefault(x => x.Id == id);
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var entity = ProductList.FirstOrDefault(c => c.Id == product.Id);

            if (entity != null)
                entity.Update(product.Name, product.Description, product.Price);
            else
                throw new ApplicationException("El producto no fue encontrado");
        }

        public void DeleteProduct(int id)
        {
            var entity = ProductList.FirstOrDefault(c => c.Id == id);

            if (entity != null)
                ProductList.Remove(entity);
            else
                throw new ApplicationException("El producto no fue encontrado");
        }

        public List<Product> GetProductsByDepartment(int id)
        {
            return ProductList.FindAll(x => x.Subdepartment.Department.Id == id);
        }

        public List<Product> GetProductsBySubdepartment(int id)
        {
            return ProductList.FindAll(x => x.Subdepartment.Id == id);
        }
    }
}
