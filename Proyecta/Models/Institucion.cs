using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecta.Models
{
    public class IInstitucion
    {
        [Display(Name = "Cédula de la persona encargada")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(20, ErrorMessage = "Cédula de no más de 20 caracteres")]
        public string id_Persona { get; set; }

        [Display(Name = "Nombre de la institución")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(20, ErrorMessage = "El nombre de no más de 20 caracteres")]
        public string Nombre_Institución { get; set; }

        [Display(Name = "Cédula jurídica de la institución")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(20, ErrorMessage = "Cédula jurídica de no más de 20 caracteres")]
        public string Cedula_Representante{ get; set; }

        [Display(Name = "Logotipo de la empresa")]
        public string urlLogo { get; set; }
    }

    [MetadataType(typeof(IInstitucion))]
    public partial class Institucion
    {
    }
}