using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services.Interfaces;

public interface ICategoryService
{
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
    Category GetCategoryById(Guid categoryId);
    IEnumerable<Category> GetAllCategories();
}