using System;
using System.Collections.Generic;

namespace BE
{
	public class Recibo
	{
		public int id;
		public Empleado empleado;
		public DateTime periodo;
		public List<Concepto> remunerativos = new List<Concepto>();
		public List<Concepto> descuentos = new List<Concepto>();
		public double total;
	}
}
