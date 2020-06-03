using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class ProductDao
    {
        ShopSoftWareDbContext dbContext = null;

        public ProductDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public IEnumerable<Product> GetAllPagingProduct(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = dbContext.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameProduct.ToLower().Contains(searchString.ToLower()));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public long GetCountProduct()
        {
            return dbContext.Product.Count();
        }

        public bool InsertProduct(Product entity)
        {
            try
            {
                dbContext.Product.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product GetProductByID(string id)
        {
            return dbContext.Product.Where(x => x.IDProduct == id).SingleOrDefault();
        }

        public bool UpdateProduct(Product product, string id)
        {
            try
            {
                var model = dbContext.Product.Find(id);

                model.NameProduct = product.NameProduct;
                model.IDCategory = product.IDCategory;
                model.Price = product.Price;
                model.Images = product.Images;
                model.Quantity = product.Quantity;
                model.ModifiDate = DateTime.Now;
                model.Status = product.Status;
                model.MetaTitle = product.MetaTitle;

                dbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProductByID(string id)
        {
            try
            {
                var product = dbContext.Product.Find(id);
                dbContext.Product.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> ListProductForHome(string idCategory)
        {
            return dbContext.Product.Where(x => x.IDCategory == idCategory).Take(3).OrderByDescending(x => x.CreateDate).ToList();
        }

        public IEnumerable<Product> GetListPagingProductForCategory(string IDCategory, int page, int pageSize)
        {
            IQueryable<Product> model = dbContext.Product;

            model = model.Where(x => x.IDCategory == IDCategory);

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public Product GetOneProductForIDCategory(string idCategory)
        {
            return dbContext.Product.Where(x => x.IDCategory == idCategory && x.Quantity > 0).OrderByDescending(x => x.CreateDate).Take(1).SingleOrDefault();
        }
    }
}
