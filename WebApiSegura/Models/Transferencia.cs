//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSegura.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transferencia
    {
        public int Codigo { get; set; }
        public Nullable<int> CuentaOrigen { get; set; }
        public Nullable<int> CuentaDestino { get; set; }
        public Nullable<System.DateTime> FechaHora { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Estado { get; set; }
    }
}