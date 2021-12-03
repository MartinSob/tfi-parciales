using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LlamadaBl
    {
        ComunicadorBl cbl = new ComunicadorBl();
        AbonadoBl abl = new AbonadoBl();

        LlamadaDao dao = new LlamadaDao();

        public List<Llamada> listar() {
            return dao.listar();
        }

        public void crear(Llamada llamada) {
            llamada.fecha = DateTime.Now;
            llamada.costo = calcularCosto(llamada);
            dao.crear(llamada);
        }

        public double calcularCosto(Llamada llamada) {
            if (llamada.nacional) { 
                if (abl.esAbonado(llamada.destino.id)) {
                    return 0;
                }

                llamada.origen = abl.obtener(llamada.origen.idAbonado);
                llamada.destino = cbl.obtener(llamada.destino.id);

                if (llamada.origen.tipo == TipoTelefono.Celular && llamada.destino.tipo == TipoTelefono.Celular) {
                    return llamada.duracion * 0.8;
                }

                if (llamada.destino.tipo == TipoTelefono.Fijo) {
                    return llamada.duracion * 0.95;
                }
            }

            return (3 + llamada.duracion * 0.95);
        }
    }
}
