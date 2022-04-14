﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    internal interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public List<Product> GetProductsByDepartment(int id);
        public List<Product> GetProductsBySubdepartment(int id);
    }
}
