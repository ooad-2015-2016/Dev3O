using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemFundamentals.Models
{
    public class Account : Models.Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public Account(
            String name,
            String surname,
            String nameOfFather,
            String adress,
            String city,
            int postalNumber,
            String telephoneNumber,
            String email,
            String username,
            String password
            )
        {
            this.Name = name;
            this.Surname = surname;
            this.NameOfFather = nameOfFather;
            this.Adress = adress;
            this.City = city;
            this.PostalNumber = postalNumber;
            this.TelephoneNumber = telephoneNumber;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
    }
}
