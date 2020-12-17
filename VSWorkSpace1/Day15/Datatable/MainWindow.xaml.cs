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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datatable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
        DataSet ds;
        private void btnfill_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees;";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "Emp");
            dgEmp.ItemsSource = ds.Tables["Emp"].DefaultView;
            con.Close();


 
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Employees set EmpName = @name, Basic = @Basic, DeptNo = @deptNo where EmpNo = @id";

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@name", SourceColumn = "EmpName", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@deptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmd;
            da.Update(ds,"Emp");
           
            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values ( @EmpNo, @EmpName, @Basic, @DeptNo);";

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@EmpName", SourceColumn = "EmpName", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = cmd;
                MessageBox.Show(cmd.CommandText);
                da.Update(ds, "Emp");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

          
            SqlCommand cmdU = new SqlCommand();
            cmdU.Connection = con;
            cmdU.CommandType = CommandType.Text;
            cmdU.CommandText = "update Employees set EmpName = @name, Basic = @Basic, DeptNo = @deptNo where EmpNo = @id";

            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@name", SourceColumn = "EmpName", SourceVersion = DataRowVersion.Current });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@deptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdI = new SqlCommand();
            cmdI.Connection = con;
            cmdI.CommandType = CommandType.Text;
            cmdI.CommandText = "insert into Employees values ( @EmpNo, @EmpName, @Basic, @DeptNo);";

            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@EmpName", SourceColumn = "EmpName", SourceVersion = DataRowVersion.Current });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();

                // DataSet ds2 = ds.GetChanges();
                DataSet ds2 = ds.GetChanges(DataRowState.Added);
                //DataSet ds3 = ds.GetChanges(DataRowState.Modified);

                da.UpdateCommand = cmdU;

                da.InsertCommand = cmdI;

                // da.Update(ds, "Emp");

                da.Update(ds2, "Emp");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }
    }
}
