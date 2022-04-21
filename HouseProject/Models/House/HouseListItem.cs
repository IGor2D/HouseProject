using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseProject.Models.House
{
    public class HouseListItem
    {
        public Guid? Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Entrance { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Area { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifieAt { get; set; }

    }
}
