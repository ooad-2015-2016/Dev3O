using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DAL
{
    public class BankAccount
    {
        [Key]
        public int BankAccountID { get; set; }
        [Required]
        public Person Owner { get; set; }
        [Required]
        public double Balance { get; set; }

    }
}
