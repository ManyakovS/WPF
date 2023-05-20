using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Classes
{
    internal class ShowSession
    {
        public ShowSession()
        {
        }

        //public ShowSession(string _time, string _date, int _cost, string _cinemaHall_title)
        //{
        //    ticket_cost = _cost;
        //    time = _time;
        //    date = _date;
        //    cinemaHall_title = _cinemaHall_title;
        //}

        public string cinemaHall_title { get; set; }
        public int ticket_cost { get; set; }
        public string time { get; set; }
        public string date { get; set; }

    }
}
