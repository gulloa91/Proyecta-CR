using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecta.Models
{
    public class IProyecto_Persona
    {
        [Display(Name = "¿Con qué puedo ayudar?")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(1024, ErrorMessage = "No puede ser mayor a 1024 caracteres")]
        public string Recursos { get; set; }

        [Display(Name = "¿Por qué quiero ayudar?")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(1024, ErrorMessage = "No puede ser mayor a 1024 caracteres")]
        public string Motivo { get; set; }
    }


    [MetadataType(typeof(IProyecto_Persona))]
    public partial class Proyecto_Persona 
    {

        public int insertarEnProyecto(Proyecto_Persona pp) {
            try
            {
                ModeloDataContext ct = new ModeloDataContext();
                ct.Proyecto_Personas.InsertOnSubmit(pp);
                ct.SubmitChanges();
                ct.Dispose();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
            
        }

        public List<Proyecto_Persona> getParticipantes(Guid idProyecto)
        {
            ModeloDataContext ct = new ModeloDataContext();
            List<Proyecto_Persona> lista = (from a in ct.Proyecto_Personas where a.IdProyecto == idProyecto select a).ToList();
            return lista;
        }

    }
}