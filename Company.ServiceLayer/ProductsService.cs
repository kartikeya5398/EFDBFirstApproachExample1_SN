using Company.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DataLayer;
using Company.DomainModels;
using Company.RepositoryLayer;
using Company.RepositoryContracts;

namespace Company.ServiceLayer
{
    public class ProductsService : IProductsService
    {
        //CompanyDbContext db;
        IProductsRepository prodRepo;
        public ProductsService(IProductsRepository productsRepository)
        {
            this.prodRepo = productsRepository;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = prodRepo.GetProducts();
            return products;
        }
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = prodRepo.SearchProducts(ProductName);
            return products;
        }
        public Product GetProductByProductID(long ProductID)
        {
            Product p = prodRepo.GetProductByProductID(ProductID);
            return p;
        }
        public void InsertProduct(Product p)
        {
            //db.Products.Add(p);
            //db.SaveChanges();
            if (p.Price <= 1000000)
            {
                prodRepo.InsertProduct(p);
            }
            else
            {
                throw new Exception("Price Exceeds the Limit!!");
            }
            
        }
        public void UpdateProduct(Product p)
        {
            prodRepo.UpdateProduct(p);
        }
        public void DeleteProduct(long ProductID)
        {
            prodRepo.DeleteProduct(ProductID);
        }
    }
}
