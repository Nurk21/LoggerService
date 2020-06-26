using MongoDB.Bson;
using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.BL.Services
{
    public interface ILogRequestsHandler
    {
        //Task Create(string jsonString);
        Task<List<string>> GetAllAsync();
    }
    public class LogRequestsHandler : ILogRequestsHandler
    {
        //public async Task Create(string jsonString)
        //{            
        //    string connectionString = "mongodb://localhost:27017";
        //    MongoClient client = new MongoClient(connectionString);
        //    IMongoDatabase database = client.GetDatabase("test");
        //    var collection = database.GetCollection<BsonDocument>("Logs");
        //    MongoDB.Bson.BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonString);
        //    await collection.InsertOneAsync(document);            

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
            //    var queueName = channel.QueueDeclare().QueueName;

            //    if (args.Length < 1)
            //    {
            //        Log("Exception : invalid number of arguments");
            //        Environment.ExitCode = 1;
            //        return;
            //    }

            //    foreach (var bindingKey in args)
            //    {
            //        channel.QueueBind(queue: queueName,
            //                          exchange: "topic_logs",
            //                          routingKey: bindingKey);
            //    }

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body.ToArray());
            //        var routingKey = ea.RoutingKey;
            //       // program logic
            //    };
            //    channel.BasicConsume(queue: queueName,
            //                         autoAck: true,
            //                         consumer: consumer);
        //}
        
        public async Task<List<string>> GetAllAsync()
        {
        string connectionString = "mongodb://localhost:27017";
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("test");
        var collection = database.GetCollection<BsonDocument>("Logs");
        var filter = new BsonDocument();
        List<string> logList = new List<string>();
        using (var cursor = await collection.FindAsync(filter))
        {
            while (await cursor.MoveNextAsync())
            {
                var logs = cursor.Current;
                foreach (var doc in logs)
                {
                    logList.Add(doc.ToString());
                }
            }
        }
        return logList;
        }
    }
}
