using System.Collections.Generic;

namespace group_me.server.Interfaces
{
    public interface IRepository<T>
    // NOTE Generic Repository template for all repositories EXCEPT Auth0
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T data);
        bool Update(T data);
        bool Delete(int id);
    }
}