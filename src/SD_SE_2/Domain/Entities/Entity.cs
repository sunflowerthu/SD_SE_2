namespace SD_SE_2.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
}