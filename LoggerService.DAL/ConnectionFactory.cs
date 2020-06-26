using LoggerService.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerService.DAL
{
    public interface IConnectionFactory
    {
        //    MongoClient client
        //}
        //public class ConnectionFactory : IConnectionFactory
        //{
        //    private readonly string _connectionString;

        //    public ConnectionFactory(IOptions<AppSettings> appSettings)
        //    {
        //        _connectionString = appSettings.Value.ConnectionString;
        //    }

        //    public SqlConnection GetOpenedConnection()
        //    {
        //        var connection = new SqlConnection(_connectionString);
        //        connection.Open();
        //        return connection;
        //    }
    }
}
