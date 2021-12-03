using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
	public class ReportesController : Controller
	{
		ReporteBl bl = new ReporteBl();

		public ActionResult Index() {
			return View();
		}

		public ActionResult CargosMesCliente(int idAbonado, int fecha) {
			double cargo = bl.obtenerCargosMes(new Abonado { idAbonado = idAbonado }, fecha);
			return Json(new { text = "El cliente gasto $" + cargo }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CargosMes(int fecha) {
			double cargo = bl.obtenerRecaudacion(fecha);
			return Json(new { text = "La recaudacion fue de $" + cargo }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult cargosMesPromo(string promocion, int fecha) {
			Promocion p = Promocion.NacionalCelular;
			switch (promocion) {
				case "NacionalFijo":
					p = Promocion.NacionalFijo;
					break;
				case "NacionalCelular":
					p = Promocion.NacionalCelular;
					break;
				case "NacionalCompania":
					p = Promocion.NacionalCompania;
					break;
				case "Internacional":
					p = Promocion.Internacional;
					break;
			}

			double cargo = bl.obtenerRecaudacionPorPromocion(p, fecha);
			return Json(new { text = "La recaudacion fue de $" + cargo }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult PorcentajeTipo(string tipo) {
			string result = $"{tipo} tiene un %" + bl.obtenerPorcentajeTipo((TipoTelefono)Enum.Parse(typeof(TipoTelefono), tipo));
			return Json(new { text = result }, JsonRequestBehavior.AllowGet);
		}
	}
}