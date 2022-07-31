using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Endereco
    {
        public string? CEP { get; set; }
        public string? Logadouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        [MaxLength(2)]
        public string? UF { get; set; }

    }
}