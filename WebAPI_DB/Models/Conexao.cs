using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebAPI.Models
{
    /// <summary>Só uma conexão compartilhada pra pegar o path do proejto e usar a conexao com o banco</summary>
    public class Conexao
    {
        private static string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.ToString() + @"\";
        public string ConnectionPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="""
                                                + path +
                                                @"App_Data\Banco.mdf"";Integrated Security=True";
    }
}