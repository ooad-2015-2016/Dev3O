using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace App1.BankaBaza.Models
{
    class Account
    {

        
        public int AccountId { get; set; }//
        public string Username { get; set; }//username acc-a 
        public string Password { get; set; }//password acc-a 
        
    }
}
