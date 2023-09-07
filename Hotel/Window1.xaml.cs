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
using Newtonsoft.Json;

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

        // Почему так много кнопок???
        private void DataView_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Поиск и фильтрация в чем то схожи... найти все элементы, которые подходят по значению
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Реализуй фильтрацию
            // Если не понимаешь смысла слова "фильтрация", то задумайся как её производить
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Сохранить значение всех элементов в таблице в файл
            List<Number> list = DataView.ItemsSource as List<Number>;

            Api.SerializeUsers<Number>(list, "Numbers.txt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Допустим я нажал на определенный столбец и хочу чтобы он отсортировался
            // Реализуй сортировку по выбранному столбцу
            List<Number> list = DataView.ItemsSource as List<Number>;

            DataView.ItemsSource = null;
            list.Sort((x, y) => x.Cost.CompareTo(y.Cost));
            DataView.ItemsSource = list;
        }

        private void EditDataGrid(object sender, DataGridCellEditEndingEventArgs e)
        {
            // вызывается при редактировании таблицы
            // как сделать так, чтобы он проверял не только нашу роль, но и её тоже
            // так чтобы он проверял наши права в соответствии с нашей ролью
            // если какое-то право позволяет редактировать или читать таблицу, то позволять или не позволять делать операцию
            // Подсказка User -> Role -> все булевые bool значения (они должны здесь проверяться)
            if (Api.CurrentUser.Role.UserGroup != UserGroup.Admin)
            {
                e.Cancel = true;
                MessageBox.Show("У вас недостаточно прав для редактирования данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                //var dataGrid = (DataGrid)sender;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Напиши код обновления DataGrid
        }
    }
}
