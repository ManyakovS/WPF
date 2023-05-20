using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class Session
    {
        public int sessionId { get; set; }

        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public DateTime timeEnd { get; set; }

        public int filmId { get; set; }
        public virtual Film Film { get; set; }

        public int cinemaHallId { get; set; }
        public virtual CinemaHall cinemaHall { get; set; }


    }
}
