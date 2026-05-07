using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.producto;

namespace Api.Controllers
{
    public class productoController : Controller

    {
        private IProductoService _productoService;

        public productoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        
        // GET: productoController
        public ActionResult Index()
        {
            return  View();
        }

        // GET: productoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: productoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: productoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: productoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
