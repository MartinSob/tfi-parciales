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
    public class ComunicadorDao : ConnectionDao
    {
		public List<Comunicador> listar() {
			SqlCommand query = new SqlCommand("ListarComunicadores", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Comunicador> comunicadors = new List<Comunicador>();
			if (data.HasRows) {
				while (data.Read()) {
					comunicadors.Add(castDto(data));
				}
			}

			conn.Close();

			return comunicadors;
		}

		public List<Comunicador> listarTodos() {
			SqlCommand query = new SqlCommand("ListarTodosComunicadores", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Comunicador> comunicadors = new List<Comunicador>();
			if (data.HasRows) {
				while (data.Read()) {
					comunicadors.Add(castDto(data));
				}
			}

			conn.Close();

			return comunicadors;
		}

		public void crear(Comunicador comunicador) {
			try {
				SqlCommand query = new SqlCommand("CrearComunicador", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@numero",
					DbType = DbType.String,
					Value = comunicador.numero
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@tipo",
					DbType = DbType.String,
					Value = comunicador.tipo.ToString()
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public void actualizar(Comunicador comunicador) {
			try {
				SqlCommand query = new SqlCommand("ActualizarComunicador", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@numero",
					DbType = DbType.String,
					Value = comunicador.numero
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = comunicador.id
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@tipo",
					DbType = DbType.String,
					Value = comunicador.tipo.ToString()
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public void borrar(Comunicador comunicador) {
			try {
				SqlCommand query = new SqlCommand("BorrarComunicador", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@id",
					DbType = DbType.Int32,
					Value = comunicador.id
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				var a = e;
			}
		}

		public int obtenerUltimo() {
			SqlCommand query = new SqlCommand("ObtenerUltimoComunicador", conn);
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

		public Comunicador castDto(SqlDataReader data) { 
			Comunicador c = new Comunicador {
				id = int.Parse(data["id"].ToString()),
				numero = data["numero"].ToString()
			};

			string tipo = data["tipo"].ToString();
			if (tipo == "Celular")
				c.tipo = TipoTelefono.Celular;

			if (tipo == "Fijo")
				c.tipo = TipoTelefono.Fijo;

			return c;
		}
	}
}
