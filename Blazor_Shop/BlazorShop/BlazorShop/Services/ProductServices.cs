using BlazorShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Services
{
    public class ProductServices
    {
        private readonly ApplicationDbContext _db;

        public ProductServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int Id)
        {
            Product obj = new Product();
            return _db.Products.Include(c => c.Category).FirstOrDefault(c => c.Id == Id);
        }

        public List<Product> GetProduct()
        {
            
            return _db.Products.Include(c=>c.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {

            return _db.Categories.ToList();
        }
        public bool CreateProduct(Product objproduct)
        {
            _db.Products.Add(objproduct);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product objproduct)
        {
            var catfromdb = _db.Products.FirstOrDefault(c => c.Id == objproduct.Id);
            if (catfromdb != null)
            {
                if (objproduct.Image == null)
                {
                    objproduct.Image = catfromdb.Image;
                }
                _db.Products.Update(objproduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
           
            return true;
        }

        public bool DeleteProduct(Product objproduct)
        {
            var catfromdb = _db.Products.FirstOrDefault(c => c.Id == objproduct.Id);
            if (catfromdb != null)
            {
                _db.Products.Remove(catfromdb);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }



    }
}
