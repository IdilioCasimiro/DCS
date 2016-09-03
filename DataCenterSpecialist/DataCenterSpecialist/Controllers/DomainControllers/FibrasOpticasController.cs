using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataCenterSpecialist.Models;
using DataCenterSpecialist.Models.Contexto;

namespace DataCenterSpecialist.Controllers.DomainControllers
{
    public class FibrasOpticasController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: FibraOptica
        public async Task<ActionResult> Index()
        {
            return View(await db.FibraOptica.ToListAsync());
        }

        // GET: FibraOptica/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FibraOptica fibraOptica = await db.FibraOptica.FindAsync(id);
            if (fibraOptica == null)
            {
                return HttpNotFound();
            }
            return View(fibraOptica);
        }

        // GET: FibraOptica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FibraOptica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CaboID,NumeroCabo,Cor,RackA,EquipamentoA,PortaA,RackB,EquipamentoB,PortaB")] FibraOptica fibraOptica)
        {
            if (ModelState.IsValid)
            {
                db.FibraOptica.Add(fibraOptica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fibraOptica);
        }

        // GET: FibraOptica/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FibraOptica fibraOptica = await db.FibraOptica.FindAsync(id);
            if (fibraOptica == null)
            {
                return HttpNotFound();
            }
            return View(fibraOptica);
        }

        // POST: FibraOptica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CaboID,NumeroCabo,Cor,RackA,EquipamentoA,PortaA,RackB,EquipamentoB,PortaB")] FibraOptica fibraOptica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fibraOptica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fibraOptica);
        }

        // GET: FibraOptica/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FibraOptica fibraOptica = await db.FibraOptica.FindAsync(id);
            if (fibraOptica == null)
            {
                return HttpNotFound();
            }
            return View(fibraOptica);
        }

        // POST: FibraOptica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FibraOptica fibraOptica = await db.FibraOptica.FindAsync(id);
            db.FibraOptica.Remove(fibraOptica);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
