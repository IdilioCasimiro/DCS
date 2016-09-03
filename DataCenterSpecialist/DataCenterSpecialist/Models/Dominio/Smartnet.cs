using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenterSpecialist.Models.Dominio
{
    public class Smartnet
    {
        public int SmartnetID { get; set; }

        //Propriedades para relacionamento
        public Equipamento Equipamento { get; set; }
        public int EquipamentoID { get; set; }

        //Self Properties
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Início da cobertura"), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataInicioCobertura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Fim da cobertura"), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataFimCobertura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Preço")]
        public decimal Preco { get; set; }

    }
}