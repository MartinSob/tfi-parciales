using System.Data.SqlClient;

namespace DAL
{
	public class ConnectionDao
	{
		protected SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Parcial2;Integrated Security=True");
	}
}
