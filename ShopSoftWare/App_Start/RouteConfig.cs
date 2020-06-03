using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopSoftWare
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login Admin",
                url: "admin",
                defaults: new { controller = "ADLogin", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin User",
                url: "admin/user",
                defaults: new { controller = "ADUser", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin User Create",
                url: "admin/user/create",
                defaults: new { controller = "ADUser", action = "CreateUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin User Edit",
                url: "admin/user/edit/{id}",
                defaults: new { controller = "ADUser", action = "EditUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Admin",
                url: "admin/product",
                defaults: new { controller = "ADProduct", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Admin Insert",
                url: "admin/product/insert",
                defaults: new { controller = "ADProduct", action = "InsertProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Admin Edit",
                url: "admin/product/edit/{id}",
                defaults: new { controller = "ADProduct", action = "EditProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Category Admin",
                url: "admin/category",
                defaults: new { controller = "ADCategory", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Category Admin Insert",
                url: "admin/category/insert",
                defaults: new { controller = "ADCategory", action = "InsertCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Category Admin Edit",
                url: "admin/category/edit/{id}",
                defaults: new { controller = "ADCategory", action = "EditCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Footer Admin",
                url: "admin/footer",
                defaults: new { controller = "ADFooter", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Footer Admin Edit",
                url: "admin/footer/edit/{id}",
                defaults: new { controller = "ADFooter", action = "EditFooter", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Order Cart Admin",
                url: "admin/order",
                defaults: new { controller = "ADOrderCart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Order Cart Details Admin",
                url: "admin/order/{id}",
                defaults: new { controller = "ADOrderCart", action = "OrderDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home User",
                url: "trang-chu",
                defaults: new { controller = "USHome", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Windows User",
                url: "key-windows",
                defaults: new { controller = "USProduct", action = "KeyWindow", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Office User",
                url: "key-office",
                defaults: new { controller = "USProduct", action = "KeyOffice", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Game User",
                url: "key-game",
                defaults: new { controller = "USProduct", action = "KeyGame", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Virrus User",
                url: "key-virus",
                defaults: new { controller = "USProduct", action = "KeyVirus", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Details Product",
                url: "chi-tiet-san-pham/{id}",
                defaults: new { controller = "USProduct", action = "DetailsProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "CartPayment", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Item In Cart",
                url: "them-gio-hang",
                defaults: new { controller = "CartPayment", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Payment Cart",
                url: "thanh-toan",
                defaults: new { controller = "CartPayment", action = "Payment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Create Account",
                url: "dang-ky",
                defaults: new { controller = "USAccount", action = "CreateAccount", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login Account",
                url: "dang-nhap",
                defaults: new { controller = "USAccount", action = "LoginCustomer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logout Account",
                url: "dang-xuat",
                defaults: new { controller = "USAccount", action = "LogoutCustomer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "thanh-toan-thanh-cong",
                defaults: new { controller = "CartPayment", action = "Success", id = UrlParameter.Optional }
            ); 

            routes.MapRoute(
                name: "Payment Error",
                url: "thanh-toan-that-bai",
                defaults: new { controller = "CartPayment", action = "Error", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "USHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
