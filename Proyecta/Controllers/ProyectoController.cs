using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Proyecta.Controllers
{
    public class ProyectoController : Controller
    {
        //
        // GET: /Proyecto/
        

        public ActionResult Index(string id = "")
        {
            Models.Proyecto p = new Models.Proyecto();
            return View(p.GetProyecto(new Guid(id)));
        }

        public ActionResult BuscarProyecto()
        {
            return View();
        }

        public ActionResult Exito()
        {
            return View();
        }

        public ActionResult CrearProyecto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProyecto(Models.Proyecto p)
        {
            p.FechaCreacion = DateTime.Now;
            p.Id = Guid.NewGuid();
            //p.FechaFinal = DateTime.Now;
            //p.FechaInicio = DateTime.Now;
            p.Cedula_Proponiente = "000000000";
            p.Estado = 'N';
            HttpPostedFileBase image = Request.Files["imagen"];
            p.urlImagen = saveImage(image, p);
            
            if (ModelState.IsValid) {
                if (Models.Proyecto.createProyecto(p))
                {
                    return RedirectToAction("Exito", "Proyecto");
                }
            }
            return View(p);
        }

        protected String saveImage(HttpPostedFileBase image, Models.Proyecto client)
        {
            // Get the maximum file size
            HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
            int FileSizeLimit = (section.MaxRequestLength * 1024); // Kb => Bytes
            var r = "";

            if (image.ContentLength > 0 && FileSizeLimit >= image.ContentLength)
            {
                var imageName = Path.GetFileName(image.FileName);
                String fileType = "";

                try
                {
                    // Get mime type: if image/png => image
                    fileType = ((image.ContentType.ToString()).Split('/'))[0].ToString();
                    if (fileType.ToLower() == "image")
                    {
                        Directory.CreateDirectory(Server.MapPath("~/assets/images/Proyectos/" + client.Id.ToString()));
                        var imageURL = Path.Combine(Server.MapPath("~/assets/images/Proyectos/" + client.Id.ToString()), imageName);
                        image.SaveAs(imageURL);
                        r = "/assets/images/Proyectos/" + client.Id.ToString() + "/" + imageName;
                    }
                    else
                    {
                        ViewBag.errorImageClass = "show";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.errorImageClass = "show";
                }

            }
            else
            {
                if (image.ContentLength <= 0) // No image
                {
                    r = "/assets/images/logo.png";
                }
                else // Bigger than max size
                {
                    ViewBag.errorImageSizeClass = "show";
                }
            }
            return r;
        
        }

        public ActionResult Participar(Guid idProyecto)
        {
            ViewBag.idProyecto = idProyecto;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Participar(Proyecta.Models.Proyecto_Persona pp)
        {
            pp.IdPersona = new Guid(Session["idPersona"].ToString());
            return View(pp);
        }

    }
}
