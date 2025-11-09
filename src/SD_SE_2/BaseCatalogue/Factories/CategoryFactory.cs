using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Factories;

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