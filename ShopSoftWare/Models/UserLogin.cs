using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSoftWare.Common
{
    [Serializable]
    public class UserLogin
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
    }
}