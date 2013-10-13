using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecta.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Crear()
        {
            return View();
        }

        // GET: /Usuario/

        public ActionResult Exito()
        {
            return View();
        }

        // GET: /Usuario/EscogerTipo

        public ActionResult EscogerTipo()
        {
            return View();
        }

        // POST: /Usuario/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Proyecta.Models.Usuario us)
        {
            us.NombreUsuario = us.Correo;

            if (ModelState.IsValid)
            {
                
                if (us.CreateUsario(us))
                {
                    return RedirectToAction("Exito");
                   
                }
            }
            return View(us);
        }

    }
}
