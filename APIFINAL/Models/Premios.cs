using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIFINAL.Models
{
    [Table("Premios")]
    public class Premios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        public int Ano { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; }
        
    }
}