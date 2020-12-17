using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day16CRUDhw.Models;

namespace Day16CRUDhw.Controllers
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

            
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    l1.Add(new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]) });
                }
                dr.Close();
                     
            con.Close();

            return View(l1);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            Employees l1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Employees where EmpNo = @EmpNo;";
            cmd.Parameters.AddWithValue("@EmpNo", id);
            try
            {
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                l1 = new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]) };
               
                dr.Close();

            }
            catch
            {
                return RedirectToAction("Index");
            }

            con.Close();

            return View(l1);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            Employees e1 = new Employees();

            return View(e1);
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(Employees e1)
        {
           
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connect;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Employees values ( @EmpNo, @EmpName, @Basic, @DeptNo);";

                cmd.Parameters.AddWithValue("@EmpNo", e1.EmpNo);
                cmd.Parameters.AddWithValue("@EmpName", e1.EmpName);
                cmd.Parameters.AddWithValue("@Basic", e1.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", e1.DeptNo);
            try
            {
                cmd.ExecuteNonQuery();

             }
              catch
                {
                     
                }
            con.Close();
            return RedirectToAction("Index");           
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            Employees l1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Employees where EmpNo = @EmpNo;";
            cmd.Parameters.AddWithValue("@EmpNo", id);
            try
            {
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                l1 = new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]) };

                dr.Close();

            }
            catch
            {
                return RedirectToAction("Index");
            }

            con.Close();

            return View(l1);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employees e1)
        {
            SqlConnection con = new SqlConnection();
                con.ConnectionString = connect;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update Employees set EmpName = @EmpName, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo;";

                cmd.Parameters.AddWithValue("@EmpNo",id);
                cmd.Parameters.AddWithValue("@EmpName", e1.EmpName);
                cmd.Parameters.AddWithValue("@Basic", e1.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", e1.DeptNo);
            try
            {
                cmd.ExecuteNonQuery();

             }
              catch
                {
                     
                }
            con.Close();
            return RedirectToAction("Index");
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            Employees l1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Employees where EmpNo = @EmpNo;";
            cmd.Parameters.AddWithValue("@EmpNo", id);
            try
            {
                int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                l1 = new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]) };

                dr.Close();

            }
            catch
            {
                return RedirectToAction("Index");
            }

            con.Close();

            return View(l1);

        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employees e1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from Employees where EmpNo = @EmpNo;";

            cmd.Parameters.AddWithValue("@EmpNo", id);

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {
                con.Close();
                return View(e1);
            }
            con.Close();
            return RedirectToAction("Index");
        }
    }
}
