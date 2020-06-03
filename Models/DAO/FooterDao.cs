using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FooterDao
    {
        ShopSoftWareDbContext dbContext = null;

        public FooterDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public Footer GetFooterByID(long id)
        {
            return dbContext.Footer.Find(id);
        }

        public bool UpdateFooter(Footer footer)
        {
            try
            {
                var model = dbContext.Footer.Find(footer.ID);

                model.Address = footer.Address;
                model.Phone = footer.Phone;
                model.Email = footer.Email;
                model.DayWorkforWeek = footer.DayWorkforWeek;
                model.TimeWork = footer.TimeWork;

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       /* public Footer TakeFooter(long id)
        {
            return dbContext.Footer.Where(x => x.ID == id).SingleOrDefault();
        }*/
    }
}
