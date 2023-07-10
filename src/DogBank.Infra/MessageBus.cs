using Amazon.SQS;
using Amazon.SQS.Model;
using DogBank.Infra.Sqs;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DogBank.Infra
{
    public class MessageBus : IMessageBus
    {
        private readonly ILogger<MessageBus> _logger;
        private readonly ISqsClientFactory _sqsClientFactory;


        public MessageBus(ILogger<MessageBus> logger, ISqsClientFactory sqsClientFactory)
        {
            _logger = logger;
            _sqsClientFactory = sqsClientFactory;
        }


        //public async Task SendMessage(string qUrl, string messageBody)
        //{
        //    SendMessageResponse responseSendMsg =
        //      await _sqsClient.SendMessageAsync(qUrl, messageBody);

        //    _logger.LogInformation($"Message added to queue\n  {qUrl}");
        //    _logger.LogInformation($"HttpStatusCode: {responseSendMsg.HttpStatusCode}");
        //}

        public async Task<IEnumerable<T>> GetMessages<T>()
        {
            var messages = new List<T>();

            var request = new ReceiveMessageRequest
            {
                QueueUrl = _sqsClientFactory.GetSqsQueue(),
                MaxNumberOfMessages = 10,
                VisibilityTimeout = 10,
                WaitTimeSeconds = 10,
            };

            var response = await _sqsClientFactory.GetSqsClient().ReceiveMessageAsync(request);

            foreach (var message in response.Messages)
            {
                try
                {
                    var m = JsonSerializer.Deserialize<T>(message.Body);
                    if (m != null)
                        messages.Add(m);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "GetMessages error");
                }
            }

            return messages;
        }

        public async Task SendMessage<T>(T message)
        {
            var request = new SendMessageRequest
            {
                MessageBody = JsonSerializer.Serialize(message),
                QueueUrl = _sqsClientFactory.GetSqsQueue(),
            };

            var client = _sqsClientFactory.GetSqsClient();
            await client.SendMessageAsync(request,);
        }


    }
}
