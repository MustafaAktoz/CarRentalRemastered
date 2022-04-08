using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Cashing.Abstract
{
    public interface ICacheService
    {
        void Add(string key, object value, double duration);
        bool IsAdd(string key);
        T Get<T>(string key);
        object Get(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
