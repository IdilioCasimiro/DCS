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
    public class SFPsController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: SFPs
        public async Task<ActionResult> Index()
        {
            return View(await db.SFPs.ToListAsync());
        }

        // GET: SFPs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SFP sFP = await db.SFPs.FindAsync(id);
            if (sFP == null)
            {
                return HttpNotFound();
            }
            return View(sFP);
        }

        // GET: SFPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SFPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SFPID,Fabricante,Referencia,Descricao,Quantidade")] SFP sFP)
        {
            if (ModelState.IsValid)
            {
                db.SFPs.Add(sFP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sFP);
        }

        // GET: SFPs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SFP sFP = await db.SFPs.FindAsync(id);
            if (sFP == null)
            {
                return HttpNotFound();
            }
            return View(sFP);
        }

        // POST: SFPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SFPID,Fabricante,Referencia,Descricao,Quantidade")] SFP sFP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sFP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sFP);
        }

        // GET: SFPs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SFP sFP = await db.SFPs.FindAsync(id);
            if (sFP == null)
            {
                return HttpNotFound();
            }
            return View(sFP);
        }

        // POST: SFPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SFP sFP = await db.SFPs.FindAsync(id);
            db.SFPs.Remove(sFP);
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
