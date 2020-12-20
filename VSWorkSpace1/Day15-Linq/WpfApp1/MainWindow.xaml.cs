using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataContext dbc = new EmployeeDataContext();
            Employee e1 = new Employee();
            try
            {
                e1.EmpNo = Convert.ToInt32(txtId.Text);
                e1.EmpName = txtName.Text.ToString();
                e1.Basic = Convert.ToDouble(txtBasic.Text);
                e1.DeptNo = Convert.ToInt32(txtDeptNo.Text);

                dbc.Employees.InsertOnSubmit(e1);
                dbc.SubmitChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtUpdate_Click(object sender, RoutedEventArgs e)
        {

            EmployeeDataContext dbc = new EmployeeDataContext();

            Employee e1 = dbc.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtId.Text));
            if (e1 != null)
            {
                try
                {

                    e1.EmpName = txtName.Text.ToString();
                    e1.Basic = Convert.ToDouble(txtBasic.Text);
                    e1.DeptNo = Convert.ToInt32(txtDeptNo.Text);

                    dbc.SubmitChanges();
                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Employee doesnt exist");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataContext dbc = new EmployeeDataContext();

            Employee e1 = dbc.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtId.Text));
            if (e1 != null)
            {
                try
                {
                    dbc.Employees.DeleteOnSubmit(e1);        
                    dbc.SubmitChanges();
                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Employee doesnt exist");
            }

        }

        private void btndisplay_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataContext dbc = new EmployeeDataContext();

            DataTable dt = dbc.Employees.ToDataTable();
            dt.Columns.Remove("Department");
            dgdata.ItemsSource = dt.DefaultView;

        }

    }

    public static class ListHelper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            DataTable dt = new DataTable();
            Type listType = list.ElementAt(0).GetType();
            //get element properties nad datatable columns 
            System.Reflection.PropertyInfo[] properties = listType.GetProperties();

            foreach (PropertyInfo property in properties)
                dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
            foreach (object item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                    dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                dt.Rows.Add(dr);
            }

            return dt;
        }

    }
}
