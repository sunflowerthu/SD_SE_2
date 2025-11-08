using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
}