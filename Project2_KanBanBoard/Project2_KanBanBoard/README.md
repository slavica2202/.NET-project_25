# Console Kanban Board

## Описание на проекта

Това е конзолно приложение, което симулира **Kanban Board** за управление на задачи. Програмата позволява потребителите да създават задачи и да ги премества през три етапа:
- **To Do** (задачи, които предстои да се извършат)
- **In Progress** (задачи, които са в процес на изпълнение)
- **Done** (задачи, които са приключени)

Програмата използва клавиши за бързо действие, като **F1**, **F5**, **F6**, **F7**, за взаимодействие с задачите и поддържа записване и зареждане на задачите в JSON файл.

## Цели на проекта
- Създаване на конзолно приложение за Kanban дъска
- Възможност за добавяне, премахване и преминаване на задачи през различни етапи
- Потребителски интерфейс чрез клавишни комбинации
- Поддръжка на записване и зареждане на задачи от JSON файл

## Използвани технологии
- **Език за програмиране**: C#
- **Платформа**: .NET Core или .NET Framework
- **Библиотека**: [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) за сериализация на JSON
- **Среда за разработка**: Visual Studio

## Зависимости
- .NET Core 3.1 или по-нова версия (или .NET Framework)
- NuGet пакет: **Newtonsoft.Json** (за работа с JSON)

## Инструкции за инсталация и стартиране

1. **Инсталиране на зависимостите**:
   - Отворете Visual Studio и отворете проекта.
   - Добавете NuGet пакета **Newtonsoft.Json** чрез **NuGet Package Manager**.

2. **Компилиране и стартиране на проекта**:
   - Стартирайте проекта от Visual Studio (натиснете F5).
   - Програмата ще ви попита дали искате да заредите съществуваща дъска или да създадете нова.

3. **Използване на програмата**:
   - Използвайте клавишните комбинации, за да добавяте задачи и да преминавате през етапите на Kanban дъската:
     - **F1** - Добавете нова задача в "To Do"
     - **F5** - Преместете задача в "In Progress"
     - **F6** - Преместете задача в "Done"
     - **F7** - Запишете дъската в JSON файл и излезте от програмата

## Пример за използване
1. Стартирайте програмата.
2. Изберете дали да заредите съществуваща дъска или да създадете нова.
3. След като създадете нова дъска, добавете задачи с **F1** и премествайте ги през етапите с **F5** и **F6**.

### Примерен изглед на Kanban дъската в конзолата:



## Архитектура на приложението

### Основни компоненти:
1. **KanbanBoard** - Клас, който съдържа трите колони на дъската: **To Do**, **In Progress**, **Done**. Всяка колона е списък от задачи.
2. **Task** - Клас, който съдържа информация за всяка задача, включително ID и описание.
3. **Program** - Главен клас, който управлява взаимодействието с потребителя, показва дъската и обработва задачите.

### Работни потоци:
1. **Добавяне на задачи** - Потребителят въвежда задача, която се добавя в колоната "To Do".
2. **Преместване на задачи** - Потребителят избира задача от съответната колона и я премества в следващата стъпка ("In Progress" или "Done").
3. **Записване и зареждане на дъска** - Състоянието на задачите се записва в JSON файл и може да бъде заредено при следващо стартиране на програмата.

## Стъпки за създаване на файла:
1. **KanbanBoard.cs** - Създайте клас, който съдържа три колони и инициализира списъците за задачи.
2. **Task.cs** - Създайте клас за задачите, който съдържа ID и описание на задачата.
3. **Program.cs** - Главен файл, който съдържа логиката за работа с задачите и потребителския интерфейс.

