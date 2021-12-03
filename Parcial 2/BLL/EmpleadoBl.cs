using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoBl
    {
		EmpleadoDao dao = new EmpleadoDao();

		public List<Empleado> listar() {
			return dao.listar();
		}

		public Empleado listar(int id) {
			return dao.listar().Find(c => c.id == id);
		}

		public void crear(Empleado empleado) {
			dao.crear(empleado);
		}
	}
}
