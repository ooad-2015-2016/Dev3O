using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.BankaBaza.Models;

namespace App1.AccountBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(AccountDbContext context)
        {
            if (!context.Accounti.Any())
            {
                context.Accounti.AddRange(new Account()
                {
                    Username = "emir8gallo",
                    Password = "ooadProjekat",
                    
                });

                context.SaveChanges();
            }
        }

        
    }
}
