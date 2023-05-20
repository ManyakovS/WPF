using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class User
    {
        public int userId { get; set; }

        public string email { get; set; }
        public string passwordHash { get; set; }

        public int name { get; set; }
        public int lastName { get; set; }

        public string icon { get; set; }

    }
}
