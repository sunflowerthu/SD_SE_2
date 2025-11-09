namespace SD_SE_2.BaseCatalogue.Entities;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}