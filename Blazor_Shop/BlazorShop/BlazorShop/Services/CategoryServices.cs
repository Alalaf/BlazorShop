using BlazorShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Services
{
    public class CategoryServices
    {
        private readonly ApplicationDbContext _db;

        public CategoryServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int Id)
        {
            Category obj = new Category();
            return _db.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public List<Category> GetCategory()
        {
            
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category objcategory)
        {
            _db.Categories.Add(objcategory);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(Category objcategory)
        {
            var catfromdb = _db.Categories.FirstOrDefault(c => c.Id == objcategory.Id);
            if (catfromdb != null)
            {
                catfromdb.Name = objcategory.Name;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
           
            return true;
        }

        public bool DeleteCategory(Category objcategory)
        {
            var catfromdb = _db.Categories.FirstOrDefault(c => c.Id == objcategory.Id);
            if (catfromdb != null)
            {
                _db.Categories.Remove(catfromdb);
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
