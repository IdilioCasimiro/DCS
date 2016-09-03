using DataCenterSpecialist.Models.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCenterSpecialist.Controllers.DomainControllers
{
    //Custom ActionResult
    public class CustomActionResult<T> : ActionResult
    {
        public T Dados { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            string resultado = "resultado 8da action";
            context.HttpContext.Response.Write(resultado);
        }
    }
    public class PatchChordsController : Controller
    {
        ContextoCadastro cadastro = new ContextoCadastro();

        // GET: PatchChord
        public JsonResult NumeroCaboUnico(string numeroCabo)
        {
            bool resposta = false;

            int caboID = 0;

            if (int.TryParse(numeroCabo, out caboID))
            {
                resposta = cadastro.CabosEthernet.AsParallel().All(c => c.NumeroCabo != caboID);

                if (resposta)
                {
                    resposta = cadastro.FibraOptica.AsParallel().All(c => c.NumeroCabo != caboID);
                    if (resposta)
                        return Json(resposta, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                resposta = cadastro.CabosEnergia.AsParallel().All(c => c.NumeroCaboEnergia != numeroCabo);
            }

            return Json(resposta, JsonRequestBehavior.AllowGet);

        }
    }
}