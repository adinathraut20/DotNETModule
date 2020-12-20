using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{

    public class HomeController : Controller
    {
        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
        public ActionResult Index()
        {
            Users u1 = new Users();
            return View(u1);
        }

        [HttpPost]
        public ActionResult Index(Users u1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where Email = @Email and Password = @Password";
            cmd.Parameters.AddWithValue("@Email", u1.Email);
            cmd.Parameters.AddWithValue("@Password", u1.Password);
            Users u2;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u2 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString() };
                Session.Add("User", u2);
                // Session["User"] = u1;

                if (u2.RememberMe)
                {
                    HttpCookie objCookie = new HttpCookie("ChocoChip");
                    objCookie.Expires = DateTime.Now.AddDays(1);
                    objCookie.Values["UserId"] = u1.UserId.ToString();
                    //objCookie.Values["key2"] = u1.Password.ToString();
                }

                dr.Close();
                con.Close();
                return RedirectToAction("HomePage");
            }
            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            Users u1 = new Users();
            List<SelectListItem> l1 = new List<SelectListItem>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from City";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l1.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString() });
            }
            dr.Close();
            con.Close();

            u1.City = l1;

            return View(u1);
        }
        [HttpPost]
        public ActionResult Register(Users u1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand("CreateUserPro",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", u1.UserId);
            cmd.Parameters.AddWithValue("@FullName", u1.FullName);
            cmd.Parameters.AddWithValue("@Password", u1.Password);
            cmd.Parameters.AddWithValue("@Email", u1.Email);
            cmd.Parameters.AddWithValue("@CityId", u1.CityId);
            cmd.Parameters.AddWithValue("@Phone", u1.Phone);
            
            int i = cmd.ExecuteNonQuery();

            con.Close();
            return RedirectToAction("Index");
        }

        public ActionResult HomePage()
        {
           
            HttpCookie objCookie = Request.Cookies["UserId"];
            if (objCookie != null)
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connect;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where UserId = @UserId";
                cmd.Parameters.AddWithValue("@UserId", objCookie.Values["UserId"]);
                Users u1;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString(), Password = dr["Password"].ToString() };
                    Session.Add("User", u1);
                    dr.Close();
                    con.Close();
                    return View(u1);
                }
                con.Close();
                return RedirectToAction("HomePage");

            }

            if ((Users)Session["User"] == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        

        public ActionResult Details(int id=0 )
        {
            if ((Users)Session["User"] == null)
            {
                return RedirectToAction("Index");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where UserId = @UserId";
            cmd.Parameters.AddWithValue("@UserId", id);
            Users u1;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString(), Password = dr["Password"].ToString() };
               
                dr.Close();
                con.Close();
                return View(u1);
            }
            con.Close();
            return RedirectToAction("HomePage");

        }

        public ActionResult Edit(int id=0)
        {
            if ((Users)Session["User"] == null)
            {
                return RedirectToAction("Index");
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            List<SelectListItem> l1 = new List<SelectListItem>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where UserId = @UserId";
            cmd.Parameters.AddWithValue("@UserId", id);
            Users u1;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString(), Password = dr["Password"].ToString() };
                dr.Close();
               /* cmd.CommandText = "select * from City";

                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    l1.Add(new SelectListItem { Text = dr1["CityName"].ToString(), Value = dr1["Id"].ToString() });
                }
                dr1.Close();*/
               
                con.Close();
                return View(u1);
            }
            con.Close();
            return RedirectToAction("HomePage");           
        }

        [HttpPost]
        public ActionResult Edit(Users u1)
        {
            if ((Users)Session["User"] == null)
            {
                return RedirectToAction("Index");
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand("UpdateUserPro", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", u1.UserId);
            cmd.Parameters.AddWithValue("@FullName", u1.FullName);
            cmd.Parameters.AddWithValue("@Password", u1.Password);
            cmd.Parameters.AddWithValue("@Email", u1.Email);
            cmd.Parameters.AddWithValue("@CityId", u1.CityId);
            cmd.Parameters.AddWithValue("@Phone", u1.Phone);

            int i = cmd.ExecuteNonQuery();

            con.Close();
            return RedirectToAction("HomePage");

        }

        public ActionResult Logout()
        {
            HttpCookie objCookie = Request.Cookies["ChocoChip"];
            /*if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies.Remove("UserId");
            }*/
            Session.Abandon();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}