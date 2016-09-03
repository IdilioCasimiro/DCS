using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataCenterSpecialist.Models.Contexto;
using DataCenterSpecialist.Models.Dominio;

namespace DataCenterSpecialist.Controllers.DomainControllers
{
    public class CabosEnergiaController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: CabosEnergia
        public async Task<ActionResult> Index()
        {
            return View(await db.CabosEnergia.ToListAsync());
        }

        // GET: CabosEnergia/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEnergia caboEnergia = await db.CabosEnergia.FindAsync(id);
            if (caboEnergia == null)
            {
                return HttpNotFound();
            }
            return View(caboEnergia);
        }

        // GET: CabosEnergia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabosEnergia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CaboEnergiaID,NumeroCaboEnergia,Rack,Equipamento,Fonte,PDU,Posicao")] CaboEnergia caboEnergia)
        {
            if (ModelState.IsValid)
            {
                db.CabosEnergia.Add(caboEnergia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(caboEnergia);
        }

        // GET: CabosEnergia/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEnergia caboEnergia = await db.CabosEnergia.FindAsync(id);
            if (caboEnergia == null)
            {
                return HttpNotFound();
            }
            return View(caboEnergia);
        }

        // POST: CabosEnergia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CaboEnergiaID,NumeroCaboEnergia,Rack,Equipamento,Fonte,PDU,Posicao")] CaboEnergia caboEnergia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caboEnergia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(caboEnergia);
        }

        // GET: CabosEnergia/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEnergia caboEnergia = await db.CabosEnergia.FindAsync(id);
            if (caboEnergia == null)
            {
                return HttpNotFound();
            }
            return View(caboEnergia);
        }

        // POST: CabosEnergia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CaboEnergia caboEnergia = await db.CabosEnergia.FindAsync(id);
            db.CabosEnergia.Remove(caboEnergia);
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
