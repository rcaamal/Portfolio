using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Matience.Models;
using System.Data.Entity;

namespace Matience.DAL
{
    public class TendentCollection : DbContext
    {
        

        public TendentCollection() : base("name=OurUsers")
        {

           
        }

        public virtual DbSet<Tendent> Users { get; set; }
    }
}