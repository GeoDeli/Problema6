using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Problema6.Models
{
    public class Client
    {
        [Key]
        public int ID_client { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }

        [MaxLength(13), MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CNP invalid")]
        public string CNP { get; set; }

        public virtual ICollection<Achizitie> Achizitie { get; set; }
    }
}