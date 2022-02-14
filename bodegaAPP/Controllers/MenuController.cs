using bodegaAPP.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using System.Text;

namespace bodegaAPP.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bodegawsrest20220213174454.azurewebsites.net/BodegaService.svc/bodegauser/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Bodega bodegaObtenida = js.Deserialize<Bodega>(tramajson);
            if(bodegaObtenida == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Bodega";
            ViewBag.Titulo1 = "Codigo";
            ViewBag.Titulo2 = "Nombre";
            ViewBag.Titulo3 = "Direccion";
            ViewBag.Titulo4 = "Contacto";
            ViewBag.Titulo5 = "Telefono";
            ViewBag.Titulo6 = "Latitud";
            ViewBag.Titulo7 = "Longitud";
            ViewBag.Titulo8 = "Activo";
            return View(bodegaObtenida);
        }

        public ActionResult Edit(string id1)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bodegawsrest20220213174454.azurewebsites.net/BodegaService.svc/bodegas/" + id1);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Bodega bodegaObtenida = js.Deserialize<Bodega>(tramajson);
            if (bodegaObtenida == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Editar bodega";
            return View(bodegaObtenida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, idbodega, nombre, direccion, contacto, telefono, latitud, longitud, activo, iduser")] bodegaAPP.Dominio.Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(bodega);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bodegawsrest20220213174454.azurewebsites.net/BodegaService.svc/bodegas");
                request.Method = "PUT";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();

                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        public ActionResult Producto(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bodegawsrest20220213174454.azurewebsites.net/BodegaService.svc/bodegauser/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Bodega bodegaObtenida = js.Deserialize<Bodega>(tramajson);
            if (bodegaObtenida == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Bodega";
            ViewBag.Titulo1 = "Codigo";
            ViewBag.Titulo2 = "Nombre";
            ViewBag.Titulo3 = "Direccion";
            ViewBag.Titulo4 = "Contacto";
            ViewBag.Titulo5 = "Telefono";
            ViewBag.Titulo6 = "Latitud";
            ViewBag.Titulo7 = "Longitud";
            ViewBag.Titulo8 = "Activo";
            return View(bodegaObtenida);
        }
    }
}