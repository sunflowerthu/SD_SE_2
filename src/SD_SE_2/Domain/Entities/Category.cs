using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Entities;

public class Category : Entity
{
    public CategoryType Type { get; }

    public Category(string name, CategoryType type)
    {
        Type = type;
        Name = name;
    }
}