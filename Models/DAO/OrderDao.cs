using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class OrderDao
    {
        ShopSoftWareDbContext dbContext = null;

        public OrderDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public long InsertOrderandResultIDOrder(Order model)
        {
            model.CreateDate = DateTime.Now;
            model.Status = false;

            dbContext.Order.Add(model);
            dbContext.SaveChanges();

            return model.ID;
        }

        public void UpdateStatusOrder(long id)
        {
            var model = dbContext.Order.Find(id);
            model.Status = true;
            dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetListOrder(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = dbContext.Order;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.OderPhone.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public Order GetOrderByID(long id)
        {
            return dbContext.Order.Where(x => x.ID == id).SingleOrDefault();
        }
    }
}
