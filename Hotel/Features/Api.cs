using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace Hotel.Features
{
    internal class Api
    {
        public static User CurrentUser { get; set; } // Это пользователь, который зашел в систему
        public static string PathToFolder { get; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void RegistrationToSystem(object sender, string login, string password)
        {
            // Сделать проверку, что пользователь уже сущесвует в файле
            // Если пользователь существует, то выкидываем ошибку MessageBox.Show("Вы уже зарегестрированы");
            CurrentUser = new User()
            {
                Login = login,
                Password = password,
                Role = new Role()
            };

            // Добавлять пользователя в файл, если его не существует
            // Показываеть MessageBox.Show("Вы были зарегестрированы и вошли в систему с обычными правами.");
            // Произвести вход в систему...
            List<User> users = DeserializeUsers<User>("Users.txt");
            if (users.Contains(CurrentUser))
            {
                MessageBox.Show("Этот пользователь существует");
                Hotel.Window1 newform = new Hotel.Window1();
                newform.Show();
            }
            else
            {
                MessageBox.Show("Этот пользователь не существует");
            }
        }

        public static void LoginToSystem(object sender, string login, string password)
        {
            List<User> users = DeserializeUsers<User>("Users.txt");

            CurrentUser = new User();
            foreach(User user in users)
            {
                if (user.Login == login)
                {
                    if(user.Password == password)
                    {
                        CurrentUser = user;
                    }
                    else
                    {
                        MessageBox.Show("Пароль неверный.");
                    }
                }
            }
            // Как сделать проверку, если мы полностью прошли список, а нашего логина нет в нем???

            // Просто вход без надписи
            if (users.Contains(CurrentUser))
            {
                Hotel.Window1 newform = new Hotel.Window1();
                newform.Show();
            }
            else
            {
                MessageBox.Show("Этот пользователь не существует");
            }
        }

        public static string CheckDataBase(string txt)
        {
            var path = Path.Combine(PathToFolder, "DataBase");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, txt);
            if (!File.Exists(path))
            {              
                File.Create(path);
            }

            return path;
        }
      
        public static void SerializeUsers<T>(List<T> list, string txt)
        {
            string dbpath = CheckDataBase(txt);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(dbpath, json);
        }

        public static List<T> DeserializeUsers<T>(string txt)
        {
            string dbpath = CheckDataBase(txt);
            string json = File.ReadAllText(dbpath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
