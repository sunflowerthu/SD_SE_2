using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
    bool Exists(Guid id);
}