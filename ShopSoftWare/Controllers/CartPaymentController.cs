using Models.DAO;
using Models.EF;
using ShopSoftWare.Common;
using ShopSoftWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopSoftWare.Controllers
{
    public class CartPaymentController : Controller
    {
        // GET: CartPayment
        public ActionResult Index()
        {
            var cartItems = Session[CommonConstants.CART_SECSSION];
            var listItems = new List<CartItem>();
            if (cartItems != null)
            {
                listItems = (List<CartItem>)cartItems;
            }
            return View(listItems);
        }

        public ActionResult AddItem(string id, int quantity)
        {
            var cartItem = Session[CommonConstants.CART_SECSSION];
            var sanpham = new ProductDao().GetProductByID(id);

            if (cartItem != null)
            {
                var listItem = (List<CartItem>)cartItem;
                //nếu đã tồn tại sản phẩm rồi thì cộng thêm số lượng
                if (listItem.Exists(x => x.product.IDProduct == id))
                {
                    foreach (var item in listItem)
                    {
                        if (item.product.IDProduct == id)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    //chưa tồn tại sản phẩm mà trong giỏ hàng đã có 1 sản phẩm nào khác
                    var items = new CartItem();
                    items.product = sanpham;
                    items.quantity = quantity;

                    listItem.Add(items);
                }

                //gán giá trị list là danh sách các mặt hàng vào session để lưu giá trị
                Session[CommonConstants.CART_SECSSION] = listItem;
            }
            else
            {
                var item = new CartItem();
                var listItem = new List<CartItem>();

                item.product = sanpham;
                item.quantity = quantity;

                listItem.Add(item);

                Session[CommonConstants.CART_SECSSION] = listItem;

            }
            return Redirect("/gio-hang");
        }

        public JsonResult Update(string cartModel)
        {
            //cartModel trùng với tên phía name của Ajax vì nó là nơi lấy và chứa dữ liệu khi mà nó gửi diều hướng về.
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);

            var sectionCart = (List<CartItem>)Session[CommonConstants.CART_SECSSION];

            foreach (var item in sectionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.IDProduct == item.product.IDProduct);

                if (jsonItem != null)
                {
                    item.quantity = jsonItem.quantity;
                }
            }

            Session[CommonConstants.CART_SECSSION] = sectionCart;

            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cartProduct = Session[CommonConstants.CART_SECSSION];
            var listItem = new List<CartItem>();

            if (cartProduct != null)
            {
                listItem = (List<CartItem>)cartProduct;
            }

            var custommerSession = Session[CommonConstants.CUSTOMER_SECSION];
            var customer = new Customer();

            if (custommerSession != null)
            {
                customer = (Customer)custommerSession;
            }

            ViewBag.InforCustomer = customer;

            return View(listItem);
        }

        public JsonResult Payment(string name, string address, string phone, string email, string request)
        {
            var cartProduct = Session[CommonConstants.CART_SECSSION];
            var listItem = new List<CartItem>();
            var customerSession = Session[CommonConstants.CUSTOMER_SECSION];

            long idCustomer = -1; //khách hàng đó không có đăng ký tài khoản người dùng -> để tránh bị null idCustomer khi thêm dữ liệu vào Order

            if (customerSession != null)
            {
                var customer = new Customer();
                customer = (Customer)customerSession;
                idCustomer = new UserDao().GetIDUserByUsernameAndPassword(customer.Username, customer.Password);
            }

            if (cartProduct != null)
            {
                listItem = (List<CartItem>)cartProduct;
            }

            var orderDao = new OrderDao();

            try
            {
                var order = new Order();
                order.CustomerID = idCustomer;
                order.OrderName = name;
                order.OrderAddress = address;
                order.OderPhone = phone;
                order.OrderEmail = email;
                order.OrderRequest = request;

                var idOrder = orderDao.InsertOrderandResultIDOrder(order);

                var orderDetailDao = new OrderDetailsDao();

                for (int i = 0; i < listItem.Count; i++)
                {
                    var orderDetails = new OrderDetails();

                    orderDetails.IDOrder = idOrder;
                    orderDetails.IDProduct = listItem[i].product.IDProduct;
                    orderDetails.NameProduct = listItem[i].product.NameProduct;
                    orderDetails.Price = listItem[i].product.Price;
                    orderDetails.Quantity = listItem[i].quantity;

                    orderDetailDao.InsertOrderDetails(orderDetails);
                }

                orderDao.UpdateStatusOrder(idOrder);

                Session[CommonConstants.CART_SECSSION] = null;

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

        public JsonResult Delete(string id)
        {
            var sectionCart = (List<CartItem>)Session[CommonConstants.CART_SECSSION];

            sectionCart.RemoveAll(x => x.product.IDProduct == id);

            Session[CommonConstants.CART_SECSSION] = sectionCart;

            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// Thanh toán thành công sẽ trả về View này
        /// </summary>
        /// <returns></returns>
        public ActionResult Success()
        {
            return View();
        }


        /// <summary>
        /// Thanh toán thất bại sẽ trả về View này
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
        
    }
}