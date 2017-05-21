using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class PassportControlEntities: DbContext
    {
        public DbSet<PassportItem> Passports { get; set; }
        public DbSet<PlaceOfBirth> Places { get; set; }
    }
}