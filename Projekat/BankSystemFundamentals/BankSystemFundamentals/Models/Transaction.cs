using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemFundamentals.Models
{
    class Transaction
    {
        public enum TransactionType { Whithdraw, Deposit, Transfer}
        public int TransactionID { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public float Amount { get; set; }
        public Member Sender { get; set; }
        public Member Receiver { get; set; }
        public Employee EmployeeThatApproved { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public Transaction() { }
    }
}
