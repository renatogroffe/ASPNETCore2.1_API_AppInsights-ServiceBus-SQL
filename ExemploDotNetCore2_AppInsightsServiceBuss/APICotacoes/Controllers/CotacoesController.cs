using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using APICotacoes.Data;
using APICotacoes.Models;

namespace APICotacoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacoesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cotacao>> Get(
            [FromServices]ApplicationDbContext context)
        {
            return context.Cotacoes.ToList();
        }

        [HttpGet("carregar")]
        public object CarregarCotacoes(
            [FromServices]ServiceBusConfigurations configurations)
        {
            string conteudo = "Solicitação de Carga - " +
                $"API Cotacoes - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            var body = Encoding.UTF8.GetBytes(conteudo);

            var client = new QueueClient(
                configurations.ConnectionString,
                configurations.QueueName,
                ReceiveMode.ReceiveAndDelete);
            client.SendAsync(new Message(body)).Wait();

            return new
            {
                Resultado = "Mensagem encaminhada com sucesso"
            };
        }
    }
}