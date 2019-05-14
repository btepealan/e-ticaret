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
    public class BaseController : Controller
    {
        SaglikContext ent = new SaglikContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Repository<Kategori> repoK = new Repository<Kategori>(ent);
            ViewBag.Kategoriler = repoK.GetAll();

            base.OnActionExecuting(filterContext);
        }
    }
}