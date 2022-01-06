using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Problema6.Models
{
    public class Achizitie
    {
        [Key]
        public int ID_achizitie { get; set; }
        public int ID_client { get; set; }
        public int ID_telefon { get; set; }

        [Display(Name = "Data achizitie"), DataType(DataType.Date)]
        public DateTime DataAchizitie { get; set; }
        [Range(0, 100000), Display(Name = "Pret")]
        public float Pret { get; set; }

        public virtual Telefon Telefon { get; set; }
        public virtual Client Client { get; set; }

    }
}