using PracticCinema.Classes;
using PracticCinema.src;
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

namespace PracticCinema
{
    /// <summary>
    /// Логика взаимодействия для films.xaml
    /// </summary>
    public partial class films : Page
    {

        public List<ImageBrush> images = new List<ImageBrush>();

        public List<TextBlock> titles = new List<TextBlock>();

        public List<Grid> gr_films = new List<Grid>();


        public List<Film> _films = PracticCinemaEntities.GetContext().Film.OrderBy(film => film.filmId).ToList();

        public List<Asset> _assets = PracticCinemaEntities.GetContext().Asset.OrderBy(asset => asset.filmId).ToList();

        public List<Asset> avalilableFilms;

        public int visibleFilms = 8;


        public films()
        {
            InitializeComponent();
            preparingLists();
            avalilableFilms = _assets.Where(a => a.Film.rentalStart < DateTime.Now && a.Film.rentalEnd > DateTime.Now.AddDays(1) && a.description == "previewImg").ToList();
            showFilms(avalilableFilms);
        }

        private void GoToFilm1_Click(object sender, RoutedEventArgs e)
        {
            string name;
            try
            {
                name = (sender as Button).Name;
            }
            catch (Exception)
            {
                name = (sender as Hyperlink).Name;
            }

            int selected = int.Parse(name[4].ToString()) - 1;

            PagePagination._asset = avalilableFilms[selected];
            PagePagination.openAboutFilm();



        }

        private void preparingLists()
        {
            images.Add(film1_source); images.Add(film2_source); images.Add(film3_source); images.Add(film4_source);
            images.Add(film1_source); images.Add(film2_source); images.Add(film7_source); images.Add(film8_source);

            titles.Add(film1_title); titles.Add(film2_title); titles.Add(film3_title); titles.Add(film4_title);
            titles.Add(film5_title); titles.Add(film6_title); titles.Add(film7_title); titles.Add(film8_title);

            gr_films.Add(gr_film1); gr_films.Add(gr_film2); gr_films.Add(gr_film3); gr_films.Add(gr_film4);
            gr_films.Add(gr_film5); gr_films.Add(gr_film6); gr_films.Add(gr_film7); gr_films.Add(gr_film8);
        }

        private void showFilms(List<Asset> assets)
        {
            foreach (var grid in gr_films)
            {
                grid.Visibility = Visibility.Hidden;
            }

            int count = 0;
            foreach (var asset in assets)
            {
                if (asset.link != null)
                    try
                    {
                        images[count].ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(asset.link);

                    }
                    catch (Exception)
                    {
                        images[count].ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("pack://application:,,,/PracticCinema;component/src/DefaultPrev.png");
                    }

                string title = asset.Film.name;
                if (title.Length > 15)
                    title = title.Substring(0, 12) + "...";
                titles[count].Text = title;
                gr_films[count].Visibility = Visibility.Visible;
                count++;
            }
        }
    }
}
