using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Models
{
    public class Prices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public double LoadingAndCounting { get; set; }
        public double Transport { get; set; }
        public double Risk { get; set; }
        public double AlternativePrice { get; set; }

        //RelationShips
        public string AtmId { get; set; }
        public Atm Atm { get; set; }

        //Methods
        public void Update(Prices p)
        {
            LoadingAndCounting = p.LoadingAndCounting;
            Transport = p.Transport;
            Risk = p.Risk;
            AlternativePrice = p.AlternativePrice;
        }

    }
}
