using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmpleadoDao : ConnectionDao
	{
		public List<Empleado> listar() {
			SqlCommand query = new SqlCommand("ListarEmpleados", conn);
			query.CommandType = CommandType.StoredProcedure;

			conn.Open();
			SqlDataReader data = query.ExecuteReader();

			List<Empleado> empleados = new List<Empleado>();
			if (data.HasRows) {
				while (data.Read()) {
					empleados.Add(castDto(data));
				}
			}

			conn.Close();

			return empleados;
		}

		public void crear(Empleado empleado) {
			try {
				SqlCommand query = new SqlCommand("CrearEmpleado", conn);
				query.CommandType = CommandType.StoredProcedure;

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@nombre",
					DbType = DbType.String,
					Value = empleado.nombre
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@apellido",
					DbType = DbType.String,
					Value = empleado.apellido
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@dni",
					DbType = DbType.String,
					Value = empleado.dni
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@legajo",
					DbType = DbType.Int32,
					Value = empleado.legajo
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@fecNac",
					DbType = DbType.DateTime,
					Value = empleado.fecNac
				});

				query.Parameters.Add(new SqlParameter {
					ParameterName = "@sueldo",
					DbType = DbType.Double,
					Value = empleado.sueldo
				});

				conn.Open();
				query.ExecuteNonQuery();
				conn.Close();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
		
		public Empleado castDto(SqlDataReader data) {
			Empleado a = new Empleado {
				id = int.Parse(data["id"].ToString()),
				nombre = data["nombre"].ToString(),
				apellido = data["apellido"].ToString(),
				dni = data["dni"].ToString(),
				legajo = data["legajo"].ToString(),
				fecNac = DateTime.Parse(data["fecNac"].ToString()),
				sueldo = double.Parse(data["sueldo"].ToString())
			};

			return a;
		}
	}
}
