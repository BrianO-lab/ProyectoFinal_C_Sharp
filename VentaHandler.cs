using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> GetVenta()
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
                                Venta vent = new Venta();

                                vent.Id = Convert.ToInt32(dataReader["Id"]);
                                vent.Comentarios = dataReader["Comentarios"].ToString();

                                resultado.Add(vent);
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