using Hotel.Features;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.IO;

namespace Hotel
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            List<Number> users = Api.DeserializeUsers<Number>("Numbers.txt");
            DataView.ItemsSource = users;
        }

        private void DataView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Сортировка списка в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Number> list = DataView.ItemsSource as List<Number>;

            DataView.ItemsSource = null;
            list.Sort((x, y) => x.Cost.CompareTo(y.Cost));
            DataView.ItemsSource = list;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Number> list = DataView.ItemsSource as List<Number>;

            Api.SerializeUsers<Number>(list, "Numbers.txt");
        }
    }
}
