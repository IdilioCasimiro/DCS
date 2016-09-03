using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCenterSpecialist.Models.Dominio
{
    public class CaboEnergia
    {
        public int CaboEnergiaID { get; set; }

        [Remote("NumeroCaboUnico","PatchChords", ErrorMessage = "Este ID já foi atribuído"), DisplayName("ID do Cabo")]
        public string NumeroCaboEnergia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Rack")]
        public string Rack { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Equipamento")]
        public string Equipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Fonte (A/B)")]
        public string Fonte { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("PDU (A/B)")]
        public string PDU { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Posição")]
        public string Posicao { get; set; }
    }
}