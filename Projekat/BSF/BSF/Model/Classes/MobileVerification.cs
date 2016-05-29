using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DAL
{
    public class MobileVerification
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public Person Verifying { get; set; }
        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}
