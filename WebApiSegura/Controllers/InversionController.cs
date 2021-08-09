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
    [RoutePrefix("api/Inversion")]
    [EnableCors(origins: "http://localhost:3000, https://api-internet-banking.azurewebsites.net", headers: "*", methods: "*")]
    public class InversionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Inversion inversion = new Inversion();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, CodigoMoneda, Monto, Interes, Liquidez
                                                            FROM Inversion WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        inversion.Codigo = sqlDataReader.GetInt32(0);
                        inversion.CodigoUsuario = sqlDataReader.GetInt32(1);
                        inversion.CodigoMoneda = sqlDataReader.GetInt32(2);
                        inversion.Monto = sqlDataReader.GetDecimal(3);
                        inversion.Interes = sqlDataReader.GetInt32(4);
                        inversion.Liquidez = sqlDataReader.GetDecimal(5);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(inversion);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Inversion> inversiones = new List<Inversion>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, CodigoMoneda, Monto, Interes, Liquidez
                                                            FROM Inversion", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Inversion inversion = new Inversion();
                        inversion.Codigo = sqlDataReader.GetInt32(0);
                        inversion.CodigoUsuario = sqlDataReader.GetInt32(1);
                        inversion.CodigoMoneda = sqlDataReader.GetInt32(2);
                        inversion.Monto = sqlDataReader.GetDecimal(3);
                        inversion.Interes = sqlDataReader.GetInt32(4);
                        inversion.Liquidez = sqlDataReader.GetDecimal(5);

                        inversiones.Add(inversion);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(inversiones);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Inversion inversion)
        {
            if (inversion == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Inversion (CodigoUsuario, CodigoMoneda, Monto, Interes, Liquidez) VALUES
                                                            (@CodigoUsuario, @CodigoMoneda, @Monto, @Interes, @Liquidez)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", inversion.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", inversion.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Monto", inversion.Monto);
                    sqlCommand.Parameters.AddWithValue("@Interes", inversion.Interes);
                    sqlCommand.Parameters.AddWithValue("@Liquidez", inversion.Liquidez);
                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(inversion);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Inversion inversion)
        {
            if (inversion == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Inversion SET CodigoUsuario = @CodigoUsuario,
                                                                               CodigoMoneda = @CodigoMoneda,
                                                                               Monto = @Monto, 
                                                                               Interes = @Interes,
                                                                               Liquidez = @Liquidez
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", inversion.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", inversion.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", inversion.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Monto", inversion.Monto);
                    sqlCommand.Parameters.AddWithValue("@Interes", inversion.Interes);
                    sqlCommand.Parameters.AddWithValue("@Liquidez", inversion.Liquidez);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(inversion);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Inversion WHERE Codigo = @Codigo", sqlConnection);

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
