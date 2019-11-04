using System;
using System.Collections.Generic;

namespace Ariel.Paixao.Web.Razor.Dominios
{
    public partial class RegistroDefeitos
    {
        public int Id { get; set; }
        public DateTime DataChamado { get; set; }
        public int? IdTipoEquipamento { get; set; }
        public int? IdTipoDefeito { get; set; }
        public string Descricao { get; set; }

        public TiposDefeitos IdTipoDefeitoNavigation { get; set; }
        public TiposEquipamentos IdTipoEquipamentoNavigation { get; set; }
    }
}
