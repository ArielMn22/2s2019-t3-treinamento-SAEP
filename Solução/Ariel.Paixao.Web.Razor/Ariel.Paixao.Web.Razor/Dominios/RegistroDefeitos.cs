using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ariel.Paixao.Web.Razor.Dominios
{
    public partial class RegistroDefeitos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a data do chamado")]
        [DataType(DataType.Date)]
        [Display(Name ="Data Chamado")]
        public DateTime DataChamado { get; set; }

        [Required(ErrorMessage = "Insira o tipo de equipamento")]
        [Display (Name ="Tipo Equipamento")]
        public int? IdTipoEquipamento { get; set; }

        [Required(ErrorMessage = "Insira o tipo do defeito")]
        [Display(Name = "Tipo Defeito")]
        public int? IdTipoDefeito { get; set; }

        [Required(ErrorMessage = "Insira a descrição do defeito")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo Defeito")]
        public TiposDefeitos IdTipoDefeitoNavigation { get; set; }

        [Display(Name = "Tipo Equipamento")]
        public TiposEquipamentos IdTipoEquipamentoNavigation { get; set; }
    }
}
