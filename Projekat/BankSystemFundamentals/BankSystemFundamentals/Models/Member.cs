using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemFundamentals.Models
{
    public class Member : Models.Account
    {
        public int CardID { get; set; }
        public Boolean Verified { get; set; }
        public Member(
            String name,
            String surname,
            String nameOfFather,
            String adress,
            String city,
            int postalNumber,
            String telephoneNumber,
            String email,
            String username,
            String password,
            int cardID,
            Boolean verified
            ) : base(name, surname, nameOfFather, adress, city, postalNumber, telephoneNumber, email, username, password)
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
            this.CardID = cardID;
            this.Verified = verified;
        }
    }
}
