using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIFINAL.Models
{
    [Table("Celebridades")]
    public class Celebridades
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string pais { get; set; }

        public DateTime DataNasc { get; set; }
    }
}