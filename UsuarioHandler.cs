using System.Data.SqlClient;

namespace ProyectoFinal

{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> GetUsuario()
        {
            List<Usuario> resultado = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuar = new Usuario();

                                usuar.Id = Convert.ToInt32(dataReader["Id"]);
                                usuar.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuar.Nombre = dataReader["Nombre"].ToString();
                                usuar.Apellido = dataReader["Apellido"].ToString();
                                usuar.Contraseņa = dataReader["Contraseņa"].ToString();
                                usuar.Mail = dataReader["Mail"].ToString();

                                resultado.Add(usuar);
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