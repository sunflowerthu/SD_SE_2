using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Facades;

public interface ICategoryFacade
{
    public void AddCategory(string name, CategoryType categoryType);
    void DeleteCategory(Guid categoryId);
    void EditCategory(Guid categoryId, string? newName, CategoryType? newType);
}