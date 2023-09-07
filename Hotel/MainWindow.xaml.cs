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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Api.RegistrationToSystem(sender, TextBox1.Text, TextBox2.Text); // Возможно передавать sender не имеет смысла, а может имеет и надо подумать с chatgpt
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Api.LoginToSystem(sender, TextBox1.Text, TextBox2.Text); // тоже самое
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Вы зашли в режиме гостя"); // Тут непонятно что делать с CurrentUser и лучше, чтобы он не был null и был Api.CurrentUser.UserGroup = UserGroup.Guest;
            Hotel.Window1 newform = new Hotel.Window1();
            newform.Show();
        }
    }
}
