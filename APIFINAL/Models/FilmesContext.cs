using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIFINAL.Models
{
    public class FilmesContext :DbContext
    {
       public DbSet<Filmes> Filmes { get; set; }
    }
}