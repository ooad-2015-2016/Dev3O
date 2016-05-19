using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemFundamentals.Models
{
    public abstract class Person
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String NameOfFather { get; set; }
        public String Adress { get; set; }
        public String City { get; set; }
        public int PostalNumber { get; set; }
        public String TelephoneNumber { get; set; }
        public String Email { get; set; }
    }
}
