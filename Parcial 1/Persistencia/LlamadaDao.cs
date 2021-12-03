using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class LlamadaDao : ConnectionDao
    {
		public List<Llamada> listar() {
			SqlCommand query = new SqlCommand("ListarLlamadas", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Llamada> llamadas = new List<Llamada>();
			if (data.HasRows) {
				while(data.Read()) { 
					Llamada l = new Llamada {
						id = int.Parse(data["id"].ToString()),
						origen = new Abonado { idAbonado = int.Parse(data["origen_id"].ToString()) },
						destino = new Comunicador { id = int.Parse(data["destino_id"].ToString()) },
						duracion = int.Parse(data["duracion"].ToString()),
						fecha = Convert.ToDateTime(data["fecha"].ToString()),
						nacional = Convert.ToBoolean(data["nacional"].ToString()),
						costo = double.Parse(data["costo"].ToString())
					};

					llamadas.Add(l);
				}
			}

			conn.Close();

			return llamadas;
		}

		public void crear(Llamada llamada) {
			try {
				SqlCommand query = new SqlCommand("CrearLlamada", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@origen",
					DbType = DbType.Int32,
					Value = llamada.origen.idAbonado
				});
				query.Parameters.Add(new SqlParameter {
					ParameterName = "@destino",
					DbType = DbType.Int32,
					Value = llamada.destino.id
				});
				query.Parameters.Add(new SqlParameter {
					ParameterName = "@duracion",
					DbType = DbType.Int32,
					Value = llamada.duracion
				});
				query.Parameters.Add(new SqlParameter {
					ParameterName = "@fecha",
					DbType = DbType.DateTime,
					Value = llamada.fecha
				});
				query.Parameters.Add(new SqlParameter {
					ParameterName = "@nacional",
					DbType = DbType.Boolean,
					Value = llamada.nacional
				});
				query.Parameters.Add(new SqlParameter {
					ParameterName = "@costo",
					DbType = DbType.Decimal,
					Value = llamada.costo
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}
	}
}
