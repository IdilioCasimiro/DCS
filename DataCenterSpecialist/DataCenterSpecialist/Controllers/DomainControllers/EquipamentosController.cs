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
    public class EquipamentosController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: Equipamentos
        public async Task<ActionResult> Index()
        {
            return View(await db.Equipamentos.ToListAsync());
        }

        // GET: Equipamentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = await db.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // GET: Equipamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EquipamentoID,SerialNumber,Fabricante,NomeEquipamento,Localizacao,DataArquisicao")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                db.Equipamentos.Add(equipamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equipamento);
        }

        // GET: Equipamentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = await db.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EquipamentoID,SerialNumber,Fabricante,NomeEquipamento,Localizacao,DataArquisicao")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equipamento);
        }

        // GET: Equipamentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamento equipamento = await db.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Equipamento equipamento = await db.Equipamentos.FindAsync(id);
            db.Equipamentos.Remove(equipamento);
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
