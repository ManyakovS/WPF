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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using PracticCinema.Classes;
using PracticCinema.src;

namespace PracticCinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text == "" && password.Password == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            var user = PracticCinemaEntities.GetContext().User.ToList().Find(u => u.email == email.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            if(PasswordHash.VerifyPassword(password.Password, user.passwordHash))
            {
                MessageBox.Show("Успех");
                PagePagination._user = user;
                UserPage page = new UserPage();
                page.Show();
                this.Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль");



        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SignUp window = new SignUp();
            window.Show();
            this.Close();
        }

    }
}
