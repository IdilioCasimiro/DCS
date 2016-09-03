using DataCenterSpecialist.Models.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenterSpecialist.Models
{
    public class Licenca
    {
        public int LicencaID { get; set; }

        //Propriedades para relacionamento
        [Required(ErrorMessage = "Campo obrigatório")]
        public Equipamento Equipamento { get; set; }
        public int EquipamentoID { get; set; }

        //Self properties

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Fabricante")]
        public string FabricanteLicenca { get; set; }

        [DisplayName("Fornecedor")]
        public string FornecedorLicenca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Tipo de Licença")]
        public string TipoDeLicenca { get; set; } //Permanente, Periódica, Anual

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Início da cobertura")]
        public DateTime DataInicioCobertura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), DisplayName("Fim da cobertura")]
        public DateTime DataFimCobertura { get; set; }
        public decimal Preço { get; set; }

    }
}