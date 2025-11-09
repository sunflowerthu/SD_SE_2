# Домашнее задание №2 по КПО, ПИ, 2 курс

## Выполнила Рамазанова Зарина, студентка БПИ-249

## Описание проекта

Разработана полнофункциональная система учета финансов с поддержкой управления счетами, категориями и операциями. 
Из основных требований реализованы все: удаление, редактирование и добавление категорий, аккаунтов, операций. 
Для управления зависимостями реализован Di-контейнер.

### Из опциональных требований реализован следующий функционал:
- Импорт данных из CSV и JSON файлов;
- Экспорт данных из CSV и JSON файлов;
- Автоматический пересчет баланса при редактировании/удалении операций;
- Измерение времени работы отдельных команд.

## Реализация принципов SOLID
1. SRP (Single Responsibility Principle)   
   - AccountRepository, CategoryRepository, OperationRepository - отвечают только за работу с данными

   - AccountService, CategoryService, OperationService - содержат бизнес-логику

   - ExportMenuItem, ImportMenuItem и другие MenuItems - отвечают только за UI логику

   - CsvExporter, JsonExporter - отвечают только за экспорт в конкретный формат

2. OCP (Open-Closed Principle)   
   - IDataExporter, IDataImporter - легко добавить новые форматы (XML, YAML)

   - ICommand - легко добавить новые команды

3. LSP (Liskov Substitution Principle)   
   - Все реализации IRepository<T> взаимозаменяемы

   - Все реализации ICommand могут использоваться в CommandManager

   - Все реализации IMenuItem могут использоваться в Menu

4. ISP (Interface Segregation Principle)   
   - IAccountFacade, ICategoryFacade, IOperationFacade - узкоспециализированные интерфейсы

   - ICommand содержит только методы Execute/Undo

5. DIP (Dependency Inversion Principle)   
   - Все зависимости инжектируются через конструкторы

   - Зависимости от абстракций (IRepository, IService, IFacade)

   - DI контейнер управляет жизненным циклом объектов

## Реализация принципов GRASP
1. High Cohesion   

   - DataTransferFacade - сфокусирован на импорте/экспорте

   - CommandManager - отвечает только за управление командами

2. Low Coupling   
   - EventPublisher уменьшает связность между компонентами

   - Фасады предоставляют простые интерфейсы к сложным системам

   - Команды инкапсулируют операции

3. Information Expert   

   - Repository знает как работать с данными

   - Exporter знает как преобразовывать данные в форматы

4. Creator   
   - AccountFactory, CategoryFactory, OperationFactory создают объекты домена

   - CommandManager создает декорированные команды

## Реализация паттернов GoF
1. Repository Pattern   
   Классы: AccountRepository, CategoryRepository, OperationRepository
   Важность: Инкапсуляция доступа к данным, единообразие операций CRUD
   
3. Factory Method Pattern   
   Классы: AccountFactory, CategoryFactory, OperationFactory
   Важность: Делегирование создания объектов, централизация логики создания

4. Visitor Pattern   
   Классы: IExportable, Exporter
   Важность: Разделение алгоритмов экспорта от структуры объектов

5. Command Pattern   
   Классы: ICommand, AddOperationCommand, EditOperationCommand, DeleteOperationCommand, CommandManager
   Важность: Инкапсуляция операций, поддержка отмены/повтора

6. Observer Pattern   
  Классы: IEventPublisher, EventPublisher, OperationAddedEvent, BalanceRecalculatedEvent
  Важность: Слабая связность, уведомления о событиях, аудит

7. Decorator Pattern   
   Классы: TimingCommandDecorator, LoggingCommandDecorator
   Важность: Динамическое добавление функциональности без изменения классов

8. Adapter Pattern   
   Классы: CsvExporter, JsonExporter, CsvImporter, JsonImporter
   Важность: Унификация интерфейсов для разных форматов данных

9. Facade Pattern   
   Классы: AccountFacade, CategoryFacade, OperationFacade, DataTransferFacade
   Важность: Упрощение сложных подсистем, предоставление простых API
