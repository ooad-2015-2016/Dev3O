using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DAL
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Required]
        public double Amount { get; set; }
        public BankAccount ToAccount { get; set; }
        public BankAccount FromAccount { get; set; }
        public Person Referent { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
