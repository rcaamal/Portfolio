using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matience.Models
{
    public class Tendent
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(10)]
        public string LastName { get; set; }

        [Required, StringLength(10)]
        public String PhoneNumber { get; set; }

        [Required, StringLength(20)]
        public String AptName{ get; set; }

        [Required, StringLength(3)]
        public String UNumber { get; set; }

        [Required, StringLength(105)]
        public String Explanation { get; set; }
        
        

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {AptName} {UNumber} {Explanation}  ";
        }
    }
}