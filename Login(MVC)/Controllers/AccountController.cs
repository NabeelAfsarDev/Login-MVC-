using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//add models
using Login_MVC_.Models;

//add sql namespace
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        // GET: Account
        [HttpGet]
        public ActionResult Login()  //change "Index" to "Login"
        {
            return View();
        }

        void connectionString()
        {
            // sets connection string
            con.ConnectionString = @"data source=.\SQLEXPRESS; database=LOGIN_MVC; integrated security = SSPI;";
        }

        [HttpPost]

        public ActionResult Verify(Account account)
        {
            connectionString(); //set connection string
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username ='" + account.Name + "' and password='"+ account.Password +"'";

            dr = com.ExecuteReader();
           
            if (dr.Read())
            {
                //user found/verified
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }

           

        }

    }
}