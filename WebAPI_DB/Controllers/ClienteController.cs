using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Models;
using WebAPI.Repository;
using System.Net.Http;
using System.Web;

namespace WebAPI_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/<controller>/
        [Route(""), HttpGet]
        public IActionResult Get()
        {
            ActionResult retorno;
            try
            {
                List<Cliente> ListaClientes = new ClienteRepository().selectCliente(null);
                retorno = Ok(ListaClientes);
            }
            catch (Exception ex)
            {
                retorno = BadRequest(new { error = ex.Message });
            }
            return retorno;
        }

        // GET api/<controller>/5
        [Route("{id}"),HttpGet]
        public IActionResult Get([FromRoute]int? id = null)
        {
            ActionResult retorno;
            try
            {
                List<Cliente> ListaClientes = new ClienteRepository().selectCliente(id);
                retorno = Ok(ListaClientes);
            }
            catch (Exception ex)
            {
                retorno = BadRequest(new { error = ex.Message });
            }
            return retorno;
        }

        // POST api/<controller>
        [Route(""), HttpPost]
        public ActionResult Post([FromBody] Cliente clienteNovo)
        {
            ActionResult retorno;
            try
            {
                if (new ClienteRepository().insertCliente(clienteNovo))
                    retorno = Ok( new { message = "Cliente criado com sucesso!" });
                else
                    throw new Exception("Algo Imprevisto, não foi possivel criar o cliente.");
            }
            catch (Exception ex)
            {
                retorno = BadRequest(new { error = ex.Message });
            }
            return retorno;
        }

        // PUT api/<controller>/5
        [Route("{id}"), HttpPut]
        public ActionResult Put(int id, [FromBody] Cliente clienteUpdate)
        {
            ActionResult retorno;
            try
            {
                clienteUpdate.Id = id;
                if (new ClienteRepository().updateCliente(clienteUpdate))
                    retorno = Ok( new { message = "Cliente atualizado com sucesso!" });
                else
                    throw new Exception("Algo Imprevisto, não foi possivel atualizar o cliente.");
            }
            catch (Exception ex)
            {
                retorno = BadRequest(new { error = ex.Message });
            }
            return retorno;
        }

        // DELETE api/<controller>/5
        [Route("{id}"), HttpDelete]
        public ActionResult Delete(int id)
        {
            ActionResult retorno;
            try
            {
                if (new ClienteRepository().deleteCliente(id))
                    retorno = Ok( new { message = "Cliente deletado com sucesso!" });
                else
                    throw new Exception("Algo Imprevisto, não foi possivel deletar o cliente.");
            }
            catch (Exception ex)
            {
                retorno = BadRequest(new { error = ex.Message });
            }
            return retorno;
        }
    }
}
