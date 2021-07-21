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
    [Authorize]
    [RoutePrefix("api/Emisor")]
    [EnableCors(origins: "http://localhost:3000, http://localhost:49220", headers: "*", methods: "*")]
    public class EmisorController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Emisor emisor = new Emisor();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, Descripcion, Prefijo,NumeroDigitos
                                                             FROM   Emisor
                                                             WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        emisor.Codigo = sqlDataReader.GetInt32(0);
                        emisor.Descripcion = sqlDataReader.GetString(1);
                        emisor.Prefijo = sqlDataReader.GetString(2);
                        emisor.NumeroDigitos = sqlDataReader.GetInt32(3);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(emisor);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Emisor> emisores = new List<Emisor>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, Descripcion, Prefijo,NumeroDigitos
                                                             FROM   Emisor", sqlConnection);
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Emisor emisor = new Emisor();
                        emisor.Codigo = sqlDataReader.GetInt32(0);
                        emisor.Descripcion = sqlDataReader.GetString(1);
                        emisor.Prefijo = sqlDataReader.GetString(2);
                        emisor.NumeroDigitos = sqlDataReader.GetInt32(3);

                        emisores.Add(emisor);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(emisores);
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Emisor emisor)
        {
            if (emisor == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" INSERT INTO Emisor (Descripcion, Prefijo,NumeroDigitos) 
                                         VALUES (@Descripcion, @Prefijo, @NumeroDigitos)",
                                         sqlConnection);


                    sqlCommand.Parameters.AddWithValue("@Descripcion", emisor.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Prefijo", emisor.Prefijo);
                    sqlCommand.Parameters.AddWithValue("@NumeroDigitos", emisor.NumeroDigitos);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(emisor);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Emisor emisor)
        {
            if (emisor == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" UPDATE Emisor
                                                        SET 
                                                            Descripcion = @Descripcion,
                                                            Prefijo = @Prefijo,
                                                             NumeroDigitos = @NumeroDigitos
                                          WHERE Codigo = @Codigo",
                                         sqlConnection);


                    sqlCommand.Parameters.AddWithValue("@Codigo", emisor.Codigo);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", emisor.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Prefijo", emisor.Prefijo);
                    sqlCommand.Parameters.AddWithValue("@NumeroDigitos", emisor.NumeroDigitos);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(emisor);
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
                        new SqlCommand(@" DELETE Emisor WHERE Codigo = @Codigo",
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