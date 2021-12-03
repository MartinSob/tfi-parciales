using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
	public class AbonadoController : Controller
	{
		public ActionResult Index() {
			return View();
		}

		public ActionResult Edit(int id) {
			return View(new AbonadoBl().obtener(id));
		}

		public ActionResult GuardarAbonado(int idAbonado, int id, string numero, string nombre, string dni, string tipo) {
			new AbonadoBl().actualizar(new Entidades.Abonado {
				id = id,
				idAbonado = idAbonado,
				numero = numero,
				nombre = nombre,
				dni = dni,
				tipo = tipo == "Fijo" ? Entidades.TipoTelefono.Fijo : Entidades.TipoTelefono.Celular
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CrearAbonado(string numero, string nombre, string dni, string tipo) {
			new AbonadoBl().crear(new Entidades.Abonado {
				numero = numero,
				nombre = nombre,
				dni = dni,
				tipo = tipo == "Fijo" ? Entidades.TipoTelefono.Fijo : Entidades.TipoTelefono.Celular
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EliminarAbonado(int id) {
			new AbonadoBl().borrar(new Entidades.Abonado {
				idAbonado = id
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Crear() {
			return View();
		}
	}
}