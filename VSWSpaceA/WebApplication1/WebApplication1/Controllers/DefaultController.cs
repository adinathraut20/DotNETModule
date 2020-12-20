using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
        // GET: Default
        public ActionResult Index()
        {
            List<Employees> l1 = new List<Employees>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Employees";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    l1.Add(new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]), EmailId = dr["EmailId"].ToString() });
                }
                dr.Close();


            }
            catch
            {

            }
            con.Close();

            return View(l1);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            Employees emp = new Employees();
            List<SelectListItem> l1 = new List<SelectListItem>();
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Department";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l1.Add(new SelectListItem{ Text = dr["DeptName"].ToString(), Value = dr["DeptNo"].ToString() });
            }
            emp.Departments = l1;
            return View(emp);
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(Employees emp = null)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connect;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Employees values ( @EmpNo, @EmpName, @Basic, @DeptNo, @EmailId );";
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                }
                catch
                {

                }
                con.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
