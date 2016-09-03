using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenterSpecialist.Models.Dominio
{
    public class Equipamento
    {
        public int EquipamentoID { get; set; }

        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Equipamento")]
        public string NomeEquipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!"), DisplayName("Localização")]
        public string Localizacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}"), DisplayName("Data de Compra")]
        public DateTime DataArquisicao { get; set; }

        //Propriedades para relacionamentos
        public List<Licenca> Licencas { get; set; }
        public List<Smartnet> Smartnets { get; set; }
    }
}