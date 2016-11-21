using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIFINAL.Models
{
    public class PremiosContext : DbContext
    {
        public DbSet<Premios> Premios { get; set; }
    }
}