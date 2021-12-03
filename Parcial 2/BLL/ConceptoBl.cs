using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
	public class ConceptoBl
	{
		ConceptoDao dao = new ConceptoDao();

		public List<Concepto> listar() {
			return dao.listar();
		}

		public Concepto listar(int id) {
			return dao.listar().Find(c => c.id == id);
		}

		public List<Concepto> listarConceptos(Recibo r) {
			return dao.listarConceptos(r);
		}

		public void crear(Concepto concepto) {
			dao.crear(concepto);
		}

		public void actualizar(Concepto concepto) {
			dao.actualizar(concepto);
		}

		public void borrar(Concepto concepto) {
			dao.borrar(concepto);
		}
	}
}
