using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
	public class ConnectionDao
	{
		protected SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Parcial;Integrated Security=True");
	}
}
