﻿using Company.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.ServiceContracts
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string ProductName);
        Product GetProductByProductID(long ProductID);
        void InsertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(long ProductID);
    }
}
