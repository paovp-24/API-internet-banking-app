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
    [RoutePrefix("api/Promocion")]
    public class PromocionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Promocion promocion = new Promocion();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoEmisor, Empresa, FechaInicio,
                                                            FechaFinalizacion, Descuento
                                                            FROM Promocion WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        promocion.Codigo = sqlDataReader.GetInt32(0);
                        promocion.CodigoEmisor = sqlDataReader.GetInt32(1);
                        promocion.Empresa = sqlDataReader.GetString(2);
                        promocion.FechaInicio = sqlDataReader.GetDateTime(3);
                        promocion.FechaFinalizacion = sqlDataReader.GetDateTime(4);
                        promocion.Descuento = sqlDataReader.GetInt32(5);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(promocion);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Promocion> promociones = new List<Promocion>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoEmisor, Empresa, FechaInicio,
                                                            FechaFinalizacion, Descuento
                                                            FROM Promocion", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Promocion promocion = new Promocion();
                        promocion.Codigo = sqlDataReader.GetInt32(0);
                        promocion.CodigoEmisor = sqlDataReader.GetInt32(1);
                        promocion.Empresa = sqlDataReader.GetString(2);
                        promocion.FechaInicio = sqlDataReader.GetDateTime(3);
                        promocion.FechaFinalizacion = sqlDataReader.GetDateTime(4);
                        promocion.Descuento = sqlDataReader.GetInt32(5);

                        promociones.Add(promocion);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(promociones);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Promocion promocion)
        {
            if (promocion == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Promocion (CodigoEmisor, Empresa,
                                                            FechaInicio, FechaFinalizacion, Descuento) VALUES
                                                            (@CodigoEmisor, @Empresa, @FechaInicio
                                                            @FechaFinalizacion, @Descuento)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoEmisor", promocion.CodigoEmisor);
                    sqlCommand.Parameters.AddWithValue("@Empresa", promocion.Empresa);
                    sqlCommand.Parameters.AddWithValue("@FechaInicio", promocion.FechaInicio);
                    sqlCommand.Parameters.AddWithValue("@FechaFinalizacion", promocion.FechaFinalizacion);
                    sqlCommand.Parameters.AddWithValue("@Descuento", promocion.Descuento);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(promocion);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Promocion promocion)
        {
            if (promocion == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Promocion SET CodigoEmisor = @CodigoEmisor,
                                                                               Empresa = @Empresa,
                                                                               FechaInicio = @FechaInicio, 
                                                                               FechaFinalizacion = @FechaFinalizacion,
                                                                               Descuento = @Descuento
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", promocion.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoEmisor", promocion.CodigoEmisor);
                    sqlCommand.Parameters.AddWithValue("@Empresa", promocion.Empresa);
                    sqlCommand.Parameters.AddWithValue("@FechaInicio", promocion.FechaInicio);
                    sqlCommand.Parameters.AddWithValue("@FechaFinalizacion", promocion.FechaFinalizacion);
                    sqlCommand.Parameters.AddWithValue("@Descuento", promocion.Descuento);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(promocion);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Promocion WHERE Codigo = @Codigo", sqlConnection);

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