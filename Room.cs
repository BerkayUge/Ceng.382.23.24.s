using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceng._382._23._24.s._202011055
{
    public class Room
    {
         public string RoomId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public record Room(string RoomId, string RoomName, int Capacity);


    }
}