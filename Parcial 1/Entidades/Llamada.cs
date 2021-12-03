using System;

namespace Entidades
{
	public class Llamada
	{
		public int id;
		public Abonado origen;
		public Comunicador destino;
		public double duracion;
		public DateTime fecha;
		public bool nacional;
		public double costo;
	}

	public enum Promocion { 
		NacionalFijo,
		NacionalCelular,
		NacionalCompania,
		Internacional
	}
}
