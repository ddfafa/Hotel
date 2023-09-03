using Hotel.Features;
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

namespace Hotel
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Api.RegistrationToSystem(TextBox1.Text, TextBox2.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Api.LoginToSystem(TextBox1.Text, TextBox2.Text);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Вы зашли в режиме гостя");
            Hotel.Window1 newform = new Hotel.Window1();
            newform.Show();
        }
    }
}
