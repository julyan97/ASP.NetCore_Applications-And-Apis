using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Models
{
    public class Movie : BaseData
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

    }
}
