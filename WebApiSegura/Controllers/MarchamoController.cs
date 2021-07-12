using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSegura.Models;

namespace WebApiSegura.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Marchamo")]
    public class MarchamoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Marchamo marchamo = new Marchamo();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, Placa,
                                                            Monto, FechaLimite, Estado
                                                            FROM Marchamo WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        marchamo.Codigo = sqlDataReader.GetInt32(0);
                        marchamo.CodigoUsuario = sqlDataReader.GetInt32(1);
                        marchamo.Placa = sqlDataReader.GetString(2);
                        marchamo.Monto = sqlDataReader.GetDecimal(3);
                        marchamo.FechaLimite = sqlDataReader.GetDateTime(4);
                        marchamo.Estado = sqlDataReader.GetString(5);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(marchamo);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Marchamo> marchamos = new List<Marchamo>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, Placa,
                                                            Monto, FechaLimite, Estado
                                                            FROM Marchamo", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Marchamo marchamo = new Marchamo();
                        marchamo.Codigo = sqlDataReader.GetInt32(0);
                        marchamo.CodigoUsuario = sqlDataReader.GetInt32(1);
                        marchamo.Placa = sqlDataReader.GetString(2);
                        marchamo.Monto = sqlDataReader.GetDecimal(3);
                        marchamo.FechaLimite = sqlDataReader.GetDateTime(4);
                        marchamo.Estado = sqlDataReader.GetString(5); ;

                        marchamos.Add(marchamo);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(marchamos);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Marchamo marchamo)
        {
            if (marchamo == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Marchamo (CodigoUsuario, Placa,
                                                            Monto, FechaLimite, Estado) VALUES
                                                            (@CodigoUsuario, @Placa,
                                                            @Monto, @FechaLimite, @Estado)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", marchamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Placa", marchamo.Placa);
                    sqlCommand.Parameters.AddWithValue("@Monto", marchamo.Monto);
                    sqlCommand.Parameters.AddWithValue("@FechaLimite", marchamo.FechaLimite);
                    sqlCommand.Parameters.AddWithValue("@Estado", marchamo.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(marchamo);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Marchamo marchamo)
        {
            if (marchamo == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Marchamo SET CodigoUsuario = @CodigoUsuario,
                                                                               Placa = @Placa,
                                                                               Monto = @Monto, 
                                                                               FechaLimite = @FechaLimite,
                                                                               Estado = @Estado,
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", marchamo.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", marchamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Placa", marchamo.Placa);
                    sqlCommand.Parameters.AddWithValue("@Monto", marchamo.Monto);
                    sqlCommand.Parameters.AddWithValue("@FechaLimite", marchamo.FechaLimite);
                    sqlCommand.Parameters.AddWithValue("@Estado", marchamo.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(marchamo);
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {
            if (id < 1)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Marchamo WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(id);
        }
    }
}