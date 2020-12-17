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

namespace WpfApp1Form
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

        private void txtFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtFullName.Text = txtFname.Text + " " + txtLname.Text;
        }

        private void txtLname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Equals(txtFname.Text, ""))
                txtFullName.Text = txtLname.Text;
            else
            {
                txtFullName.Text = (txtFname.Text + " " + txtLname.Text);
            }
        }
    }
}
