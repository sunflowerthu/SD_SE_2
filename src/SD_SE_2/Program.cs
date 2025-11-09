using Microsoft.Extensions.DependencyInjection;
using SD_SE_2.BaseCatalogue.Facades;
using SD_SE_2.BaseCatalogue.UI.MenuItems;
using SD_SE_2.BaseCatalogue.UI.MenuItems.Show;
using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.Factories;
using SD_SE_2.Domain.InputOutput;
using SD_SE_2.Domain.InputOutput.Import;
using SD_SE_2.Domain.Observers.Handlers;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services;
using SD_SE_2.Domain.Services.Interfaces;
using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Domain.UI.MenuItems;
using SD_SE_2.Facades;

namespace SD_SE_2;

class Program
{
    public static void Main()
    {
        var serviceProvider = Registration();
        var menu = serviceProvider.GetService<Menu>();
        menu.Display();
    }

    private static IServiceProvider Registration()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IOperationRepository, OperationRepository>();
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        
        services.AddSingleton<IEventPublisher, EventPublisher>();
        services.AddSingleton<ICommandManager, CommandManager>();
        
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        services.AddSingleton<IOperationService, OperationService>();
        
        services.AddSingleton<IDataTransferFacade, DataTransferFacade>();
        services.AddSingleton<IAccountFacade, AccountFacade>();
        services.AddSingleton<ICategoryFacade, CategoryFacade>();
        services.AddSingleton<IOperationFacade, OperationFacade>();
        
        services.AddSingleton<IAccountFactory, AccountFactory>();
        services.AddSingleton<ICategoryFactory, CategoryFactory>();
        services.AddSingleton<IOperationFactory, OperationFactory>();
        
        services.AddTransient<CsvExporter>();
        services.AddTransient<JsonExporter>();
        services.AddTransient<CsvImporter>();
        services.AddTransient<JsonImporter>();
        
        services.AddTransient<IMenuItem, ExportMenuItem>();
        services.AddTransient<IMenuItem, ImportMenuItem>();
        
        services.AddTransient<IMenuItem, ShowAccountsMenuItem>();
        services.AddTransient<IMenuItem, ShowOperationsMenuItem>();
        services.AddTransient<IMenuItem, ShowCategoriesMenuItem>();
        
        services.AddTransient<IMenuItem, AddAccountMenuItem>();
        services.AddTransient<IMenuItem, EditAccountMenuItem>();
        services.AddTransient<IMenuItem, DeleteAccountMenuItem>();
        
        services.AddTransient<IMenuItem, AddCategoryMenuItem>();
        services.AddTransient<IMenuItem, EditCategoryMenuItem>();
        services.AddTransient<IMenuItem, DeleteCategoryMenuItem>();
        
        services.AddTransient<IMenuItem, AddOperationMenuItem>();
        services.AddTransient<IMenuItem, EditOperationMenuItem>();
        services.AddTransient<IMenuItem, DeleteOperationMenuItem>();
        
        services.AddTransient<IMenuItem, UndoLastActionMenuItem>();
        services.AddTransient<IMenuItem, RedoLastActionMenuItem>();
        
        services.AddTransient<IMenuItem, ExitMenuItem>();
        
        services.AddTransient<OperationAuditHandler>();
        services.AddTransient<BalanceMonitoringHandler>();
        services.AddTransient<NotificationHandler>();

        services.AddTransient<Menu>();
        return services.BuildServiceProvider();
    }
}