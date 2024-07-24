﻿namespace DealerPortalApp.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        public List<T> GetAll();
        public T Get(K key);
        public T Add(T item);
        public T Delete(K key);
        public T Update(T item);
    }
}
