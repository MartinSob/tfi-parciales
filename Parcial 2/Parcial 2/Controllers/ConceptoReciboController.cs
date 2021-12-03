using BLL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial_2.Controllers
{
    public class ConceptoReciboController : Controller
    {
        ConceptoBl bl = new ConceptoBl();

        // GET: ConceptoRecibo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eliminar(int id) {
            bl.borrar(new Concepto { id = id });
            return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Actualizar(int id) {
            return View(bl.listar(id));
        }

        public ActionResult Crear() {
            return View();
        }

        public ActionResult CreateConcept(string descripcion, double cantidad, string tipo) {
            bl.crear(new Concepto { 
                descripcion = descripcion,
                cantidad = cantidad,
                tipo = tipo
            });
            return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateConcept(int id, string descripcion, double cantidad, string tipo) {
            bl.actualizar(new Concepto {
                id = id,
                descripcion = descripcion,
                cantidad = cantidad,
                tipo = tipo
            });
            return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}