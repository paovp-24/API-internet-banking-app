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
    [RoutePrefix("api/Pago")]
    [EnableCors(origins: "http://localhost:3000, http://localhost:49220", headers: "*", methods: "*")]
    public class PagoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Pago pago = new Pago();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoServicio, CodigoTarjeta,
                                                            Fechahora, Monto
                                                            FROM Pago WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        pago.Codigo = sqlDataReader.GetInt32(0);
                        pago.CodigoServicio = sqlDataReader.GetInt32(1);
                        pago.CodigoTarjeta = sqlDataReader.GetInt32(2);
                        pago.Fechahora = sqlDataReader.GetDateTime(3);
                        pago.Monto = sqlDataReader.GetDecimal(4);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(pago);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoServicio, CodigoTarjeta,
                                                            FechaHora, Monto 
                                                            FROM Pago", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Pago pago = new Pago();
                        pago.Codigo = sqlDataReader.GetInt32(0);
                        pago.CodigoServicio = sqlDataReader.GetInt32(1);
                        pago.CodigoTarjeta = sqlDataReader.GetInt32(2);
                        pago.Fechahora = sqlDataReader.GetDateTime(3);
                        pago.Monto = sqlDataReader.GetDecimal(4);

                        pagos.Add(pago);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(pagos);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Pago pago)
        {
            if (pago == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Pago (CodigoServicio, CodigoTarjeta,
                                                            Fechahora, Monto) VALUES
                                                            (@CodigoServicio, @CodigoTarjeta,
                                                            @FechaHora, @Monto)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoServicio", pago.CodigoServicio);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", pago.CodigoTarjeta);
                    sqlCommand.Parameters.AddWithValue("@FechaHora", pago.Fechahora);
                    sqlCommand.Parameters.AddWithValue("@Monto", pago.Monto);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(pago);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Pago pago)
        {
            if (pago == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Pago SET CodigoServicio = @CodigoServicio,
                                                                               CodigoTarjeta = @CodigoTarjeta, 
                                                                               Fechahora = @Fechahora, 
                                                                               Monto = @Monto
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", pago.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoServicio", pago.CodigoServicio);
                    sqlCommand.Parameters.AddWithValue("@CodigoTarjeta", pago.CodigoTarjeta);
                    sqlCommand.Parameters.AddWithValue("@Fechahora", pago.Fechahora);
                    sqlCommand.Parameters.AddWithValue("@Monto", pago.Monto);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(pago);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Pago WHERE Codigo = @Codigo", sqlConnection);

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
