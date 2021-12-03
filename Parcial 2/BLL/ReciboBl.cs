using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
	public class ReciboBl
    {
		ReciboDao dao = new ReciboDao();
		ConceptoBl cBl = new ConceptoBl();
		EmpleadoBl eBl = new EmpleadoBl();

		public List<Recibo> listar(int mes = 0, int año = 0, int empleado = 0) {
			List<Recibo> recibos = dao.listar();

			if (mes != 0) {
				recibos = recibos.Where(r => r.periodo.Month == mes).ToList();
			}

			if (año != 0) {
				recibos = recibos.Where(r => r.periodo.Year == año).ToList();
			}

			if (empleado != 0) {
				recibos = recibos.Where(r => r.empleado.id == empleado).ToList();
			}

			return recibos;
		}

		public void crear(Recibo r) {
			r.id = dao.crear(r);

			r.empleado = eBl.listar(r.empleado.id);

			foreach (Concepto c in r.remunerativos) {
				c.total = c.valorUnitario * c.cantidad / 100;
				dao.crear(r, c);
			}

			foreach (Concepto c in r.descuentos) {
				dao.crear(r, c);
			}
		}
	}
}
