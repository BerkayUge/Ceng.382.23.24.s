using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceng._382._23._24.s._202011055
{
    public class Reservation
    {
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public string ReserverName { get; set; }
        public Room Room { get; set; }

        public record Reservation(DateTime Time, DateTime Date, string ReserverName, Room Room);
    }
}