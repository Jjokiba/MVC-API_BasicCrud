using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ClienteController : Controller
    {
        private static string URLApi = "https://localhost:7093/api";
        // GET: Cliente
        public ActionResult Index()
        {
            var client = new RestClient(URLApi + @"/Cliente/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);            
            List<Cliente> Model = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);

            return View("~/Views/Cliente/GridCliente.cshtml", Model.AsEnumerable());
        }

        public ActionResult CreateUpdate(int? id = null)
        {
            Cliente model = new Cliente();

            if(id != null)
            {
                var client = new RestClient(URLApi + @"/Cliente/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                model = (JsonConvert.DeserializeObject<List<Cliente>>(response.Content)).FirstOrDefault();
            }

            return View("~/Views/Cliente/CreateUpdate.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateUpdate(Cliente clientePost)
        {
            Cliente model = new Cliente();

            if (ModelState.IsValid)
            {
                if (IsCpf(clientePost.CPF))
                {
                    if(clientePost.Id != null)
                    {
                        var client = new RestClient(URLApi + @"/Cliente/" + clientePost.Id);
                        var jsonDeserializer = new JsonDeserializer();
                        client.AddHandler("application/json", jsonDeserializer);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.PUT);
                        request.AddHeader("Content-Type", "application/json");
                        var body = JsonConvert.SerializeObject(clientePost);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        var response = client.Execute(request);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewData["Success"] = "Success";
                        }
                        else
                        {
                            //ModelState.AddModelError(, "Algo imprevisto aconteceu!");
                            ViewData["Error"] = ((RestSharp.RestResponseBase)response).Content;
                        }
                    }
                    else
                    {
                        var client = new RestClient(URLApi + @"/Cliente");
                        var jsonDeserializer = new JsonDeserializer();
                        client.AddHandler("application/json", jsonDeserializer);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        var body = JsonConvert.SerializeObject(clientePost);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        var response = client.Execute(request);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewData["Success"] = "Success";
                        }
                        else
                        {
                            //ModelState.AddModelError(, "Algo imprevisto aconteceu!");
                            ViewData["Error"] = ((RestSharp.RestResponseBase)response).Content;
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("CPF", "CPF Informado é inválido.");
                }
            }

            return View("~/Views/Cliente/CreateUpdate.cshtml", model);
        }

        public ActionResult Delete(int? id)
        {
            Cliente model = new Cliente();

            if (id != null)
            {
                var client = new RestClient(URLApi + @"/Cliente/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }

            return RedirectToAction("index");
        }

        #region  Auxilires
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        #endregion
    }
}