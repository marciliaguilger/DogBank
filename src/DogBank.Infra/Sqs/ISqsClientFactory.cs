using Amazon.SQS;

namespace DogBank.Infra.Sqs
{
    public interface ISqsClientFactory
    {
        IAmazonSQS GetSqsClient();
        string GetSqsQueue();
    }
}
