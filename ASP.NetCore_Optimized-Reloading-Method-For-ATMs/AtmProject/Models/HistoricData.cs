using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Models
{
    public class HistoricData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string TID { get; set; }
        public DateTime EventDate { get; set; }
        public int PreviousPeriodID { get; set; }
        public DateTime PreviousLoad { get; set; }
        public int PreviousDeposit { get; set; }
        public int PreviousWithdraw { get; set; }
        public int PreviousTransactionCount { get; set; }
        public int PeriodID { get; set; }
        public DateTime LoadDate { get; set; }
        public int Deposit { get; set; }
        public int Withdraw { get; set; }
        public int TransactionCount { get; set; }

        //RelationShips
        public string AtmId { get; set; }
        public Atm Atm { get; set; }
    }


}
