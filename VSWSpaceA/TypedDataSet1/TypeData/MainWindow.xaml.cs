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
using TypeData.DataSet1TableAdapters;
using TypeData.DataSet2TableAdapters;

namespace TypeData
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
        DataSet1 ds;
        private void lstDataGrid_Click(object sender, RoutedEventArgs e)
        {
           
            
            StudentsTableAdapter dstu = new StudentsTableAdapter();
            CoursesTableAdapter da = new CoursesTableAdapter();
            try
            {
                dstu.Fill(ds.Students);
                lstDataGrid1.ItemsSource = ds.Students.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
          
            StudentsTableAdapter dstu = new StudentsTableAdapter();
            CoursesTableAdapter da = new CoursesTableAdapter();
            try
            {
                dstu.Update(ds.Students);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ds = new DataSet1();
        }
    }
}
