using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DAL
{
    public class Person
    {
        [Key]
        public int AccoutnId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]
        public int MyProperty { get; set; }
        public string NameOfFather { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalNumber { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool Validated { get; set; }
    }
}
