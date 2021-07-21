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
    [RoutePrefix("api/Prestamo")]
    [EnableCors(origins: "http://localhost:3000, http://localhost:49220", headers: "*", methods: "*")]
    public class PrestamoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Prestamo prestamo = new Prestamo();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, CodigoMoneda, Monto, SaldoPendiente, TasaInteres, FechaEmision, FechaVencimiento, Estado
                                                            FROM Prestamo WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        prestamo.Codigo = sqlDataReader.GetInt32(0);
                        prestamo.CodigoUsuario = sqlDataReader.GetInt32(1);
                        prestamo.CodigoMoneda = sqlDataReader.GetInt32(2);
                        prestamo.Monto = sqlDataReader.GetDecimal(3);
                        prestamo.SaldoPendiente = sqlDataReader.GetDecimal(4);
                        prestamo.TasaInteres = sqlDataReader.GetInt32(5);
                        prestamo.FechaEmision = sqlDataReader.GetDateTime(6);
                        prestamo.FechaVencimiento = sqlDataReader.GetDateTime(7);
                        prestamo.Estado = sqlDataReader.GetString(8);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(prestamo);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, CodigoMoneda, Monto, SaldoPendiente, TasaInteres, FechaEmision, FechaVencimiento, Estado
                                                            FROM Prestamo", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Prestamo prestamo = new Prestamo();
                        prestamo.Codigo = sqlDataReader.GetInt32(0);
                        prestamo.CodigoUsuario = sqlDataReader.GetInt32(1);
                        prestamo.CodigoMoneda = sqlDataReader.GetInt32(2);
                        prestamo.Monto = sqlDataReader.GetDecimal(3);
                        prestamo.SaldoPendiente = sqlDataReader.GetDecimal(4);
                        prestamo.TasaInteres = sqlDataReader.GetInt32(5);
                        prestamo.FechaEmision = sqlDataReader.GetDateTime(6);
                        prestamo.FechaVencimiento = sqlDataReader.GetDateTime(7);
                        prestamo.Estado = sqlDataReader.GetString(8);

                        prestamos.Add(prestamo);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(prestamos);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Prestamo prestamo)
        {
            if (prestamo == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Prestamo (CodigoUsuario, CodigoMoneda, Monto, SaldoPendiente, TasaInteres, FechaEmision, FechaVencimiento, Estado) VALUES
                                                            (@CodigoUsuario, @CodigoMoneda, @Monto, @SaldoPendiente, @TasaInteres, @FechaEmision, @FechaVencimiento, @Estado)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", prestamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", prestamo.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    sqlCommand.Parameters.AddWithValue("@SaldoPendiente", prestamo.SaldoPendiente);
                    sqlCommand.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", prestamo.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaVencimiento", prestamo.FechaVencimiento);
                    sqlCommand.Parameters.AddWithValue("@Estado", prestamo.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(prestamo);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Prestamo prestamo)
        {
            if (prestamo == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Prestamo SET CodigoUsuario = @CodigoUsuario,
                                                                               CodigoMoneda = @CodigoMoneda,
                                                                               Monto = @Monto, 
                                                                               SaldoPendiente = @SaldoPendiente,
                                                                               TasaInteres = @TasaInteres,
                                                                               FechaEmision = @FechaEmision,
                                                                               FechaVencimiento = @FechaVencimiento,
                                                                               Estado = @Estado
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", prestamo.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", prestamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", prestamo.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    sqlCommand.Parameters.AddWithValue("@SaldoPendiente", prestamo.SaldoPendiente);
                    sqlCommand.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", prestamo.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaVencimiento", prestamo.FechaVencimiento);
                    sqlCommand.Parameters.AddWithValue("@Estado", prestamo.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(prestamo);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Prestamo WHERE Codigo = @Codigo", sqlConnection);

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
