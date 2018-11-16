using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WideWorldImporters.Models
{
    public class SearchContext
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Search { get; set; }





        public override string ToString()
        {
            return $"{base.ToString()}: {Search}   ";

        }
    }
}