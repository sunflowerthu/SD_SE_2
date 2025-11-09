using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;

namespace SD_SE_2.BaseCatalogue.Facades.Interfaces;

public interface ICategoryFacade
{
    public void CreateCategory(string name, CategoryType categoryType);
    void DeleteCategory(Guid categoryId);
    void EditCategory(Guid categoryId, string? newName, CategoryType? newType);
    IEnumerable<Category> GetAllCategories();
}