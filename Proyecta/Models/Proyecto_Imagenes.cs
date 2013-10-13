using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecta.Models
{
    public partial class Proyecto_Imagenes
    {
        public List<Proyecto_Imagene> getListaImagenesProyecto(Guid ID)
        {
            ModeloDataContext ct = new ModeloDataContext();
            List<Proyecto_Imagene> lista = (from a in ct.Proyecto_Imagenes where a.Id_Proyecto==ID select a).ToList();
            ct.Dispose();
            return lista;
        }
    }
}