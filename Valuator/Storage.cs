using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace Valuator
{

    public class Storage : IStorage
    {
        private const string _host = "localhost";
        private const int _port = 6379;
        private readonly IConnectionMultiplexer _connection;

        public Storage()
        {
            _connection = ConnectionMultiplexer.Connect(_host);
        }

        public List<string> GetAllKeys()
        {
            var keys = _connection.GetServer(_host, _port).Keys();
            return keys.Select(item => item.ToString()).ToList();
        }

        public string GetDataByKey(string key)
        {
            var db = _connection.GetDatabase();
            return db.StringGet(key);
        }

        public void SaveData(string key, string value)
        {
            var db = _connection.GetDatabase();
            db.StringSet(key, value);
        }
    }
}
