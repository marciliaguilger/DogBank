﻿using Amazon;
using Amazon.SQS;
using Microsoft.Extensions.Options;

namespace DogBank.Infra.Sqs
{
    public class SqsClientFactory : ISqsClientFactory
    {
        private readonly IOptions<SqsOptions> _options;

        public SqsClientFactory(IOptions<SqsOptions> options)
        {
            _options = options;
        }

        public IAmazonSQS GetSqsClient()
        {
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(_options.Value.SqsRegion),
                ServiceURL = $"https://sqs.{_options.Value.SqsRegion}.amazonaws.com"
            };

            return new AmazonSQSClient(_options.Value.IamAccessKey, _options.Value.IamSecretKey, config);
        }

        public string GetSqsQueue() =>
            $"https://sqs.{_options.Value.SqsRegion}.amazonaws.com/{_options.Value.SqsQueueId}/{_options.Value.SqsQueueName}";
    }

}
