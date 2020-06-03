using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailsDao
    {
        ShopSoftWareDbContext dbContext = null;

        public OrderDetailsDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public bool InsertOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                dbContext.OrderDetails.Add(orderDetails);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OrderDetails> GetListOrderDetailsByIdOrder(long id)
        {
            return dbContext.OrderDetails.Where(x => x.IDOrder == id).ToList();
        }
    }
}
