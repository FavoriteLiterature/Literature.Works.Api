using System.Text;
using System.Text.Json;
using Literature.Works.Api.Application.Commands.Works;
using Literature.Works.Api.Options;
using MediatR;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Literature.Works.Api.Services;

public class RabbitMqService : BackgroundService
{
    private readonly IModel _channel;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly EventingBasicConsumer _consumer;
    private readonly string _queue;

    public RabbitMqService(IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMq> options)
    {
        _serviceScopeFactory = serviceScopeFactory;

        RabbitMq rabbitMqOptions = options.Value;
        
        var factory = new ConnectionFactory { 
            HostName = rabbitMqOptions.HostName,
            Port = rabbitMqOptions.Port,
            UserName = rabbitMqOptions.UserName,
            Password = rabbitMqOptions.Password, 
        };

        _queue = rabbitMqOptions.Queue;
            
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
        
        _channel.QueueDeclare(
            queue: _queue, 
            durable: true, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);
        
        _consumer = new EventingBasicConsumer(_channel);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Received += async (_, eventArgs) =>
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            
            var jsonString = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            
            var request = JsonSerializer.Deserialize<AddWorkRequest>(
                json: jsonString, 
                options: new JsonSerializerOptions 
                {
                    PropertyNameCaseInsensitive = true
                });

            if (request is null)
            {
                _channel.BasicReject(eventArgs.DeliveryTag, false);
            }
            else
            {
                await mediator.Send(request, stoppingToken);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            }
        };

        _channel.BasicConsume(_queue, false, _consumer);
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        base.Dispose();
    }
}