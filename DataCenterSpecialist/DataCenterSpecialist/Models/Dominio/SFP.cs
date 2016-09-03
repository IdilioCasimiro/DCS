using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenterSpecialist.Models
{
    public class SFP
    {
        public int SFPID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Referência")]
        public string Referencia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }
    }
}