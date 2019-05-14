using Saglik.BLL.Repository;
using Saglik.DAL.Context;
using Saglik.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.MVC.Controllers
{
    public class HomeController : BaseController
    {
        Repository<Urun> repoU = new Repository<Urun>(new SaglikContext());
        public ActionResult Index(int? katid, int? altid)
        {
            ViewBag.KatID = katid;
            ViewBag.AltKatID = altid;
            return View();
        }
        public ActionResult UrunlerBy(int? katid, int? altid)
        {
            List<Urun> liste = new List<Urun>();
            if(altid.HasValue)
            {
                //Alt Kategori seçilmiş...
                liste = repoU.GetAll(x => x.altkategoriID == altid).ToList();
            }
            else
            {
                //Kategori seçilmiş...
                if (katid.HasValue)
                {
                    liste = repoU.GetAll(x => x.kategoriID == katid).ToList();
                }
                else
                {
                    //Seçim yapılmamış, tüm ürünler listelenecek...
                    liste = repoU.GetAll().ToList();
                }
            }
            return PartialView(liste);
        }
    }
}