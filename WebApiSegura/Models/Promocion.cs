//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSegura.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promocion
    {
        public int Codigo { get; set; }
        public int CodigoEmisor { get; set; }
        public string Empresa { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFinalizacion { get; set; }
        public int Descuento { get; set; }
    
        public virtual Emisor Emisor { get; set; }
    }
}
