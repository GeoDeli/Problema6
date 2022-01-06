using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Problema6.Models
{
    public class Gestiune_Telefoane : DbContext
    {
        public Gestiune_Telefoane() : base("Gestiune_Telefoane")
        { }
        public virtual DbSet<Telefon> Telefon { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Achizitie> Achizite { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

    }
}