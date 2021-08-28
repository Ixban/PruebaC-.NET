using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionLayer.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {

            var result = BL.LineasCelularess.getAll();

            List<ML.LineasCelulares> LineasList = new List<ML.LineasCelulares>();

            foreach (var lineaItem in result.Objects)
            {
                ML.LineasCelulares lineasCelulares = new ML.LineasCelulares();
                lineasCelulares.MobileLineId = ((ML.LineasCelulares)lineaItem).MobileLineId;
                lineasCelulares.MobileLine = ((ML.LineasCelulares)lineaItem).MobileLine;
                lineasCelulares.Description = ((ML.LineasCelulares)lineaItem).Description;
                LineasList.Add(lineasCelulares);
            }

            return View(LineasList);
        }

    }
}
