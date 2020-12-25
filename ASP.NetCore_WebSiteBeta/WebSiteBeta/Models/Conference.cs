using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Conference
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string ConferenceName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Destination { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }



    }
}
