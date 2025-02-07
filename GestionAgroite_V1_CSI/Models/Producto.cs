namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
         
            DetalleCompra = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int IdProducto { get; set; }

        public int? IdCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_Producto { get; set; }

        public decimal Precio_Referencial { get; set; }

        [StringLength(100)]
        public string Imagenes_Producto { get; set; }

        [StringLength(200)]
        public string Descripcion_Producto { get; set; }

        [StringLength(50)]
        public string Fecha_Inicio { get; set; }

        [StringLength(50)]
        public string Fecha_Fin { get; set; }

        public decimal? Cantidad_Producida { get; set; }

        public int? IdUnidadVolumen { get; set; }

        public int? IdFrecuencia { get; set; }

        public int? IdAsociacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       

        public virtual Asociacion Asociacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

        public virtual Frecuencia Frecuencia { get; set; }

        public virtual UnidadVolumen UnidadVolumen { get; set; }

        public List<Producto> Listar()
        {
            var producto = new List<Producto>();

            try
            {
                using (var db = new agroite())
                {
                    producto = db.Producto.Include("Asociacion").Include("Frecuencia").Include("UnidadVolumen").Include("Categoria").ToList();

                }

            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }
        public List<Producto> Buscar(string criterio)
        {
            var usuarios = new List<Producto>();

            try
            {
                using (var db = new agroite())
                {

                    usuarios = db.Producto
                       .Where(x => x.Nombre_Producto.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }

        public Producto Obtener(int id)
        {
            var producto = new Producto();
            try
            {
                using (var db = new agroite())
                {
                    producto = db.Producto.Include("Asociacion").Include("UnidadVolumen").Include("Frecuencia").Include("Categoria").Where(x => x.IdProducto == id)
                                      .SingleOrDefault();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public ViewModel vmObtener(int id)
        {
            var viewModel = new ViewModel();
            var oUnidadVolumen = new UnidadVolumen();
            var oFrecuencia = new Frecuencia();
            var oAsociacion = new Asociacion();
            var oCategoria = new Categoria();
            try
            {
                using (var db = new agroite())
                {
                    viewModel.oProducto = db.Producto.Include("Categoria").Include("UnidadVolumen").Include("Frecuencia").Include("Asociacion").Where(x => x.IdProducto == id).FirstOrDefault();
                    viewModel.unidadVolumen = oUnidadVolumen.Listar();
                    viewModel.frecuencia = oFrecuencia.Listar();
                    viewModel.asociacion = oAsociacion.Listar();
                    viewModel.categoria = oCategoria.Listar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return viewModel;
        }
        public ViewModel vmInstancia()
        {
            var viewModel = new ViewModel();

            var oUnidadVolumen = new UnidadVolumen();
            var oFrecuencia = new Frecuencia();
            var oAsociacion = new Asociacion();
            var oCategoria = new Categoria();
            try
            {
                viewModel.oProducto = new Producto();
                viewModel.unidadVolumen = oUnidadVolumen.Listar();
                viewModel.frecuencia = oFrecuencia.Listar();
                viewModel.asociacion = oAsociacion.Listar();
                viewModel.categoria = oCategoria.Listar();
            }
            catch (Exception)
            {
                throw;
            }
            return viewModel;
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new agroite())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdProducto > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
