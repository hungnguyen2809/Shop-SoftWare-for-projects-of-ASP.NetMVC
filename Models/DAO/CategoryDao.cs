using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class CategoryDao
    {

        ShopSoftWareDbContext dbContext = null;
        public CategoryDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public string GetNameCategoryByID(string id)
        {
            return dbContext.Category.Where(x => x.IDCategory.ToLower() == id.ToLower()).Select(x => x.NameCategory).SingleOrDefault().ToString();
        }

        public List<Category> GetListCategory()
        {
            return dbContext.Category.ToList();
        }

        public IEnumerable<Category> GetAllPagingCategory(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = dbContext.Category;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameCategory.ToLower().Contains(searchString.ToLower()));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool ChangeStatus (string id)
        {
            var category = dbContext.Category.Find(id);
            category.Status = !category.Status;
            dbContext.SaveChanges();

            return dbContext.Category.Find(id).Status;
        }

        public int CountCategory()
        {
            return dbContext.Category.Count();
        }

        public bool InsertCategory(Category category)
        {
            try
            {
                dbContext.Category.Add(category);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category GetCategoryByID(string id)
        {
            return dbContext.Category.Find(id);
        }

        public bool UpdateCategory(Category entity, string id)
        {
            try
            {
                var category = dbContext.Category.Find(id);

                category.NameCategory = entity.NameCategory;
                category.ModifyDate = DateTime.Now;
                category.MetaTitle = entity.MetaTitle;
                category.Status = entity.Status;
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(string id)
        {
            try
            {
                var cate = dbContext.Category.Find(id);
                dbContext.Category.Remove(cate);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
