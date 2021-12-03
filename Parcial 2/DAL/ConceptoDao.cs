using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ConceptoDao : ConnectionDao
	{
		public List<Concepto> listar() {
			try {
				SqlCommand query = new SqlCommand("ListarConceptos", conn);
				query.CommandType = CommandType.StoredProcedure;

				conn.Open();
				SqlDataReader data = query.ExecuteReader();

				List<Concepto> conceptos = new List<Concepto>();
				if (data.HasRows) {
					while (data.Read()) {
						conceptos.Add(castDto(data));
					}
				}

				conn.Close();

				return conceptos;
			} catch (Exception e) {
				Console.WriteLine(e);
			}
			return new List<Concepto>();
		}

		public List<Concepto> listarConceptos(Recibo r) {
			SqlCommand query = new SqlCommand("ListarReciboConcepto", conn);
			query.CommandType = CommandType.StoredProcedure;

			query.Parameters.Add(new SqlParameter {
				ParameterName = "@recibo_id",
				DbType = DbType.Int32,
				Value = r.id
			});

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Concepto> conceptos = new List<Concepto>();
			if (data.HasRows) {
				while (data.Read()) {
					conceptos.Add(castDto(data));
				}
			}

			conn.Close();

			return conceptos;
		}

		public void crear(Concepto concepto) {
			try {
				SqlCommand query = new SqlCommand("CrearConcepto", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@descripcion",
					DbType = DbType.String,
					Value = concepto.descripcion
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@cantidad",
					DbType = DbType.Decimal,
					Value = concepto.cantidad
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@tipo",
					DbType = DbType.String,
					Value = concepto.tipo
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public void actualizar(Concepto concepto) {
			try {
				SqlCommand query = new SqlCommand("ActualizarConcepto", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = concepto.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@descripcion",
					DbType = DbType.String,
					Value = concepto.descripcion
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@cantidad",
					DbType = DbType.Double,
					Value = concepto.cantidad
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@tipo",
					DbType = DbType.String,
					Value = concepto.tipo
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public void borrar(Concepto concepto) {
			try {
				SqlCommand query = new SqlCommand("BorrarConcepto", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = concepto.id
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public Concepto castDto(SqlDataReader data) {
			Concepto a = new Concepto {
				id = int.Parse(data["id"].ToString()),
				descripcion = data["descripcion"].ToString(),
				tipo = data["tipo"].ToString(),
				cantidad = double.Parse(data["cantidad"].ToString())
			};

			try {
				a.valorUnitario = double.Parse(data["valorUnitario"].ToString());
			} catch (Exception e) {
				a.valorUnitario = 0;
			}

			try {
				a.total = double.Parse(data["total"].ToString());
			} catch (Exception e) {
				a.total = 0;
			}

			return a;
		}
	}
}
