namespace ProjekatBanka.Models
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;


    [Table("Kartica")]
    public class Kartice
    {
        [Key]
        [Column(Order = 0)]
        public int IDKartice { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Tip kartice moze biti najvise 50 karaktera")]
        public string TipKartice { get; set; }

    
        
    }
}