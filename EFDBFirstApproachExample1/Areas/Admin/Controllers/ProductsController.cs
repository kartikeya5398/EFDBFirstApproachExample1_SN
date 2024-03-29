﻿//using EFDBFirstApproachExample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using EFDBFirstApproachExample1.Filter;
using Company.DataLayer;
using Company.DomainModels;
using Company.ServiceLayer;
using Company.ServiceContracts;

namespace EFDBFirstApproachExample1.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
            // GET: Admin/Products  
            CompanyDbContext db;
            IProductsService productsService;
        public ProductsController(IProductsService pService)
        {
            this.db = new CompanyDbContext();
            this.productsService = pService;
        }
            // GET: Products
            public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                ViewBag.search = search;
                //List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
                List<Product> products = productsService.SearchProducts(search);

                //Sorting 
                ViewBag.sortCol = SortColumn;
                ViewBag.iconClass = IconClass;

                if (ViewBag.sortCol == "ProductID")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")

                        products = products.OrderBy(temp => temp.ProductID).ToList();

                    else

                        products = products.OrderByDescending(temp => temp.ProductID).ToList();

                }
                else if (ViewBag.sortCol == "ProductName")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.ProductName).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.ProductName).ToList();
                    }
                }
                else if (ViewBag.sortCol == "Price")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.Price).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.Price).ToList();
                    }
                }
                else if (ViewBag.sortCol == "DateOfPurchase")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
                    }
                }
                else if (ViewBag.sortCol == "AvailabilityStatus")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                    }
                }
                else if (ViewBag.sortCol == "CategoryID")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.CategoryID).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.CategoryID).ToList();
                    }
                }
                else if (ViewBag.sortCol == "BrandID")
                {
                    if (ViewBag.iconClass == "fa-sort-asc")
                    {
                        products = products.OrderBy(temp => temp.BrandID).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(temp => temp.BrandID).ToList();
                    }
                }

                //Paging
                int NoOfRecordPerPage = 5;
                int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
                int NoOfRecordToSkip = (PageNo - 1) * NoOfRecordPerPage;
                ViewBag.PageNo = PageNo;
                ViewBag.NoOfPages = NoOfPages;
                products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
                return View(products);
            }

            public ActionResult Details(long id)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                //Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
                Product p = productsService.GetProductByProductID(id);
                return View(p);
            }

            public ActionResult Create()
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                ViewData["Categories"]= db.Categories.ToList();
                ViewBag.brands = db.Brands.ToList();
                return View();
            }

            [HttpPost]
            public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,DateOfPurchase,AvailabilityStatus,CategoryID,BrandID,Active,Photo")] Product p)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();

                if (ModelState.IsValid)
                {
                    if (Request.Files.Count >= 1)
                    {
                        var imgBytes = new Byte[] { };
                        try
                        {
                            var file = Request.Files[0];
                            imgBytes = new Byte[file.ContentLength + 1];
                            file.InputStream.Read(imgBytes, 0, file.ContentLength);
                            var stringImage = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                            p.Photo = stringImage;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            /*imgBytes = new Byte[file.ContentLength + 1];
                            file.InputStream.Read(imgBytes, 0, file.ContentLength);*/
                        }
                    }
                    //db.Products.Add(p);
                    //db.SaveChanges();
                    productsService.InsertProduct(p);
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.categories = db.Categories.ToList();
                    ViewBag.brands = db.Brands.ToList();
                    return View();
                }

                /*if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength - 1];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var stringImage = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = stringImage;

                }*/

            }

            public ActionResult Edit(long id)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                //Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
                Product existingProduct = productsService.GetProductByProductID(id);
                ViewBag.category = db.Categories.ToList();
                ViewBag.brands = db.Brands.ToList();
                return View(existingProduct);
            }

            [HttpPost]
            public ActionResult Edit(Product p)
            {
                if (ModelState.IsValid)
                {
                    //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                    Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                    existingProduct.ProductName = p.ProductName;
                    existingProduct.Price = p.Price;
                    existingProduct.DateOfPurchase = p.DateOfPurchase;
                    existingProduct.CategoryID = p.CategoryID;
                    existingProduct.BrandID = p.BrandID;
                    existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                    existingProduct.Active = p.Active;

                    if (Request.Files.Count >= 1)
                    {
                        var imgBytes = new Byte[] { };
                        try
                        {
                            var file = Request.Files[0];
                            imgBytes = new Byte[file.ContentLength + 1];
                            file.InputStream.Read(imgBytes, 0, file.ContentLength);
                            var stringImage = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                            existingProduct.Photo = stringImage;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            /*imgBytes = new Byte[file.ContentLength + 1];
                            file.InputStream.Read(imgBytes, 0, file.ContentLength);*/
                        }
                    }
                    //db.SaveChanges();
                    productsService.UpdateProduct(existingProduct);
                }
                    
                    return RedirectToAction("Index", "Products");
                
            }

            public ActionResult Delete(long id)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                //Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
                Product existingProduct = productsService.GetProductByProductID(id);
                return View(existingProduct);
            }

            [HttpPost]
            public ActionResult Delete(long id, Product p)
            {
                //EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
                //Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
                //db.Products.Remove(existingProduct);
                //db.SaveChanges();
                productsService.DeleteProduct(id);
                return RedirectToAction("Index", "Products");
            }
    }
}