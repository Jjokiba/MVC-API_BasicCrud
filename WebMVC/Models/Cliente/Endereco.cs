using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Endereco
    {
        [Required]
        public string CEP { get; set; }
        [Required, Display(Name = "Rua")]
        public string Logadouro { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }

    }
}