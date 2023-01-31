using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        //Context
        private readonly EscuelaDBMVCContext context;

        //Inyección de dependencias
        public AulaController(EscuelaDBMVCContext context)
        {
            this.context = context;
        }

        //Todas
        public IActionResult Index()
        {
            return View(context.Aulas.ToList());
        }

        //Una sola
        private Aula TraerUna(int id)
        {
            return context.Aulas.Find(id);
        }

        //CREATE GET
        [HttpGet]
        public ActionResult Create()
        {
            Aula aula = new Aula();

            return View("Register");
        }

        //CREATE POST
        [HttpPost]
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Register", aula);
        }

        //DETAILS GET
        [HttpGet]
        public ActionResult Details(int id)
        {
            Aula aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }
            
            return View("Detalle", aula);
        }

        //EDIT GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }

            return View("Edit", aula);
        }

        //EDIT POST
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aula).State = EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(aula);
        }

        //DELETE GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }

            return View("Delete", aula);
        }

        //DELETE POST
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }

            context.Aulas.Remove(aula);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
