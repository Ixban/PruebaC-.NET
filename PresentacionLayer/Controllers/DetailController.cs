using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionLayer.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index(string FilterNumero, string FilterDescripcion)
        {
            var result = BL.DetalleDeLlamadas.getAll(FilterNumero, FilterDescripcion);

            List<ML.DetalleDeLlamadas> DetalleList = new List<ML.DetalleDeLlamadas>();

            foreach (var DetalleItem in result.Objects)
            {
                ML.DetalleDeLlamadas detalle = new ML.DetalleDeLlamadas();
                detalle.CallDetailId = ((ML.DetalleDeLlamadas)DetalleItem).CallDetailId;
                detalle.MobileLine = ((ML.DetalleDeLlamadas)DetalleItem).MobileLine;
                detalle.LineasCelulares = new ML.LineasCelulares();
                detalle.LineasCelulares.Description = ((ML.DetalleDeLlamadas)DetalleItem).LineasCelulares.Description;
                detalle.CalledPartyNumber = ((ML.DetalleDeLlamadas)DetalleItem).CalledPartyNumber;
                detalle.CalledPartyDescription = ((ML.DetalleDeLlamadas)DetalleItem).CalledPartyDescription;
                detalle.DateTime = ((ML.DetalleDeLlamadas)DetalleItem).DateTime;
                detalle.HourTime = ((ML.DetalleDeLlamadas)DetalleItem).HourTime;
                detalle.Duration = ((ML.DetalleDeLlamadas)DetalleItem).Duration;
                detalle.TotalCost = ((ML.DetalleDeLlamadas)DetalleItem).TotalCost;
                DetalleList.Add(detalle);
            }


            return View(DetalleList);
        }

    }
}
