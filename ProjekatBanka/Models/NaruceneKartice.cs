namespace ProjekatBanka.Models
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NaruceneKartice")]

    public class NaruceneKartice
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RedniBrojNarudzbe { get; set; }
        [Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string JMBG { get; set; }
        [Key]
        [Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDKartice { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Dužina tipa mora biti najviše 50 karaktera.")]
        public string Tip { get; set; }
 
        



    }
}