using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComunicadorBl
    {
        ComunicadorDao dao = new ComunicadorDao();

        public List<Comunicador> listar() {
            return dao.listar();
        }

        public List<Comunicador> listarTodos() {
            return dao.listarTodos();
        }

        public Comunicador obtener(int id) {
            return dao.listarTodos().Find(c => c.id == id);
        }

        public int obtenerUltimo() {
            return dao.obtenerUltimo();
        }

        public void crear(Comunicador comunicador) {
            dao.crear(comunicador);
        }

        public void borrar(Comunicador comunicador) {
            dao.borrar(comunicador);
        }

        public void actualizar(Comunicador comunicador) {
            dao.actualizar(comunicador);
        }
    }
}
