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
using System.Collections;

namespace DataCenterSpecialist.Controllers.DomainControllers
{
    public class LicencasController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        // GET: Licencas
        public async Task<ActionResult> Index()
        {
            var licencas = db.Licencas.Include(l => l.Equipamento);
            return View(await licencas.ToListAsync());
        }

        // GET: Licencas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = await db.Licencas.FindAsync(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            return View(licenca);
        }

        // GET: Licencas/Create
        public ActionResult Create()
        {
            //Tipos de Licença
            SelectListItem permanente = new SelectListItem { Text = "Permanente", Value = "Permanente" };
            SelectListItem periodica = new SelectListItem { Text = "Periódica", Value = "Periódica" };
            SelectListItem anual = new SelectListItem { Text = "Anual", Value = "Anual" };

            //Colecção que vai conter os tipos de licença
            List<SelectListItem> Itens = new List<SelectListItem>()
            {
                permanente,
                periodica,
                anual
            };

            IEnumerable<SelectListItem> i = Itens;

            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "NomeEquipamento");
            ViewBag.TipoDeLicenca = i;

            return View();
        }

        // POST: Licencas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LicencaID,EquipamentoID,FabricanteLicenca,FornecedorLicenca,TipoDeLicenca,DataInicioCobertura,DataFimCobertura,Preço")] Licenca licenca)
        {
            if (ModelState.IsValid)
            {
                db.Licencas.Add(licenca);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "SerialNumber", licenca.EquipamentoID);
            return View(licenca);
        }

        // GET: Licencas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = await db.Licencas.FindAsync(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "SerialNumber", licenca.EquipamentoID);
            return View(licenca);
        }

        // POST: Licencas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LicencaID,EquipamentoID,FabricanteLicenca,FornecedorLicenca,TipoDeLicenca,DataInicioCobertura,DataFimCobertura,Preço")] Licenca licenca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EquipamentoID = new SelectList(db.Equipamentos, "EquipamentoID", "SerialNumber", licenca.EquipamentoID);
            return View(licenca);
        }

        // GET: Licencas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenca licenca = await db.Licencas.FindAsync(id);
            if (licenca == null)
            {
                return HttpNotFound();
            }
            return View(licenca);
        }

        // POST: Licencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Licenca licenca = await db.Licencas.FindAsync(id);
            db.Licencas.Remove(licenca);
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
