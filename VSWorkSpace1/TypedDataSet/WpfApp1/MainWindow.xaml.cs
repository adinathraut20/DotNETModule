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
using WpfApp1.DataSet1TableAdapters;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet1 ds;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            ds = new DataSet1();
            DepartmentTableAdapter daDp = new DepartmentTableAdapter();
            daDp.Fill(ds.Department);

            EmployeesTableAdapter daEmp = new EmployeesTableAdapter();
            daEmp.Fill(ds.Employees);

            dglst.ItemsSource = ds.Employees.DefaultView;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTableAdapter daEmp = new EmployeesTableAdapter();
            daEmp.Update(ds.Employees);
        }

       
    }
}
