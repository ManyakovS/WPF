using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class Place
    {
        public int placeId { get; set; }

        public int rowNumber { get; set; }
        public int placeNumber { get; set; }

        public int cinemaHallId { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }

    }
}
