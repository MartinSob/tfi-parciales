using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
	public class ComunicadorController : Controller
	{
		public ActionResult Index() {
			return View();
		}

		public ActionResult Edit(int id) {
			return View(new ComunicadorBl().obtener(id));
		}

		public ActionResult GuardarComunicador(int id, string numero, string nombre, string dni, string tipo) {
			new ComunicadorBl().actualizar(new Entidades.Comunicador {
				id = id,
				numero = numero,
				tipo = tipo == "Fijo" ? Entidades.TipoTelefono.Fijo : Entidades.TipoTelefono.Celular
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult CrearComunicador(string numero, string tipo) {
			new ComunicadorBl().crear(new Entidades.Comunicador {
				numero = numero,
				tipo = tipo == "Fijo" ? Entidades.TipoTelefono.Fijo : Entidades.TipoTelefono.Celular
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EliminarComunicador(int id) {
			new ComunicadorBl().borrar(new Entidades.Comunicador {
				id = id
			});
			return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Crear() {
			return View();
		}
	}
}