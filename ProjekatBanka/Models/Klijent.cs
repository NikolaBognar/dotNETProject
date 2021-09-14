namespace ProjekatBanka.Models
{
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


  [Table("Klijent")]
    public partial class Klijent
    {
        [Key]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Ime može da sadrži najviše 30 karaktera")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Prezime može da sadrži najviše 30 karaktera")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Adresa može da sadrži najviše 30 karaktera")]
        public string Adresa { get; set; }

        public int BrojLicneKarte { get; set;  }

        public string Telefon { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(30, ErrorMessage = "Šifra može da sadrži najviše 30 karaktera")]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
    }
}