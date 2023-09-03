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
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.Features
{
    internal class Api
    {
        public static string PathToFolder { get; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        public static bool LoginToSystem(string login, string password)
        {
            MessageBox.Show($"Login: {login}\nPassword: {password}");
            return true;
        }

        public static bool RegistrationToSystem(string login, string password)
        {
            User user = new User()
            {
                Login = login,
                Password = password,
                UserGroup = UserGroup.Guest
            };

            List<User> users = DeserializeUsers<User>("Users.txt");
             
            if (users.Contains(user))
            {
                MessageBox.Show("Этот пользователь существует");
                Hotel.Window1 newform = new Hotel.Window1();
                newform.Show();
            }
            else
            {
                MessageBox.Show("Этот пользователь не существует");
            }

            return true;
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
