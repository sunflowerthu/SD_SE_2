using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;

namespace SD_SE_2.BaseCatalogue.Factories.Interfaces;

public interface ICategoryFactory
{
    Category CreateCategory(string name, CategoryType type);
}