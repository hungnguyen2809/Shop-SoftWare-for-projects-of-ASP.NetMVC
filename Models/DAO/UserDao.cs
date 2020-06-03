using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class UserDao
    {
        ShopSoftWareDbContext dbContext = null;
        public UserDao()
        {
            dbContext = new ShopSoftWareDbContext();
        }

        public int LoginSystem(string username, string password)
        {
            var model = dbContext.User.SingleOrDefault(x => x.Username == username);

            if (model == null)
            {
                return 0; //tương ứng tài khoản không tồn tại
            }
            else if (model.Status == false)
            {
                return -1; //tương ứng tài khoản đang bị khóa, không kích hoạt
            }
            else if (model.Permission == false)
            {
                return -3;
            }
            else if (model.Password == password)
            {
                return 1; //đăng nhập thành công
            }
            else
            {
                return -2; // đăng nhập không thành công
            }
        }

        public int LoginCustomer(string username, string password)
        {
            var model = dbContext.User.SingleOrDefault(x => x.Username == username);

            if (model == null)
            {
                return 0; //tương ứng tài khoản không tồn tại
            }
            else if (model.Status == false)
            {
                return -1; //tương ứng tài khoản đang bị khóa, không kích hoạt
            }           
            else if (model.Password == password)
            {
                return 1; //đăng nhập thành công
            }
            else
            {
                return -2; // đăng nhập không thành công
            }
        }

        public User GetUserByUsernameAndPass(string username, string password)
        {
            return dbContext.User.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
        }

        public IEnumerable<User> GetAllPagingUser(string name, int page, int pageSize)
        {
            IQueryable<User> model = dbContext.User;
            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(x => x.Username.ToLower().Contains(name.ToLower()) || x.Name.ToLower().Contains(name.ToLower()));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool InsertUser(User model)
        {
            try
            {
                dbContext.User.Add(model);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(User model)
        {
            try
            {
                var user = dbContext.User.Find(model.ID);
                if(user.Username.ToLower() != model.Username.ToLower())
                {
                    user.CreateDate = DateTime.Now;
                }
                user.Username = model.Username;
                user.Name = model.Name;
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Permission = model.Permission;
                user.ModifiDate = model.ModifiDate;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByID(long id)
        {
            return dbContext.User.Where(x => x.ID == id).SingleOrDefault();
        }

        public bool CheckUsername(string username)
        {
            var res = dbContext.User.Where(x => x.Username.ToLower() == username.ToLower()).SingleOrDefault();
            //res == null -> không tồn tại user đó -> có thể thêm mới
            if(res == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUserByID(long id)
        {
            try
            {
                var user = dbContext.User.Find(id);
                dbContext.User.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = dbContext.User.Find(id);
            user.Status = !user.Status;
            dbContext.SaveChanges();
            return dbContext.User.Find(id).Status;
        }

        public long GetIDUserByUsernameAndPassword(string username, string password)
        {
            return dbContext.User.Where(x => x.Username == username && x.Password == password).Select(x => x.ID).SingleOrDefault();
        }
    }
}
