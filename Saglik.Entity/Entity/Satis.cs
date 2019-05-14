using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Entity.Entity
{
    [Table("Satislar")]
    public class Satis : EntityBase
    {
        public Satis()
        {
            this.Tarih = DateTime.Now;
            this.teslimTarihi = DateTime.Now;
            this.toplamMiktar = 1;
            this.toplamTutar = 0;
            SatisDetaylar = new List<SatisDetay>();
        }
        /// <summary>
        /// Satış Tarihi
        /// </summary>
        [Required]
        public DateTime Tarih { get; set; }

        public int uyeID { get; set; }
        [Required]
        public int toplamMiktar { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public int toplamTutar { get; set; }
        [Required]
        public DateTime teslimTarihi { get; set; }
        /// <summary>
        /// Sipariş Durumu
        /// </summary>
        public byte durumu { get; set; }

        //Relations
        public virtual Uye Uye { get; set; }
        public virtual List<SatisDetay> SatisDetaylar { get; set; }
    }
}
