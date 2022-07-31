using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Cliente : Models.Endereco
    {
        public int? Id { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        public string RG { get; set; }
        [Display(Name = "Data expedição")]
        public DateTime? Data_Expedicao { get; set; }
        [Display(Name = "Orgão Expedição")]
        public string Orgao_Expedicao { get; set; }
        [Required, Display(Name = "Data de Nascimento")]
        public DateTime? Data_Nasc { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required, Display(Name = "Estado Civl")]
        public string Estado_Civil { get; set; }

    }
}