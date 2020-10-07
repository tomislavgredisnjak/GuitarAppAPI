using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuitarAPI.Models
{
    public class GuitarBase : DbContext
    {
        public DbSet<Guitar> Guitars { get; set; }
    }

}