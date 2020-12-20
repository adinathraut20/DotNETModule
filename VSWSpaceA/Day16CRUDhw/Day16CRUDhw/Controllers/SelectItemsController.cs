using Day16CRUDhw.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day16CRUDhw.Controllers
{
    public class SelectItemsController : Controller
    {
        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";

        // GET: SelectItems
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

        // GET: SelectItems/Details/5
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

        // GET: SelectItems/Create
        public ActionResult Create()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            Employees e1 = new Employees();

            return View(e1);
        }

        // POST: SelectItems/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectItems/Edit/5
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
                //int i = cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                l1 = new Employees { EmpNo = Convert.ToInt32(dr["EmpNo"]), EmpName = dr["EmpName"].ToString(), Basic = Convert.ToDecimal(dr["Basic"]), DeptNo = Convert.ToInt32(dr["DeptNo"]) };

                dr.Close();

                cmd.CommandText = "Select * from Department";
                dr = cmd.ExecuteReader();
                dr.Read();
                l1.Departments = (List < Department >) dr["Departments"];
                dr.Close();


            }
            catch
            {
                return RedirectToAction("Index");
            }

            con.Close();

            return View(l1);
        }

        // POST: SelectItems/Edit/5
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

        // GET: SelectItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectItems/Delete/5
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
