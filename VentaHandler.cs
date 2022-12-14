using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> resultado = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                resultado.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }
    }
}