//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalDesarrollo1._0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tb_Eventos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Eventos()
        {
            this.Tb_Publicacion = new HashSet<Tb_Publicacion>();
        }
    
        public int Eventos_id { get; set; }
        [Required(ErrorMessage = "Es necesario que igrese un nombre")]
        public string Evento_nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el Costo total del evento")]
        public decimal Evento_costo { get; set; }
        public string Evento_descripcion { get; set; }
        [Required(ErrorMessage = "Indique el tipo de evento")]
        public int TipoEvento_id { get; set; }
        [Required(ErrorMessage = "Indique el artista")]
        public int Artista_id { get; set; }
    
        public virtual Tb_Artistas Tb_Artistas { get; set; }
        public virtual Tb_TipoEvento Tb_TipoEvento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Publicacion> Tb_Publicacion { get; set; }
    }
}
