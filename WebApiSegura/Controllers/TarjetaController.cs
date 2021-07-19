using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSegura.Models;


namespace WebApiSegura.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Tarjeta")]
    [EnableCors(origins: "http://localhost:3000, http://localhost:49220", headers: "*", methods: "*")]
    public class TarjetaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Tarjeta tarjeta = new Tarjeta();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoEmisor, 
                                                             Numero, FechaEmision, FechaVencimiento, Estado
                                                             FROM   Tarjeta
                                                             WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        tarjeta.Codigo = sqlDataReader.GetInt32(0);
                        tarjeta.CodigoEmisor = sqlDataReader.GetInt32(1);

                        tarjeta.Numero = sqlDataReader.GetString(2);
                        tarjeta.FechaEmision = sqlDataReader.GetDateTime(3);
                        tarjeta.FechaVencimiento = sqlDataReader.GetDateTime(4);
                        tarjeta.Estado = sqlDataReader.GetString(5);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(tarjeta);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoEmisor,  Numero, 
                                                                FechaEmision, FechaVencimiento, Estado
                                                             FROM   Tarjeta", sqlConnection);
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Tarjeta tarjeta = new Tarjeta();

                        tarjeta.Codigo = sqlDataReader.GetInt32(0);
                        tarjeta.CodigoEmisor = sqlDataReader.GetInt32(1);

                        tarjeta.Numero = sqlDataReader.GetString(2);
                        tarjeta.FechaEmision = sqlDataReader.GetDateTime(3);
                        tarjeta.FechaVencimiento = sqlDataReader.GetDateTime(4);
                        tarjeta.Estado = sqlDataReader.GetString(5);

                        tarjetas.Add(tarjeta);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(tarjetas);
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Tarjeta tarjeta)
        {
            if (tarjeta == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" INSERT INTO Tarjeta (CodigoEmisor,  Numero, 
                                                                FechaEmision, FechaVencimiento, Estado) 
                                         VALUES (@CodigoEmisor, @Numero, @FechaEmision, @FechaVencimiento, @Estado)",
                                         sqlConnection);


                    sqlCommand.Parameters.AddWithValue("@CodigoEmisor", tarjeta.CodigoEmisor);

                    sqlCommand.Parameters.AddWithValue("@Numero", tarjeta.Numero);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", tarjeta.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaVencimiento", tarjeta.FechaVencimiento);
                    sqlCommand.Parameters.AddWithValue("@Estado", tarjeta.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(tarjeta);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Tarjeta tarjeta)
        {
            if (tarjeta == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" UPDATE Tarjeta
                                                        SET CodigoEmisor = @CodigoEmisor, 
                                                        
                                                            Numero= @Numero, 
                                                            FechaEmision= @FechaEmision, 
                                                            FechaVencimiento = @FechaVencimiento, 
                                                            Estado = @Estado 
                                          WHERE Codigo = @Codigo",
                                         sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", tarjeta.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoEmisor", tarjeta.CodigoEmisor);

                    sqlCommand.Parameters.AddWithValue("@Numero", tarjeta.Numero);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", tarjeta.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaVencimiento", tarjeta.FechaVencimiento);
                    sqlCommand.Parameters.AddWithValue("@Estado", tarjeta.Estado);


                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(tarjeta);
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {
            if (id < 1)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" DELETE Tarjeta WHERE Codigo = @Codigo",
                                         sqlConnection);

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