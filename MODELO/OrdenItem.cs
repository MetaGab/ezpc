//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODELO
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdenItem
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public Nullable<int> id_producto { get; set; }
        public Nullable<int> id_orden { get; set; }
        public Nullable<decimal> precio { get; set; }
    
        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
