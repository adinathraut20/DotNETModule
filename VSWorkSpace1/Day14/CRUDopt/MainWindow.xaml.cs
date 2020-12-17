using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace CRUDopt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window  
    {
        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;User Id=sa;Password=sa";
            //Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trainings\JKDec20\Sample.mdf;Integrated Security=True;Connect Timeout=30

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into Employees (EmpName,Basic,DeptNo) values ('"+ txtName.Text +"',"+ txtBasic.Text +"," + txtDeptNo.Text + ")";
            MessageBox.Show(cmd.CommandText);
            try
            {
               int n = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted : "+n);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            //con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Employees set EmpName = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @id;";
            
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
            cmd.Parameters.AddWithValue("@id", txtEmpNo.Text);
            con.Open();

            try
            {
                int n = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated : "+n);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand("DeletePro",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtEmpNo.Text);

            try
            {
                int n = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted : "+n);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
