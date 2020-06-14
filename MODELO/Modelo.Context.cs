﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EZPCEntidades : DbContext
    {
        public EZPCEntidades()
            : base("name=EZPCEntidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarritoItem> CarritoItems { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<MetodoPago> MetodosPago { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<OrdenItem> OrdenItems { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoUsuario> TiposUsuario { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Oferta> Ofertas { get; set; }
        public virtual DbSet<Bitacora_Oferta> Bitacora_Oferta { get; set; }
        public virtual DbSet<Bitacora_Producto> Bitacora_Producto { get; set; }
    
        public virtual int Crear_Carrito(Nullable<int> id_usuario, Nullable<int> id_producto, Nullable<int> cantidad)
        {
            var id_usuarioParameter = id_usuario.HasValue ?
                new ObjectParameter("id_usuario", id_usuario) :
                new ObjectParameter("id_usuario", typeof(int));
    
            var id_productoParameter = id_producto.HasValue ?
                new ObjectParameter("id_producto", id_producto) :
                new ObjectParameter("id_producto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Crear_Carrito", id_usuarioParameter, id_productoParameter, cantidadParameter);
        }
    
        public virtual int Crear_Orden(Nullable<int> id_usuario, Nullable<int> id_pago, Nullable<int> id_direccion)
        {
            var id_usuarioParameter = id_usuario.HasValue ?
                new ObjectParameter("id_usuario", id_usuario) :
                new ObjectParameter("id_usuario", typeof(int));
    
            var id_pagoParameter = id_pago.HasValue ?
                new ObjectParameter("id_pago", id_pago) :
                new ObjectParameter("id_pago", typeof(int));
    
            var id_direccionParameter = id_direccion.HasValue ?
                new ObjectParameter("id_direccion", id_direccion) :
                new ObjectParameter("id_direccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Crear_Orden", id_usuarioParameter, id_pagoParameter, id_direccionParameter);
        }
    }
}
