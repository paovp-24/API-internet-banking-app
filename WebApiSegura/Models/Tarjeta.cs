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
    
    public partial class Tarjeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarjeta()
        {
            this.Cuenta_Credito = new HashSet<Cuenta_Credito>();
            this.Cuenta_Debito = new HashSet<Cuenta_Debito>();
            this.Pagoes = new HashSet<Pago>();
        }
    
        public int Codigo { get; set; }
        public int CodigoEmisor { get; set; }
        public string Numero { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuenta_Credito> Cuenta_Credito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuenta_Debito> Cuenta_Debito { get; set; }
        public virtual Emisor Emisor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pagoes { get; set; }
    }
}
