using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ReciboDao : ConnectionDao
	{
		public List<Recibo> listar() {
			SqlCommand query = new SqlCommand("ListarRecibos", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Recibo> recibo = new List<Recibo>();
			if (data.HasRows) {
				while (data.Read()) {
					recibo.Add(castDto(data));
				}
			}

			conn.Close();

			return recibo;
		}

		public int crear(Recibo recibo) {
			try {
				SqlCommand query = new SqlCommand("CrearRecibo", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@empleado_id",
					DbType = DbType.String,
					Value = recibo.empleado.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@periodo",
					DbType = DbType.DateTime,
					Value = recibo.periodo
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@total",
					DbType = DbType.Decimal,
					Value = recibo.total
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
				return obtenerUltimo();
			} catch (Exception e) {
				Console.WriteLine(e);
				return 0;
			}
		}

		public void crear(Recibo recibo, Concepto concepto) {
			try {
				SqlCommand query = new SqlCommand("CrearReciboConcepto", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@recibo_id",
					DbType = DbType.Int32,
					Value = recibo.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@concepto_id",
					DbType = DbType.Int32,
					Value = concepto.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@valorUnitario",
					DbType = DbType.Decimal,
					Value = concepto.valorUnitario
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@total",
					DbType = DbType.Decimal,
					Value = concepto.total
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public int obtenerUltimo() {
			SqlCommand query = new SqlCommand("ObtenerUltimoRecibo", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			int result = 0;
			if (data.HasRows) {
				while (data.Read()) {
					result = int.Parse(data["id"].ToString());
				}
			}

			conn.Close();

			return result;
		}

		public Recibo castDto(SqlDataReader data) {
			Recibo a = new Recibo {
				id = int.Parse(data["id"].ToString()),
				empleado = new Empleado { 
					id = int.Parse(data["empleado_id"].ToString())
				},
				periodo = DateTime.Parse(data["periodo"].ToString()),
				total = double.Parse(data["total"].ToString())
			};

			return a;
		}
	}
}
