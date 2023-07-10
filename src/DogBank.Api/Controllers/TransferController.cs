using DogBank.Api.Commands;
using DogBank.Infra;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace DogBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public TransferController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [HttpPost]
        public async Task<IActionResult> TransferAmount([FromBody] TransferAmountCommand transferAmountCommand)
        {
            await _messageBus.SendMessage(JsonSerializer.Serialize(transferAmountCommand));

            return Ok("Transferencia realizada com sucesso");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageBus.GetMessages<TransferAmountCommand>();

            return Ok(JsonSerializer.Serialize(messages));
        }

    }
}
