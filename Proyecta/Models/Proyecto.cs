using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecta.Models
{

    public class IProyecto
    {
        [Display(Name = "Nombre del proyecto")]
        [Required(ErrorMessage = "obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción del proyecto")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(512, ErrorMessage = "La propuesta no puede ser mayor a 256 caracteres")]
        public string Propuesta { get; set; }

        [Display(Name = "¿Qué ocupo?")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(512, ErrorMessage = "Los recursos no pueden ser mayor a 256 caracteres")]
        public string Recursos { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(20, ErrorMessage = "La provincia no puede ser mayor a 20 caracteres")]
        public string Provincia { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "obligatorio")]
        [StringLength(20, ErrorMessage = "El cantón no puede ser mayor a 20 caracteres")]
        public string Canton { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha final")]
        public DateTime FechaFinal { get; set; }

    }

    [MetadataType(typeof(IProyecto))]
    public partial class Proyecto
    {
        public List<Proyecto> Get3FeaturedProyectos()
        {
            ModeloDataContext ct = new ModeloDataContext();
            List<Proyecto> lista = (from a in ct.Proyectos select a).ToList();
            if (lista.Count() > 3)
            {
                lista = lista.GetRange(0, 3);
            }
            ct.Dispose();
            return lista;
        }

        public static List<Proyecto> GetProyectoByCategoria(string cat){
            try
            {
                ModeloDataContext ct = new ModeloDataContext();
                List<Proyecto> p = (from a in ct.Proyectos where a.Categoria == cat select a).ToList();
                ct.Dispose();
                return p;
            }
            catch (Exception e)
            {
                return new List<Proyecto>();
            }
        }

        public static List<Proyecto> Get3ProyectosByCategoria(string cat)
        {
            try
            {
                ModeloDataContext ct = new ModeloDataContext();
                List<Proyecto> p = (from a in ct.Proyectos where a.Categoria == cat select a).ToList();
                if (p.Count() > 3)
                {
                    p = p.GetRange(0, 3);
                }
                ct.Dispose();
                return p;
            }
            catch (Exception e)
            {
                return new List<Proyecto>();
            }
        }

        public Proyecto GetProyecto(Guid idProyecto) {
            ModeloDataContext ct = new ModeloDataContext();
            Proyecto consulta = (from a in ct.Proyectos where a.Id == idProyecto select a).FirstOrDefault();
            return consulta;
        }

        public static bool createProyecto(Proyecto p){
            try
            {
                ModeloDataContext ct = new ModeloDataContext();
                ct.Proyectos.InsertOnSubmit(p);
                ct.SubmitChanges();
                ct.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }




}