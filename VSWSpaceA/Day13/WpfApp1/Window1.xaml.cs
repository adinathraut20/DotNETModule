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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!(string.IsNullOrEmpty(txtNo1.Text)) && !(string.IsNullOrEmpty(txtNo2.Text)))
            {
                txtAdd.Text = (Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text)).ToString();
            }
            else{
                MessageBox.Show("Enter Values it cannot Empty");
            }
        }

        private void txtNo1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNo1.Text)) && !(string.IsNullOrEmpty(txtNo2.Text)))
            {
                txtAdd.Text = (Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text)).ToString();
            }
        }

        private void txtNo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNo1.Text)) && !(string.IsNullOrEmpty(txtNo2.Text)))
            {
                txtAdd.Text = (Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text)).ToString();
            }
        }
    }
}
