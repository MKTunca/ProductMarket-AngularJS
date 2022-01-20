using ProductMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMarket.Controllers
{
    [_AdminControl]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get_AllProducts()
        {
            using (ProductsEntities Obj = new ProductsEntities())
            {
                List<ProductTable> Pro = Obj.ProductTable.ToList();
                return Json(Pro, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_ProductById(string Id)
        {
            using (ProductsEntities Obj = new ProductsEntities())
            {
                int ProId = int.Parse(Id);
                return Json(Obj.ProductTable.Find(ProId), JsonRequestBehavior.AllowGet);
            }
        }
        public string Insert_Product(ProductTable product)
        {
            if (product != null)
            {
                using (ProductsEntities Obj = new ProductsEntities())
                {
                    Obj.ProductTable.Add(product);
                    Obj.SaveChanges();
                    return "Product Added Successfully";
                }
            }
            else
            {
                return "Product Not Inserted! Try Again";
            }
        }
        public string Delete_Product(ProductTable Pro)
        {
            if (Pro != null)
            {
                using (ProductsEntities Obj = new ProductsEntities())
                {
                    var Pro_ = Obj.Entry(Pro);
                    if (Pro_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.ProductTable.Attach(Pro);
                        Obj.ProductTable.Remove(Pro);
                    }
                    Obj.SaveChanges();
                    return "Product Deleted Successfully";
                }
            }
            else
            {
                return "Product Not Deleted! Try Again";
            }
        }
        public string Update_Product(ProductTable Pro)
        {
            if (Pro != null)
            {
                using (ProductsEntities Obj = new ProductsEntities())
                {
                    var pro_ = Obj.Entry(Pro);
                    ProductTable proObj = Obj.ProductTable.Where(x => x.ID == Pro.ID).FirstOrDefault();
                    proObj.Name = Pro.Name;
                    proObj.Model = Pro.Model;
                    proObj.Category = Pro.Category;
                    proObj.Price = Pro.Price;
                    Obj.SaveChanges();
                    return "Product Updated Successfully";
                }
            }
            else
            {
                return "Product Not Updated! Try Again";
            }
        }
    }
}