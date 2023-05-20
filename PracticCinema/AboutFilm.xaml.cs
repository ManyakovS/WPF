using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Windows.Threading;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using VideoLibrary;
using PracticCinema.Classes;

namespace PracticCinema
{
    /// <summary>
    /// Логика взаимодействия для AboutFilm.xaml
    /// </summary>
    public partial class AboutFilm : Page
    {
        public bool isPause = true;

        public static Asset asset;

        public static FileStream fs;

        public AboutFilm()
        {
            asset = PagePagination._asset;
            fs = PagePagination.fs;

            InitializeComponent();

            setAboutFilm();

            var aboutFilm = PracticCinemaEntities.GetContext().Asset.Where(a => a.filmId == asset.filmId).ToList();

            string link = aboutFilm.Find(a => a.description == "trailer") == null ? null :
                aboutFilm.Find(a => a.description == "trailer").link;
            if(link != null)
                getVideo(link);
            else
            {
                link = aboutFilm.Find(a => a.description == "aboutImg") == null ? null :
                aboutFilm.Find(a => a.description == "aboutImg").link;
                if (link != null)
                    image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(link);
                else
                    image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(asset.link);

            }



            List<Session> session = PracticCinemaEntities.GetContext().Session.Where(s => s.filmId == asset.filmId && s.date <= DateTime.Now).ToList();
            List<ShowSession> phonesList = new List<ShowSession>();

            foreach (var item in session)
            {
                ShowSession s = new ShowSession();

                s.time = item.time.ToString();
                s.date = item.date.ToString().Split(' ')[0];
                s.ticket_cost = (int)PracticCinemaEntities.GetContext().Ticket.First(t => t.sessionId == item.sessionId).cost;
                s.cinemaHall_title = PracticCinemaEntities.GetContext().CinemaHall.First(c => c.cinemaHallId == item.cinemaHallId).name.ToString();
                
                phonesList.Add(s);
            }
            phonesGrid.ItemsSource = phonesList;

        }

        void setAboutFilm() 
        { 
            film_description.Text = asset.Film.description;
            film_duration.Text = (asset.Film.duration / 60) + "h:" + (asset.Film.duration % 60) + "m";
            film_title.Text = asset.Film.name;
            film_rating.Text = asset.Film.rating.ToString();

        }

        async void getVideo(string url)
        {
            var youtube = new YoutubeClient();

            //var videoUrl = "https://www.youtube.com/watch?v=avz06PDqDbM";
            var videoUrl = url;

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

            var streamInfo = (MuxedStreamInfo)streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            var client = new HttpClient();
            var s = await client.GetStreamAsync(streamInfo.Url.ToString());
            fs = new FileStream("localfile.mp4", FileMode.OpenOrCreate);
            PagePagination.fs = fs;
            if (fs != null)
            {
                try
                {
                await s.CopyToAsync(fs);
                }
                catch (Exception)
                {
                }

                Uri path = new Uri(@"C:\Users\Пользователь\source\repos\PracticCinema\PracticCinema\bin\Debug\localfile.mp4");

                media.Source = path;
                media.Visibility = Visibility.Visible;
                Player_tool.Visibility = Visibility.Visible;
                media.Pause();
            }
            else
                image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(asset.link);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //media.Play();
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            if (isPause)
            {
                media.Play();
                Player_tool.Visibility = Visibility.Hidden;
            }
            else
            {
                media.Pause();
                Player_tool.Visibility = Visibility.Visible;
            }

            isPause = !isPause;
        }
    }
}


