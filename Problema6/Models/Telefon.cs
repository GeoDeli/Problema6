using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Problema6.Models
{
    public class Telefon
    {
        [Key]
        public int ID_telefon { get; set; }
        public string Model { get; set; }

        [Range(2000, 2022), Display(Name = "An aparitie")]
        public int An { get; set; }
        public string Specificatii { get; set; }
        [Range(0.00, 100000.00), Display(Name = "Pret")]
        public float Pret { get; set; }

        [Range(0, 1000), Display(Name = "Stoc")]
        public int Stoc { get; set; }

        public virtual ICollection<Achizitie> Achizitie { get; set; }
    }
}