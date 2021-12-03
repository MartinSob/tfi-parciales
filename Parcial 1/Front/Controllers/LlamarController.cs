using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
	public class LlamarController : Controller
	{
		public ActionResult Index() {
			return View();
		}

		public ActionResult Crear() {
			return View();
		}

		public ActionResult RealizarLLamada(int origen, int destino, int duracion, bool nacional) {
			new LlamadaBl().crear(new Llamada {
				origen = new Abonado { idAbonado = origen },
				destino = new Comunicador { id = destino },
				duracion = duracion,
				nacional = nacional
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}
	}
}