using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticCinema.Models
{
    internal class Asset
    {
        public int assetId { get; set; }

        public string description { get; set; }
        public string link { get; set; }

        public int filmId { get; set; }
        public virtual Film film { get; set; }

    }
}
