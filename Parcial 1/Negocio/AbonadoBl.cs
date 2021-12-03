using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AbonadoBl
    {
        AbonadoDao dao = new AbonadoDao();

        public List<Abonado> listar() {
            return dao.listar();
        }

        public List<Abonado> listarTodos() {
            return dao.listarTodos();
        }

        public Abonado obtener(int id) {
            return dao.listarTodos().Find(c => c.idAbonado == id);
        }

        public bool esAbonado(int comunicadorId) {
            return dao.listar().Any(c => c.id == comunicadorId);
        }

        public void crear(Abonado abonado) {
            ComunicadorBl cbl = new ComunicadorBl();
            cbl.crear(abonado);
            abonado.id = cbl.obtenerUltimo();
            dao.crear(abonado);
        }

        public void borrar(Abonado abonado) {
            dao.borrar(abonado);
            new ComunicadorBl().borrar(abonado);
        }

        public int obtenerUltimo(int id) {
            return dao.obtenerUltimo();
        }

        public void actualizar(Abonado abonado) {
            dao.actualizar(abonado);
            new ComunicadorBl().actualizar(abonado);
        }
    }
}
