using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemFundamentals.Models
{
    public class Employee : Models.Account
    {
        public enum EmployeePositions
        {
            Admin,
            Supervisor,
            Referent
        }

        public int EmployeeID { get; set; }
        public String WorkPlace { get; set; }
        public EmployeePositions Position { get; set; }
        public Employee(
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
            int employeeID,
            EmployeePositions position
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
            this.EmployeeID = employeeID;
            this.Position = position;
        }

    }
}
