using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace bodegaAPP.Controllers
{
    public class ProductosController : Controller
    {
        private ProductosService.ProductoServiceClient proxy = new ProductosService.ProductoServiceClient();
        // GET: Productos

        public ActionResult Index(string id)
        {
            ProductosService.Producto[] productosCreados = proxy.ListarPorBodega(id);
            ViewData["Message"] = "Listado de Productos";
            ViewBag.Titulo1 = "Código de Producto";
            ViewBag.Titulo2 = "Nombre";
            ViewBag.Titulo3 = "Imagen";
            ViewBag.Titulo4 = "Precio";
            ViewBag.Titulo5 = "Categoría";
            ViewBag.Titulo6 = "Bodega";
            ViewBag.Titulo7 = "Activo";

            return View(productosCreados);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProductosService.Producto producto = proxy.ObtenerProducto(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle de Producto";
            ViewBag.Titulo1 = "Código de Producto";
            ViewBag.Titulo2 = "Nombre";
            ViewBag.Titulo3 = "Imagen";
            ViewBag.Titulo4 = "Precio";
            ViewBag.Titulo5 = "Categoría";
            ViewBag.Titulo6 = "Bodega";
            ViewBag.Titulo7 = "Activo";
            return View(producto);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosService.Producto producto = proxy.ObtenerProducto(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle del producto";
            ViewBag.Producto = producto;
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind (Include = "idproducto,nombre,imagen,precio,activo,idcategoria,idbodega")]
                            bodegaAPP.ProductosService.Producto producto)
        {
            if (ModelState.IsValid)
            {
                proxy.ModificarProducto(producto);
                return RedirectToAction("Index", new { id = producto.idbodega });
            }
            return View(producto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Include = "idproducto,nombre,imagen,precio,activo,idcategoria,idbodega")]
                            bodegaAPP.ProductosService.Producto producto)
        {
            if (ModelState.IsValid)
            {
                proxy.CrearProducto(producto);
                return RedirectToAction("Index", new { id = producto.idbodega });
            }
            return View(producto);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosService.Producto producto = proxy.ObtenerProducto(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductosService.Producto producto = proxy.ObtenerProducto(id);
            proxy.EliminarProducto(id);
            return RedirectToAction("Index", new { id = producto.idbodega });
        }
    }
}