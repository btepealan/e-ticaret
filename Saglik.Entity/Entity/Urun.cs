using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Entity.Entity
{
    [Table("Urunler")]
    public class Urun : EntityBase
    {
        public Urun()
        {
            this.miktar = 1;
            this.kritikSeviye = 1;
            this.urunFiyat = 1;
            this.indirim = false;
            this.indirimOrani = 0;

        }
        [Required]
        [StringLength(20)]
        public string urunKodu { get; set; }

        [Required]
        [StringLength(50)]
        public string urunAd { get; set; }

        public int? kategoriID { get; set; }
        public int altkategoriID { get; set; }
        public int miktar { get; set; }
        public int kritikSeviye { get; set; }

        [Column(TypeName = "money")]
        public decimal urunFiyat { get; set; }
        public string urunBilgisi { get; set; }

        [StringLength(100)]
        public string urunResimYolu1 { get; set; }
        [StringLength(100)]
        public string urunResimYolu2 { get; set; }
        [Required]
        public bool indirim { get; set; }
        [Required]
        public int indirimOrani { get; set; }

        //Relations

        public virtual Kategori Kategori { get; set; }
        public virtual AltKategori AltKategori { get; set; }
        public virtual List<SatisDetay> SatisDetaylar { get; set; }
    }
}
