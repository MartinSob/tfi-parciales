using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
	public class ReporteBl
	{
		LlamadaDao dao = new LlamadaDao();

		public double obtenerCargosMes(Abonado abonado, int mes) {
			List<Llamada> llamadas = dao.listar().Where(llamada => 
				llamada.fecha.Month == mes
				&& llamada.origen.idAbonado == abonado.idAbonado
			).ToList();

			double result = 0;
			foreach (Llamada l in llamadas) {
				result += l.costo;
			}

			return result;
		}

		public double obtenerRecaudacion(int mes) {
			List<Llamada> llamadas = dao.listar().Where(llamada => llamada.fecha.Month == mes).ToList();

			double result = 0;
			foreach (Llamada l in llamadas) {
				result += l.costo;
			}

			return result;
		}

		public double obtenerRecaudacionPorPromocion(Promocion promocion, int mes) {
			List<Llamada> llamadas = dao.listar().Where(llamada => llamada.fecha.Month == mes).ToList();

			foreach (Llamada l in llamadas) {
				l.origen = new AbonadoBl().obtener(l.origen.idAbonado);
			}

			switch (promocion) {
				case Promocion.Internacional:
					llamadas = llamadas.Where(llamada => llamada.nacional == false).ToList();
					break;
				case Promocion.NacionalCelular:
					llamadas = llamadas.Where(llamada => llamada.origen.tipo == TipoTelefono.Celular && llamada.nacional).ToList();
					break;
				case Promocion.NacionalCompania:
					llamadas = llamadas.Where(llamada => new AbonadoBl().esAbonado(llamada.destino.id) && llamada.nacional).ToList();
					break;
				case Promocion.NacionalFijo:
					llamadas = llamadas.Where(llamada => llamada.origen.tipo == TipoTelefono.Fijo && llamada.nacional).ToList();
					break;
			}

			double result = 0;
			foreach (Llamada l in llamadas) {
				result += l.costo;
			}

			return result;
		}

		public double obtenerPorcentajeTipo(TipoTelefono tipo) {
			List<Llamada> llamadas = dao.listar();

			foreach (Llamada l in llamadas) {
				l.origen = new AbonadoBl().obtener(l.origen.idAbonado);
			}

			var asd = llamadas.Where(llamada => llamada.origen.tipo == tipo).ToList().Count;
			var aaa = llamadas.Count;

			return ( llamadas.Where(llamada => llamada.origen.tipo == tipo).ToList().Count * 100 ) / llamadas.Count ;
		}
	}
}
