using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace ProjekatBanka.Models
{
    public partial class BankaContext : DbContext
    {
        public BankaContext() : base("BankaContext") { }


        public System.Data.Entity.DbSet<ProjekatBanka.Models.Klijent> Klijents { get; set; }

        public System.Data.Entity.DbSet<ProjekatBanka.Models.Kartice> Kartices { get; set; }

        public System.Data.Entity.DbSet<ProjekatBanka.Models.NaruceneKartice> naruceneKartices { get; set; }
        public System.Data.Entity.DbSet<ProjekatBanka.Models.SkladisteKartica> skladisteKarticas { get; set; }

    }
}