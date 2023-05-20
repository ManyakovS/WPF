using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class Ticket
    {
        public int ticketId { get; set; }

        public string state { get; set; }
        public int cost { get; set; }

        public int sessionId { get; set; }
        public virtual Session session { get; set; }

        public int placeId  { get; set; }
        public virtual Place place { get; set; }

        public int userId  { get; set; }
        public virtual User user { get; set; }


    }
}
