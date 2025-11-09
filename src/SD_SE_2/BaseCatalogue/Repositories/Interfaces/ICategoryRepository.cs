using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;

namespace SD_SE_2.BaseCatalogue.Repositories.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    List<Category> GetCategoriesByType(CategoryType type);
    List<Category> GetIncomeCategories();
    List<Category> GetExpenseCategories();
    bool ExistByName(string name);
}