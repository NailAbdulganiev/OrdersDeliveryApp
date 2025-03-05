# Order Delivery App

Простое веб-приложение для приемки заказов на доставку. Реализовано на ASP.NET 9.0 MVC с использованием PostgreSQL в качестве базы данных.

## Технологии
- **Backend:** ASP.NET 9.0
- **Frontend:** ASP.NET MVC
- **ORM:** Entity Framework Core
- **База данных:** PostgreSQL

## Требования
- .NET 9 SDK
- PostgreSQL
- IDE (например, Rider или Visual Studio)

## Установка и запуск
### 1. Клонирование репозитория
```bash
git clone https://github.com/NailAbdulganiev/OrderDeliveryApp.git
cd OrderDeliveryApp
```

### 2. Установка необходимых NuGet-пакетов
В проекте используются следующие пакеты:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Npgsql.EntityFrameworkCore.PostgreSQL

Установите их либо через NuGet Manager, либо через терминал:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### 3. Настройка базы данных
- Убедитесь, что PostgreSQL установлен и запущен.
- Создайте базу данных (например, **Orders**).
- Измените строку подключения в файле `appsettings.json` под ваши данные:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=Orders;Username=ваш-username;Password=ваш-пароль"
}
```

### 4. Применение миграций
Создайте и примените миграции к базе данных:
```bash
dotnet ef migrations add InitialMigration --project OrdersDeliveryApp.Data --startup-project OrdersDeliveryApp
dotnet ef database update --project OrdersDeliveryApp.Data --startup-project OrdersDeliveryApp
```

### 5. Запуск приложения
```bash
dotnet run
```

## Функционал
### 1. Создание заказа
Форма для ввода данных о заказе:
- Город отправителя
- Адрес отправителя
- Город получателя
- Адрес получателя
- Вес груза
- Дата забора груза

Все поля обязательны для заполнения.

### 2. Список заказов
Отображение всех созданных заказов с автоматически сгенерированным номером заказа.

### 3. Детали заказа
Просмотр деталей заказа в режиме чтения (открывается при клике на заказ в списке заказов).

## Структура проекта
### **Модели** (`OrdersDeliveryApp.Domain`)
- `Models`:
  - `Order.cs` — доменная модель заказа.
- `Interfaces`:
  - `IOrderService.cs` — интерфейс для сервиса заказов.

### **Контекст базы данных и репозитории** (`OrdersDeliveryApp.Data`)
- `Data`:
  - `AppDbContext.cs` — для работы с базой данных.
- `Interfaces`:
  - `IOrderRepository.cs` — интерфейс для репозитория заказов.
- `Repository`:
  - `OrderRepository.cs` — реализация репозитория заказов.

### **Сервисы** (`OrdersDeliveryApp.Services`)
- `DTOs`:
  - `OrderDTO.cs` — Data Transfer Object для заказов.
- `Interfaces`:
  - `IOrderService.cs` — интерфейс для сервиса заказов.
- `Services`:
  - `OrderService.cs` — реализация сервиса заказов.

### **Представления** (`OrdersDeliveryApp` — ASP.NET Core Web Application)
- `Controllers`:
  - `OrderController.cs` — обработка запросов, связанных с заказами.
- `Views/Order`:
  - `Create.cshtml` — создание нового заказа.
  - `Details.cshtml` — просмотр деталей заказа.
  - `Index.cshtml` — список всех заказов.
- `wwwroot`:
  - Папка с необходимыми библиотеками (Bootstrap, jQuery).

### **Миграции**
Автоматически создаются при использовании Entity Framework Core.

## Примечания
- Список заказов сортируется по автоматически сгенерированному номеру заказа, чтобы последний созданный заказ отображался вверху списка.
- При создании нового заказа пользователь перенаправляется на страницу со списком заказов, где отображается уведомление об успешном создании заказа.
- На страницах деталей заказа и создания заказа добавлены кнопки "Вернуться к списку" для удобства пользователя.

