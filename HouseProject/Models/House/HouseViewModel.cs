using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace HouseProject.Models.House
{
    public class HouseViewModel
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
