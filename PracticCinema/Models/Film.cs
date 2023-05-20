using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class Film
    {
        public int filmId { get; set; }

        public string time { get; set; }
        public string description { get; set;}
        public string genres { get; set; }
        public int duration { get; set;}
        public DateTime rentalStart { get; set;}
        public DateTime rentalEnd { get; set; }

        public decimal rating { get; set; }



    }
}
