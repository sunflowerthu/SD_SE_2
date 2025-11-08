using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Factories;

public interface ICategoryFactory
{
    Category CreateCategory(string name, CategoryType type);
}