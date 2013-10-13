using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecta.Models
{
    public class IRetroaliimentacion_Proyecto
    {
        [Display(Name = "Archivo")]
        [Required(ErrorMessage = "obligatorio")]
        public string Url_Archivo { get; set; }

        [Display(Name = "Comentario")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(256, ErrorMessage = "El comentario de no más de 256 caracteres")]
        public string Comentario { get; set; }
       
    }

    [MetadataType(typeof(IRetroaliimentacion_Proyecto))]
    public partial class Retroaliimentacion_Proyecto
    {
    }
}