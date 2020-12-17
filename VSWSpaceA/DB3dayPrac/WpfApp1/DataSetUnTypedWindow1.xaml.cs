using System;
using System.Collections.Generic;
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
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DataSetUnTypedWindow1.xaml
    /// </summary>
    public partial class DataSetUnTypedWindow1 : Window
    {
        public DataSetUnTypedWindow1()
        {
            InitializeComponent();
        }

        string connect = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
        DataSet ds;
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Students";

            SqlDataAdapter da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds, "Students");
            lstGrid.ItemsSource = ds.Tables["Students"].DefaultView;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Students values ( @id, @Name, @Fees, @CourseId);";

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "id", SourceVersion = DataRowVersion.Original });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Fees", SourceColumn = "Fees", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@CourseId", SourceColumn = "CourseId", SourceVersion = DataRowVersion.Current });

            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = cmd;
            da.Update(ds,"Students");

         }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connect;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Students set Name = @Name, Fees = @Fees, CourseId = @CourseId where id = @id;";

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "id", SourceVersion = DataRowVersion.Original });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Fees", SourceColumn = "Fees", SourceVersion = DataRowVersion.Current });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@CourseId", SourceColumn = "CourseId", SourceVersion = DataRowVersion.Current });
           
            
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmd;
                da.Update(ds, "Students");

               
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

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Students where id = @id;";

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "id", SourceVersion = DataRowVersion.Original });
            
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = cmd;
                da.Update(ds, "Students");


            }
            catch (Exception ex)
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
            cmdU.CommandText = "update Students set Name = @Name, Fees = @Fees, CourseId = @CourseId where id = @id;";

            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "id", SourceVersion = DataRowVersion.Original });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@Fees", SourceColumn = "Fees", SourceVersion = DataRowVersion.Current });
            cmdU.Parameters.Add(new SqlParameter { ParameterName = "@CourseId", SourceColumn = "CourseId", SourceVersion = DataRowVersion.Current });

            SqlCommand cmdI = new SqlCommand();
            cmdI.Connection = con;
            cmdI.CommandType = CommandType.Text;
            cmdI.CommandText = "insert into Students values ( @id, @Name, @Fees, @CourseId);";

            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@id", SourceColumn = "id", SourceVersion = DataRowVersion.Original });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@Fees", SourceColumn = "Fees", SourceVersion = DataRowVersion.Current });
            cmdI.Parameters.Add(new SqlParameter { ParameterName = "@CourseId", SourceColumn = "CourseId", SourceVersion = DataRowVersion.Current });

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                //DataSet ds2 = ds.GetChanges(DataRowState.Added);
                da.UpdateCommand = cmdU;
                da.InsertCommand = cmdI;
                da.ContinueUpdateOnError = true;
                da.Update(ds, "Students");

                ds.AcceptChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ds.RejectChanges();
        }

        private void btnSerial_Click(object sender, RoutedEventArgs e)
        {
            ds.GetXml();
            ds.GetXmlSchema();
            ds.WriteXmlSchema("Ais.xsd");
            ds.WriteXml("aish1.xml", XmlWriteMode.DiffGram);
            MessageBox.Show("Serialization Done");
        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema("Ais.xsd");
                ds.ReadXml("aish1.xml", XmlReadMode.DiffGram);
                lstGrid.ItemsSource = ds.Tables["Students"].DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
