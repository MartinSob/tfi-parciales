using BE;
using BLL;
using Parcial_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial_2.Controllers
{
    public class ReciboSueldoController : Controller
    {
        ReciboBl bl = new ReciboBl();
        ConceptoBl cbl = new ConceptoBl();

        // GET: ReciboSueldo
        public ActionResult Index(int mes = 0, int año = 0, int empleado = 0)
        {
            return View(new ListModel<Recibo>(bl.listar(mes, año, empleado)));
        }

        public ActionResult Crear() {
            return View();
        }

        public ActionResult CreateRecibo(int empleadoId, DateTime periodo, int[] remunerativos, int[] descuentos, int[] rValorUnitario, int[] dValorUnitario, double total) {
            Recibo recibo = new Recibo {
                empleado = new Empleado { id = empleadoId },
                periodo = periodo,
                total = total
            };

            for(int i = 0; i < remunerativos.Length; i++) {
                Concepto newC = cbl.listar(remunerativos[i]);
                newC.valorUnitario = rValorUnitario[i];
                recibo.remunerativos.Add(newC);
            }

            for (int i = 0; i < descuentos.Length; i++) {
                Concepto newC = cbl.listar(descuentos[i]);
                newC.valorUnitario = dValorUnitario[i];
                recibo.remunerativos.Add(newC);
            }

            bl.crear(recibo);

            return Json(new { type = "success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult View(int id) {
            var recibo = bl.listar().Where(r => r.id == id).First();
            foreach(Concepto c in cbl.listarConceptos(new Recibo { id = id })) {
                if (c.tipo == "Remunerativo")
                    recibo.remunerativos.Add(c);
                if (c.tipo == "Descuento")
                    recibo.descuentos.Add(c);
            }
            return View(recibo);
        }
    }
}