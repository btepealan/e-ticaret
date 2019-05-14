using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Entity.Entity
{
    [Table("Uyeler")]
    public class Uye : EntityBase
    {
        public Uye()
        {

        }
        [Required]
        [StringLength(30, ErrorMessage = "İsim {0} karakterden uzun olmamalıdır!")]
        public string ad { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Soyisim {0} karakterden uzun olmamalıdır!")]
        public string soyad { get; set; }
        [Required]
        [MinLength(11), MaxLength(11)]
        public string tckno { get; set; }
        public string adres { get; set; }
        [StringLength(30)]
        public string ilce { get; set; }
        [StringLength(30)]
        public string il { get; set; }
        public string UserId { get; set; }

        //Relations
        public virtual List<Satis> Satislar { get; set; }
    }
}
