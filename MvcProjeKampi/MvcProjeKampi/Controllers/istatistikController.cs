using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();

        public ActionResult Index()
        {
            var istatistik1 = c.Categories.Count();
            ViewBag.ist1 = istatistik1;

            var istatistik2 = c.Headings.Where(x => x.CategoryID == 8).Count();
            ViewBag.ist2 = istatistik2;

            var istatistik3 = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            ViewBag.ist3 = istatistik3;

            var istatistik4 = c.Headings.GroupBy(x => x.Category.CategoryName).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.ist4 = istatistik4;

            var True = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var False = c.Categories.Where(x => x.CategoryStatus == false).Count();

            ViewBag.ist5 =Math.Abs( True - False);
            return View();
        }
    }
}