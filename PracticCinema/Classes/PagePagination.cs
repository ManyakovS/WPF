using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PracticCinema.Classes
{
    internal class PagePagination
    {
        public static Frame _frame { get; set; }

        public static Asset _asset { get; set; }

        public static FileStream fs { get; set; }

        public static User _user { get; set; }


        public static void openFilms()
        {
            _frame.Navigate(new Uri("/Films.xaml", UriKind.Relative));
            if(fs != null)
            {
                fs.Dispose();
                fs = null;
            }
        }

        public static void openAboutFilm()
        {
            _frame.Navigate(new Uri("/AboutFilm.xaml", UriKind.Relative));
        }
    }
}
