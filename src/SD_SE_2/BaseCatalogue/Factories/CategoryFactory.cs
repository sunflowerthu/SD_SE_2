using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Factories.Interfaces;
using SD_SE_2.BaseCatalogue.Repositories.Interfaces;

namespace SD_SE_2.BaseCatalogue.Factories;

public class CategoryFactory(ICategoryRepository categoryRepository) : ICategoryFactory
{
    public Category CreateCategory(string name, CategoryType type)
    {
        if (categoryRepository.ExistByName(name))
        {
            throw new ArgumentException("Category with name " + name + " is exist");
        }

        var category = new Category(name, type);
        return category;
    }
}