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
    using System.Xml.Serialization;

    
    public partial class Tb_Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       
        public Tb_Persona()
        {
            this.Tb_Ticket = new HashSet<Tb_Ticket>();
        }
    
        public int Persona_id { get; set; }
        public string Persona_nombre1 { get; set; }
        public string Persona_nombre2 { get; set; }
        public string Persona_apellido1 { get; set; }
        public string Persona_apellido2 { get; set; }
        public string Persona_dpi { get; set; }
        public string Persona_correo { get; set; }
        public string Persona_contrasenia { get; set; }
        public int RolUsuario_id { get; set; }
        public string Persona_Tarjeta { get; set; }
        public Nullable<int> Tarjeta_id_fk { get; set; }
    
        public virtual Tb_EmpTarjeta Tb_EmpTarjeta { get; set; }
        public virtual Tb_RolUsuario Tb_RolUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Ticket> Tb_Ticket { get; set; }
    }
}
