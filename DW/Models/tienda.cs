//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tienda
    {
        public int id { get; set; }
        public string nombre_tienda { get; set; }
        public int estado { get; set; }
        public string descripcion_tienda { get; set; }
        public string telefono_tienda { get; set; }
        public byte[] imagen_tienda { get; set; }
        public string correo_tienda { get; set; }
    }
}
