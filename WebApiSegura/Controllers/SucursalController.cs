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
    [RoutePrefix("api/Sucursal")]
    public class SucursalController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Sucursal sucursal = new Sucursal();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, Nombre, Ubicacion,Correo, Telefono
                                                             FROM   Sucursal
                                                             WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        sucursal.Codigo = sqlDataReader.GetInt32(0);
                        sucursal.Nombre = sqlDataReader.GetString(1);
                        sucursal.Ubicacion = sqlDataReader.GetString(2);
                        sucursal.Correo = sqlDataReader.GetString(3);
                        sucursal.Telefono = sqlDataReader.GetInt32(4);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sucursal);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT  Codigo, Nombre, Ubicacion,Correo, Telefono
                                                             FROM   Sucursal", sqlConnection);
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Sucursal sucursal = new Sucursal();
                        sucursal.Codigo = sqlDataReader.GetInt32(0);
                        sucursal.Nombre = sqlDataReader.GetString(1);
                        sucursal.Ubicacion = sqlDataReader.GetString(2);
                        sucursal.Correo = sqlDataReader.GetString(3);
                        sucursal.Telefono = sqlDataReader.GetInt32(4);

                        sucursales.Add(sucursal);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(sucursales);
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Sucursal sucursal)
        {
            if (sucursal == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" INSERT INTO Sucursal (Nombre, Ubicacion,Correo, Telefono) 
                                         VALUES (@Nombre, @Ubicacion, @Correo,@Telefono)",
                                         sqlConnection);


                    sqlCommand.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Ubicacion", sucursal.Ubicacion);
                    sqlCommand.Parameters.AddWithValue("@Correo", sucursal.Correo);
                    sqlCommand.Parameters.AddWithValue("@Telefono", sucursal.Telefono);


                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sucursal);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Sucursal sucursal)
        {
            if (sucursal == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" UPDATE Sucursal
                                                        SET 

                                                          Nombre=  @Nombre, 
                                                         Ubicacion= @Ubicacion, 
                                                    Correo=     @Correo,
                                                        Telefono=  @Telefono
                                          WHERE Codigo = @Codigo",
                                         sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", sucursal.Codigo);
                    sqlCommand.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Ubicacion", sucursal.Ubicacion);
                    sqlCommand.Parameters.AddWithValue("@Correo", sucursal.Correo);
                    sqlCommand.Parameters.AddWithValue("@Telefono", sucursal.Telefono);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sucursal);
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
                        new SqlCommand(@" DELETE Sucursal WHERE Codigo = @Codigo",
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
