using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUDopt
{
    /// <summary>
    /// Interaction logic for DataReader.xaml
    /// </summary>
    public partial class DataReader : Window
    {
        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
        public DataReader()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "select * from Employees";
                     
            SqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                lstName.Items.Add(dr["EmpName"]);  //dr[0] 
            }
            MessageBox.Show("Displayed");
            dr.Close();
            con.Close();


        }

        private void btnDisplay2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Employees;select * from Department";

            SqlDataReader dr = cmd.ExecuteReader();

            lstName.Items.Add("EmployeeNames : ");

            while (dr.Read())
            {
                lstName.Items.Add(dr["EmpName"]);  //dr[0] 
            }

            dr.NextResult();

            lstName.Items.Add("Department Names : ");

            while (dr.Read())
            {
                lstName.Items.Add(dr[1]);  //dr[0] 
            }
            MessageBox.Show("Displayed");
            dr.Close();
            con.Close();
        }

        private void btnMars_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                lstName.Items.Add(dr["EmpName"]);
            }
            dr.Close();
            //MessageBox.Show(cn.State.ToString());
        }

        private SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees";
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //cn.Close();
            return dr;
        }

        private void btnMars1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Department";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                lstName.Items.Add(drDepts["DeptName"]);

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstName.Items.Add("    " + drEmps["EmpName"]);
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();
        }
    }
}
