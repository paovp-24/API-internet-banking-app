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
    [Authorize]
    [RoutePrefix("api/Fiador")]
    public class FiadorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Fiador fiador = new Fiador();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoPrestamo, Cedula, Nombre, Apellidos, Ocupacion
                                                            FROM Fiador WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        fiador.Codigo = sqlDataReader.GetInt32(0);
                        fiador.CodigoPrestamo = sqlDataReader.GetInt32(1);
                        fiador.Cedula = sqlDataReader.GetString(2);
                        fiador.Nombre = sqlDataReader.GetString(3);
                        fiador.Apellidos = sqlDataReader.GetString(4);
                        fiador.Ocupacion = sqlDataReader.GetString(5);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(fiador);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Fiador> fiadores = new List<Fiador>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoPrestamo, Cedula, Nombre, Apellidos, Ocupacion
                                                            FROM Fiador", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Fiador fiador = new Fiador();
                        fiador.Codigo = sqlDataReader.GetInt32(0);
                        fiador.CodigoPrestamo = sqlDataReader.GetInt32(1);
                        fiador.Cedula = sqlDataReader.GetString(2);
                        fiador.Nombre = sqlDataReader.GetString(3);
                        fiador.Apellidos = sqlDataReader.GetString(4);
                        fiador.Ocupacion = sqlDataReader.GetString(5);

                        fiadores.Add(fiador);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(fiadores);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Fiador fiador)
        {
            if (fiador == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Fiador (CodigoPrestamo, Cedula, Nombre, Apellidos, Ocupacion) VALUES
                                                            (@CodigoPrestamo, @Cedula, @Nombre, @Apellidos, @Ocupacion)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoPrestamo", fiador.CodigoPrestamo);
                    sqlCommand.Parameters.AddWithValue("@Cedula", fiador.Cedula);
                    sqlCommand.Parameters.AddWithValue("@Nombre", fiador.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellidos", fiador.Apellidos);
                    sqlCommand.Parameters.AddWithValue("@Ocupacion", fiador.Ocupacion);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(fiador);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Fiador fiador)
        {
            if (fiador == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Fiador SET CodigoPrestamo = @CodigoPrestamo,
                                                                               Cedula = @Cedula,
                                                                               Nombre = @Nombre, 
                                                                               Apellidos = @Apellidos,
                                                                               Ocupacion = @Ocupacion
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", fiador.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoPrestamo", fiador.CodigoPrestamo);
                    sqlCommand.Parameters.AddWithValue("@Cedula", fiador.Cedula);
                    sqlCommand.Parameters.AddWithValue("@Nombre", fiador.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellidos", fiador.Apellidos);
                    sqlCommand.Parameters.AddWithValue("@Ocupacion", fiador.Ocupacion);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(fiador);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Fiador WHERE Codigo = @Codigo", sqlConnection);

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
