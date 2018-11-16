using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WideWorldImporters.Models;
using System.Data.Entity;

namespace WideWorldImporters.DAL
{
    public class WWICollection : DbContext
    {
        // GET: WWICollection
        public WWICollection() : base("WWICollection")
        {
            
        }
    }
}