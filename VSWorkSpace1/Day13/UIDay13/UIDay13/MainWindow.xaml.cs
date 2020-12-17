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

namespace UIDay13
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

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Add("Lamborgini");
            lstNames.Items.Add("Rolls Royce");
            lstNames.Items.Add("Ferrari");
            lstNames.Items.Add("Cadiallac");
            lstNames.Items.Add("Limo");
            lstNames.Items.Add("Bugatti");
        }
        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
/*            if (lstNames.Items.IsEmpty)
            {
                MessageBox.Show("Nothing to Select");
            }
            else
            {
                *//*var list = lstNames.SelectedItems;
                foreach(var i in list){
                    lstNames1.Items.Add(i);
                    lstNames.Items.Remove(i);
                }*//*
               // MessageBox.Show("Items Selected : "+ lstNames.SelectedItems.Count.ToString());
               
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lstNames.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nothing Selected");
            }
            else
            {
                foreach (var i in lstNames.SelectedItems)
                {
                    lstNames1.Items.Add(i);
                }
               foreach(var i in lstNames1.Items)
                {
                    lstNames.Items.Remove(i);
                }
                    
               
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lstNames.Items.Count == 0)
            {
                MessageBox.Show("Empty Selection");
            }
            else
            {
                foreach(var i in lstNames.Items)
                {
                    lstNames1.Items.Add(i);
                }
                lstNames.Items.Clear();
            
            }

            }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (lstNames1.Items.Count == 0)
            {
                MessageBox.Show("Empty Selection");
            }
            else
            {
                foreach (var i in lstNames1.Items)
                {
                    lstNames.Items.Add(i);
                }
                lstNames1.Items.Clear();

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (lstNames1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nothing Selected");
            }
            else
            {
                foreach (var i in lstNames1.SelectedItems)
                {
                    lstNames.Items.Add(i);
                }
                foreach (var i in lstNames.Items)
                {
                    lstNames1.Items.Remove(i);
                }


            }
        }
    }
}
