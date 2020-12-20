using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
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
            cmd.CommandText = "select * from Users where Email = @email and Password = @password";
            
            cmd.Parameters.AddWithValue("@email", u1.Email);
            cmd.Parameters.AddWithValue("@password", u1.Password);
             
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]) };
                Session.Add("User",u1);
                return RedirectToAction("HomePage");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            Users u1 = new Users();
            List<SelectListItem> L1City = new List<SelectListItem>();

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
               L1City.Add( new SelectListItem { Text = dr["CityName"].ToString(), Value =dr["Id"].ToString() });
            }
            u1.City = L1City;

            return View(u1);
        }

        [HttpPost]
        public ActionResult Register(Users u1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Users values(@UserId, @FullName, @Password, @Email, @CiytId, @Phone)";
           
            cmd.Parameters.AddWithValue("@UserId", u1.UserId);
            cmd.Parameters.AddWithValue("@FullName", u1.FullName);
            cmd.Parameters.AddWithValue("@Password", u1.Password);
            cmd.Parameters.AddWithValue("@Email", u1.Email);
            cmd.Parameters.AddWithValue("@CiytId", u1.CityId);
            cmd.Parameters.AddWithValue("@Phone", u1.Phone);
            try
            {
                int i = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            return RedirectToAction("Index");
        }

        public ActionResult HomePage()
        {
            

            return View();
        }
        public ActionResult Details(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where UserId = @UserId";

            cmd.Parameters.AddWithValue("@UserId", id);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Users u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(), Password = dr["Password"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString() };

                return View(u1);
            }
            return RedirectToAction("HomePage");
        }
        public ActionResult Edit(int id=0)
        {
            Debug.WriteLine("Get Edit");
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where UserId = @UserId";

            cmd.Parameters.AddWithValue("@UserId", id);           

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Users u1 = new Users { UserId = Convert.ToInt32(dr["UserId"]), Email = dr["Email"].ToString(),Password = dr["Password"].ToString(), FullName = dr["FullName"].ToString(), CityId = Convert.ToInt32(dr["CityId"]), Phone = dr["Phone"].ToString() };

                return View(u1);
            }
            return RedirectToAction("HomePage");

        }
        [HttpPost]
        public ActionResult Edit(Users u1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Users set FullName=@FullName, Password=@Password, Email=@Email, CiytId=@CiytId, Phone=@Phone where UserId=@UserId)";

           // cmd.Parameters.AddWithValue("@UserId", u1.UserId);
            cmd.Parameters.AddWithValue("@FullName", u1.FullName);
            cmd.Parameters.AddWithValue("@Password", u1.Password);
            cmd.Parameters.AddWithValue("@Email", u1.Email);
            cmd.Parameters.AddWithValue("@CiytId", u1.CityId);
            cmd.Parameters.AddWithValue("@Phone", u1.Phone);
            try
            {
                int i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            return RedirectToAction("HomePage");
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