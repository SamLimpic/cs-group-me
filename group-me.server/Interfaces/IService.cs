using System.Collections.Generic;

namespace group_me.server.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T data);
        T Update(T data, string creatorId);
        void Delete(int id, string creatorId);
    }
}