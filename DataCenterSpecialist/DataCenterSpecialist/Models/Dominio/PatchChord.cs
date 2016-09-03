using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCenterSpecialist.Models.Dominio
{
    public class PatchChord
    {
        
        public int CaboID { get; set; }

        [Remote("NumeroCaboUnico", "PatchChords", ErrorMessage = "Este ID já foi atribuído!")]
        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("ID do Cabo")]
        public int NumeroCabo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Rack A")]
        public string RackA { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Equipamento A")]
        public string EquipamentoA { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Porta A")]
        public string PortaA { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Rack B")]
        public string RackB { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Equipamento B")]
        public string EquipamentoB { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Porta B")]
        public string PortaB { get; set; }

    }
}