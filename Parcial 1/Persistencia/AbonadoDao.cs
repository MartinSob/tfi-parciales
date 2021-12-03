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
    public class AbonadoDao : ConnectionDao
    {
		public List<Abonado> listar() {
			SqlCommand query = new SqlCommand("ListarClientes", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Abonado> abonados = new List<Abonado>();
			if (data.HasRows) {
				while (data.Read()) {
					abonados.Add(castDto(data));
				}
			}

			conn.Close();

			return abonados;
		}

		public List<Abonado> listarTodos() {
			SqlCommand query = new SqlCommand("ListarTodosClientes", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Abonado> abonados = new List<Abonado>();
			if (data.HasRows) {
				while (data.Read()) {
					abonados.Add(castDto(data));
				}
			}

			conn.Close();

			return abonados;
		}

		public void crear(Abonado abonado) {
			try {
				SqlCommand query = new SqlCommand("CrearCliente", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@comunicador",
					DbType = DbType.Int32,
					Value = abonado.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@nombre",
					DbType = DbType.String,
					Value = abonado.nombre
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@dni",
					DbType = DbType.String,
					Value = abonado.dni
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public void actualizar(Abonado abonado) {
			try {
				SqlCommand query = new SqlCommand("ActualizarCliente", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = abonado.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@nombre",
					DbType = DbType.String,
					Value = abonado.nombre
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@dni",
					DbType = DbType.String,
					Value = abonado.dni
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public void borrar(Abonado comunicador) {
			try {
				SqlCommand query = new SqlCommand("BorrarCliente", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = comunicador.idAbonado
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public int obtenerUltimo() {
			SqlCommand query = new SqlCommand("ObtenerUltimoCliente", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			int result = 0;
			if (data.HasRows) {
				while (data.Read()) {
					result = int.Parse(data["idCliente"].ToString());
				}
			}

			conn.Close();

			return result;
		}
		
		public Abonado castDto(SqlDataReader data) {
			Abonado a = new Abonado {
				id = int.Parse(data["id"].ToString()),
				idAbonado = int.Parse(data["idCliente"].ToString()),
				nombre = data["nombre"].ToString(),
				dni = data["dni"].ToString(),
				numero = data["numero"].ToString()
			};

			string tipo = data["tipo"].ToString();
			if (tipo == "Celular")
				a.tipo = TipoTelefono.Celular;

			if (tipo == "Fijo")
				a.tipo = TipoTelefono.Fijo;

			return a;
		}
	}
}
