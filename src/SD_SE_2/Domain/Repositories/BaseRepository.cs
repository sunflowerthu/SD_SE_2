using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : Entity
{
    protected readonly List<T> _entities = new();
    private readonly string _entityName;

    protected BaseRepository(string entityName = "Entity")
    {
        _entityName = entityName;
    }

    public virtual void Add(T entity)
    {
        _entities.Add(entity);
        Console.WriteLine($"{_entityName} added: {GetEntityDisplayName(entity)} (ID: {entity.Id})");
    }

    public virtual T GetById(Guid id)
    {
        return _entities.FirstOrDefault(e => e.Id == id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public virtual void Update(T entity)
    {
        var existing = GetById(entity.Id);
        if (existing != null)
        {
            _entities.Remove(existing);
            _entities.Add(entity);
            Console.WriteLine($"{_entityName} updated: {GetEntityDisplayName(entity)}");
        }
        else
        {
            Console.WriteLine($"{_entityName} with ID {entity.Id} not found for update");
        }
    }

    public virtual void Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _entities.Remove(entity);
            Console.WriteLine($"{_entityName} deleted: {GetEntityDisplayName(entity)}");
        }
        else
        {
            Console.WriteLine($"{_entityName} with ID {id} not found for deletion");
        }
    }

    public List<T> Find(Func<T, bool> predicate)
    {
        return _entities.Where(predicate).ToList();
    }

    public int Count => _entities.Count;

    public bool Exists(Guid id) => _entities.Any(e => e.Id == id);

    protected abstract string GetEntityDisplayName(T entity);
}