using PracticCinema.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using static System.Windows.Forms.LinkLabel;

namespace PracticCinema.src
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        public List<ImageBrush> images = new List<ImageBrush>();

        public List<TextBlock> titles = new List<TextBlock>();

        public List<Grid> gr_films = new List<Grid>();

        public List<Film> _films = PracticCinemaEntities.GetContext().Film.OrderBy(film => film.filmId).ToList();

        public List<Asset> _assets = PracticCinemaEntities.GetContext().Asset.OrderBy(asset => asset.filmId).ToList();

        public List<Asset> avalilableFilms;



        public UserPage()
        {
            InitializeComponent();
            PagePagination._frame = frame;
            if(PagePagination._user.icon != "")
            {
                try
                {
                    icon.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(PagePagination._user.icon);
                }
                catch (Exception)
                {
                    icon.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("pack://application:,,,/PracticCinema;component/src/TestAvatar.png");
                }
            }

            PagePagination.openFilms();



        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            PagePagination.openFilms();
        }

        
    }
}
