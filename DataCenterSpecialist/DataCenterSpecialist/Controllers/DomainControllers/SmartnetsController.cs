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
    public class SmartnetsController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: Smartnets
        public async Task<ActionResult> Index()
        {
            var smartnets = db.Smartnets.Include(s => s.Equipamento);
            return View(await smartnets.ToListAsync());
        }

        // GET: Smartnets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartnet smartnet = await db.Smartnets.FindAsync(id);
            if (smartnet == null)
            {
                return HttpNotFound();
            }
            return View(smartnet);
        }

        // GET: Smartnets/Create
        public ActionResult Create()
        {
            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "NomeEquipamento");
            return View();
        }

        // POST: Smartnets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SmartnetID,EquipamentoID,Fornecedor,Descricao,DataInicioCobertura,DataFimCobertura,Preco")] Smartnet smartnet)
        {
            
            if (ModelState.IsValid)
            {
                db.Smartnets.Add(smartnet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "NomeEquipamento", smartnet.EquipamentoID);
            return View(smartnet);
        }

        // GET: Smartnets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartnet smartnet = await db.Smartnets.FindAsync(id);
            if (smartnet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "NomeEquipamento", smartnet.EquipamentoID);
            return View(smartnet);
        }

        // POST: Smartnets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SmartnetID,EquipamentoID,Fornecedor,Descricao,DataInicioCobertura,DataFimCobertura,Preco")] Smartnet smartnet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartnet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "NomeEquipamento", smartnet.EquipamentoID);
            return View(smartnet);
        }

        // GET: Smartnets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartnet smartnet = await db.Smartnets.FindAsync(id);
            if (smartnet == null)
            {
                return HttpNotFound();
            }
            return View(smartnet);
        }

        // POST: Smartnets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Smartnet smartnet = await db.Smartnets.FindAsync(id);
            db.Smartnets.Remove(smartnet);
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
