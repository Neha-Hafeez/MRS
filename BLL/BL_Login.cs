using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DAL;

namespace WebApplication2.BLL
{
    public class BL_Login
    {
        public int ValidateLogin(string username, string password)
        {
            DL_Login dl_login = new DL_Login();
            return dl_login.ValidateLogin(username, password);
        }
    }
}