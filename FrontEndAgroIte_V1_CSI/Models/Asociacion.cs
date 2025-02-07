namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Asociacion")]
    public partial class Asociacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asociacion()
        {
            Agricultor = new HashSet<Agricultor>();
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdAsociacion { get; set; }

        [StringLength(15)]
        public string Ruc { get; set; }

        [StringLength(150)]
        public string Razon_Social { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Dapartamento { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(9)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Representante { get; set; }

        public int? Integrantes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agricultor> Agricultor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Asociacion> Listar()
        {
            var asociacion = new List<Asociacion>();

            try
            {
                using (var db = new agroite())
                {

                    asociacion = db.Asociacion.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return asociacion;
        }
        public List<Asociacion> Buscar(string criterio)
        {
            var asociacion = new List<Asociacion>();

            try
            {
                using (var db = new agroite())
                {
                    asociacion = db.Asociacion
                        .Where(x => x.Razon_Social.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return asociacion;
        }

    }
}
