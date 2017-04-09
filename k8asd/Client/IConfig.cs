using System.Collections.Generic;

namespace k8asd {
    public interface IConfig {
        void Put<T>(string key, T value);

        void PutArray<T>(string key, List<T> values);

        string Get(string key);

        List<string> GetArray(string key);
    }
}
