﻿using System;
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
    [RoutePrefix("api/Error")]
    [EnableCors(origins: "http://localhost:3000, https://api-internet-banking.azurewebsites.net", headers: "*", methods: "*")]
    public class ErrorController : ApiController
    {
   
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Error error = new Error();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, FechaHora,
                                                            Fuente, Numero, Descripcion, Accion 
                                                            FROM Error WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        error.Codigo = sqlDataReader.GetInt32(0);
                        error.CodigoUsuario = sqlDataReader.GetInt32(1);
                        error.FechaHora = sqlDataReader.GetDateTime(2);
                        error.Fuente = sqlDataReader.GetString(3);
                        error.Numero = sqlDataReader.GetString(4);
                        error.Descripcion = sqlDataReader.GetString(5);
                        error.Accion = sqlDataReader.GetString(6);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(error);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Error> errores = new List<Error>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoUsuario, FechaHora,
                                                            Fuente, Numero, Descripcion, Accion
                                                            FROM Error", sqlConnection);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Error error = new Error();
                        error.Codigo = sqlDataReader.GetInt32(0);
                        error.CodigoUsuario = sqlDataReader.GetInt32(1);
                        error.FechaHora = sqlDataReader.GetDateTime(2);
                        error.Fuente = sqlDataReader.GetString(3);
                        error.Numero = sqlDataReader.GetString(4);
                        error.Descripcion = sqlDataReader.GetString(5);
                        error.Accion = sqlDataReader.GetString(6);

                        errores.Add(error);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(errores);
        }

        [HttpPost]
        public IHttpActionResult Ingresar(Error error)
        {
            if (error == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Error (CodigoUsuario, FechaHora,
                                                            Fuente, Numero, Descripcion, Vista, Accion) VALUES
                                                            (@CodigoUsuario, @FechaHora,
                                                            @Fuente, @Numero, @Descripcion, @Accion)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", error.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@FechaHora", error.FechaHora);
                    sqlCommand.Parameters.AddWithValue("@Fuente", error.Fuente);
                    sqlCommand.Parameters.AddWithValue("@Numero", error.Numero);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", error.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Accion", error.Accion);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(error);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Error error)
        {
            if (error == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["INTERNET_BANKING"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"UPDATE Error SET CodigoUsuario = @CodigoUsuario,
                                                                               FechaHora = @FechaHora,
                                                                               Fuente = @Fuente, 
                                                                               Numero = @Numero, 
                                                                               Descripcion = @Descripcion,
                                                                               Accion = @Accion
                                                                               WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", error.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", error.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@FechaHora", error.FechaHora);
                    sqlCommand.Parameters.AddWithValue("@Fuente", error.Fuente);
                    sqlCommand.Parameters.AddWithValue("@Numero", error.Numero);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", error.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Accion", error.Accion);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok(error);
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
                    SqlCommand sqlCommand = new SqlCommand(@"DELETE Error WHERE Codigo = @Codigo", sqlConnection);

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
