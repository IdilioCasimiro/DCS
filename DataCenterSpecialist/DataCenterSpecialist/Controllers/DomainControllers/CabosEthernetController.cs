using DataCenterSpecialist.Models;
using DataCenterSpecialist.Models.Contexto;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataCenterSpecialist.Controllers.DomainControllers
{
    public class CabosEthernetController : Controller
    {
        private ContextoCadastro db = new ContextoCadastro();

        [Authorize]
        public async Task<ActionResult> Index(string ordem, int numero = 0)
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Mensagem = "Não tem permissão para aceder a página solicitada";
                return View("_LoginPartial", ViewBag);
            }
            
            Trace.WriteLine("Mensagem");
            ViewBag.Ordem = String.IsNullOrEmpty(ordem) ? "ascendente" : "";

            var cabosEthernet = from cabos in db.CabosEthernet
                                select cabos;

            if (numero != 0)
            {
                cabosEthernet = cabosEthernet.Where(n => n.NumeroCabo == numero);
            }

            switch (ordem)
            {
                case "ascendente":
                    cabosEthernet = cabosEthernet.OrderBy(c => c.CaboID);
                    break;

                default:
                    cabosEthernet = cabosEthernet.OrderByDescending(c => c.CaboID);
                    break;
            }

            return View(await cabosEthernet.ToListAsync());
        }

        // GET: CabosEthernet/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEthernet caboEthernet = await db.CabosEthernet.FindAsync(id);
            if (caboEthernet == null)
            {
                return HttpNotFound();
            }
            return View(caboEthernet);
        }

        // GET: CabosEthernet/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult IDUnico(int numeroCabo)
        {
            bool resposta = db.CabosEthernet.AsParallel().All(p => p.NumeroCabo != numeroCabo);
            return Json(resposta, JsonRequestBehavior.AllowGet);
        }

        // POST: CabosEthernet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CaboID,NumeroCabo,Cor,RackA,EquipamentoA,PortaA,RackB,EquipamentoB,PortaB")] CaboEthernet caboEthernet)
        {
            if (ModelState.IsValid)
            {
                db.CabosEthernet.Add(caboEthernet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(caboEthernet);
        }

        // GET: CabosEthernet/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEthernet caboEthernet = await db.CabosEthernet.FindAsync(id);
            if (caboEthernet == null)
            {
                return HttpNotFound();
            }
            return View(caboEthernet);
        }

        // POST: CabosEthernet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CaboID,NumeroCabo,Cor,RackA,EquipamentoA,PortaA,RackB,EquipamentoB,PortaB")] CaboEthernet caboEthernet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caboEthernet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(caboEthernet);
        }

        // GET: CabosEthernet/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaboEthernet caboEthernet = await db.CabosEthernet.FindAsync(id);
            if (caboEthernet == null)
            {
                return HttpNotFound();
            }
            return View(caboEthernet);
        }

        // POST: CabosEthernet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CaboEthernet caboEthernet = await db.CabosEthernet.FindAsync(id);
            db.CabosEthernet.Remove(caboEthernet);
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
