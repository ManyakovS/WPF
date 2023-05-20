using PracticCinema.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PracticCinema
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text == "" && password.Password == "" && password2.Password == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (PracticCinemaEntities.GetContext().User.ToList().Find(u => u.email == email.Text) != null)
            {
                MessageBox.Show("Пользователь уже существует");
                return;
            }

            if (!RegexExamples.IsValidEmail(email.Text))
            {
                MessageBox.Show("Неверный формат email");
                return;
            }

            if (password.Password != password2.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (isStrengthPassword(password.Password))
            {
                var passwordHash = PasswordHash.CreatePasswordHash(password.Password);
                User user = new User
                {
                    email = email.Text,
                    passwordHash = passwordHash,
                    name = "",
                    lastName = "",
                    icon = ""
                };
                PracticCinemaEntities.GetContext().User.Add(user);
                try
                {
                    PracticCinemaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успех");
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
            }


        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }


        public static bool isStrengthPassword(string password)
        {
            var regex2 = new Regex(@"([a-zA-Z])");
            var regex1 = new Regex(@"([0 - 9])");
            var regex3 = new Regex(@"([!,@,#,$,%,^,&,*,?,_,~])");
            if (password.Length >= 8 && regex1.IsMatch(password) && regex2.IsMatch(password) && regex3.IsMatch(password))
            {
                return true;
            }
            MessageBox.Show("Пароль должен содеражать цифры, заглавные и прописные буквы, а также спецсимволы");
            return false;
        }
    }
}
