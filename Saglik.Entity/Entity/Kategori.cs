using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Entity.Entity
{
    [Table("Kategoriler")]
    public class Kategori : EntityBase
    {
        public Kategori()
        {
            AltKategoriler = new List<AltKategori>();
        }
        [Required]
        [StringLength(50)]
        public string kategoriAd { get; set; }
        public string aciklama { get; set; }

        //Relations
        public virtual List<AltKategori> AltKategoriler { get; set; }
        public virtual List<Urun> Urunler { get; set; }
    }
}
