using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cliente : Models.Endereco
    {
        public int? Id { get; set; }
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? RG { get; set; }
        public DateTime? Data_Expedicao { get; set; }
        public string? Orgao_Expedicao { get; set; }
        public DateTime? Data_Nasc { get; set; }
        public string? Genero { get; set; }
        public string? Estado_Civil { get; set; }

    }
}