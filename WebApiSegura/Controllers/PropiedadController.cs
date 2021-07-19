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
    [RoutePrefix("api/Propiedad")]
    [EnableCors(origins: "http://localhost:3000, http://localhost:49220", headers: "*", methods: "*")]
    public class PropiedadController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Propiedad propiedad = new Propiedad();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, Ubicacion, Dimension, Descripcion, Estado, PrecioFiscal
                                                            FROM Propiedad WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        propiedad.Codigo = sqlDataReader.GetInt32(0);
                        propiedad.CodigoUsuario = sqlDataReader.GetInt32(1);
                        propiedad.Ubicacion = sqlDataReader.GetString(2);
                        propiedad.Dimension = sqlDataReader.GetString(3);
                        propiedad.Descripcion = sqlDataReader.GetString(4);
                        propiedad.Estado = sqlDataReader.GetString(5);
                        propiedad.PrecioFiscal = sqlDataReader.GetDecimal(6);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(propiedad);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, Ubicacion, Dimension, Descripcion, Estado, PrecioFiscal
                                                            FROM Propiedad", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Propiedad propiedad = new Propiedad();
                        propiedad.Codigo = sqlDataReader.GetInt32(0);
                        propiedad.CodigoUsuario = sqlDataReader.GetInt32(1);
                        propiedad.Ubicacion = sqlDataReader.GetString(2);
                        propiedad.Dimension = sqlDataReader.GetString(3);
                        propiedad.Descripcion = sqlDataReader.GetString(4);
                        propiedad.Estado = sqlDataReader.GetString(5);
                        propiedad.PrecioFiscal = sqlDataReader.GetDecimal(6);

                        propiedades.Add(propiedad);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(propiedades);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Propiedad propiedad)
        {
            if (propiedad == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Propiedad (CodigoUsuario, Ubicacion, Dimension, Descripcion, Estado, PrecioFiscal) VALUES
                                                            (@CodigoUsuario, @CodigoMoneda, @Ubicacion, @Dimension, @Descripcion, @Estado, @PrecioFiscal)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", propiedad.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Ubicacion", propiedad.Ubicacion);
                    sqlCommand.Parameters.AddWithValue("@Dimension", propiedad.Dimension);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", propiedad.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Estado", propiedad.Estado);
                    sqlCommand.Parameters.AddWithValue("@PrecioFiscal", propiedad.PrecioFiscal);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(propiedad);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Propiedad propiedad)
        {
            if (propiedad == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Propiedad SET CodigoUsuario = @CodigoUsuario,
                                                                               Ubicacion = @Ubicacion,
                                                                               Dimension = @Dimension, 
                                                                               Descripcion = @Descripcion,
                                                                               Estado = @Estado,
                                                                               PrecioFiscal = @PrecioFiscal
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", propiedad.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", propiedad.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Ubicacion", propiedad.Ubicacion);
                    sqlCommand.Parameters.AddWithValue("@Dimension", propiedad.Dimension);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", propiedad.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Estado", propiedad.Estado);
                    sqlCommand.Parameters.AddWithValue("@PrecioFiscal", propiedad.PrecioFiscal);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(propiedad);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Propiedad WHERE Codigo = @Codigo", sqlConnection);

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
