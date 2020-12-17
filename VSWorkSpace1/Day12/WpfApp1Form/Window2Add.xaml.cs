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
    /// Interaction logic for Window2Add.xaml
    /// </summary>
    public partial class Window2Add : Window
    {
        public Window2Add()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if ((!string.IsNullOrEmpty(txt1no.Text)) && (!string.IsNullOrEmpty(txt2no.Text)))
            {
              
                txtadd.Text = (Convert.ToInt32(txt1no.Text) + Convert.ToInt32(txt2no.Text)).ToString();
               
            }
            
            //MessageBox.Show(x.ToString());
           // int x = (Convert.ToInt32(txt1no.Text) + Convert.ToInt32(txt2no.Text));
           // txtadd.Text = x + "";
        }

        private void txt2no_TextChanged(object sender, TextChangedEventArgs e)
        {


            if ((!string.IsNullOrEmpty(txt1no.Text)) && (!string.IsNullOrEmpty(txt2no.Text)))
            {
                txtadd.Text = (Convert.ToInt32(txt1no.Text) + Convert.ToInt32(txt2no.Text)).ToString();
            }
            // MessageBox.Show(txt2no.Text);
            //  int y = (Convert.ToInt32(txt1no.Text) + Convert.ToInt32(txt2no.Text));
            //  txtadd.Text = y + "";
        }
    }
}
