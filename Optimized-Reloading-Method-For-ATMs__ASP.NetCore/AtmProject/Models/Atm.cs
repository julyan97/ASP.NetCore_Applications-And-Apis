using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Models
{
    public class Atm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string TID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        //RelationShips

        public List<HistoricData> HD { get; set; } = new List<HistoricData>();
        public List<Prices> Prices { get; set; } = new List<Prices>();

        //Methods
        public void Update(Atm p)
        {
            Name = p.Name;
            City = p.City;
        }
    }
}
