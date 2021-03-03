using System.Collections.Generic;

namespace Valuator
{
    public interface IStorage
    {
        public void SaveData(string key, string value);
        public string GetDataByKey(string key);
        public List<string> GetAllKeys();
    }
}
