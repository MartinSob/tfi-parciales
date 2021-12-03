using BLL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial_2.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoBl bl = new EmpleadoBl();

        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear() {
            return View();
        }

        public ActionResult CreateEmployee(string nombre, string apellido, string dni, string legajo, DateTime fecNac, double sueldo) {
            bl.crear(new Empleado { 
                nombre = nombre,
                apellido = apellido,
                dni = dni,
                legajo = legajo,
                fecNac = fecNac,
                sueldo = sueldo
            });
            return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Obtener(int id) {
            return Json(new { data = bl.listar(id) }, JsonRequestBehavior.AllowGet);
        }
    }
}