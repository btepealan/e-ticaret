using Saglik.BLL.Repository;
using Saglik.DAL.Context;
using Saglik.Entity.Entity;
using Saglik.PL.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.MVC.Controllers
{
    public class SepetController : Controller
    {
        Repository<Urun> repoU = new Repository<Urun>(new SaglikContext());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SepeteEkle(string Id, string Adet)
        {
            //ID'ye göre ürün bilgilerini veritabanından çekerek herhangi bir müdahaleyle fiyatın değişmesini önlüyoruz.
            Urun u = repoU.GetById(Convert.ToInt32(Id));
            cSepet siparis = new cSepet();
            siparis.urunId = u.Id;
            siparis.urunAd = u.urunAd;
            siparis.adet = Convert.ToInt32(Adet);
            siparis.fiyat = u.urunFiyat;
            siparis.tutar = Convert.ToInt32(Adet) * u.urunFiyat;
            List<cSepet> sepet = cSepet.SepetAl();
            siparis.SepeteEkle(sepet, siparis);
            return View("SepetYenile");
        }
        public ActionResult SepetYenile()
        {
            return View();
        }
    }
}