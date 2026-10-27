using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Task1_DeferredVsImmediate();
        Task2_AllAnyContains();
        Task3_FirstLastDefault();
    }
    static void Task1_DeferredVsImmediate()
    {
        Console.WriteLine("ЗАДАНИЕ 1. Отложенное и немедленное выполнение");
        string[] candidates = { "Анна", "Борис", "Олег", "Ирина" };
        Console.WriteLine($"Исходный массив: {string.Join(", ", candidates)}");
        IEnumerable<string> deferredQuery = candidates
            .Where(name => name.Length == 4)
            .OrderBy(name => name);
        candidates[2] = "Игорь";
        Console.WriteLine($"После candidates[2] = \"Игорь\": {string.Join(", ", candidates)}");
        Console.WriteLine("Отложенный запрос (выполнен в foreach, после замены):");
        foreach (string name in deferredQuery)
        {
            Console.WriteLine($"  {name}");
        }
        List<string> immediateList = candidates
            .Where(name => name.Length == 4)
            .OrderBy(name => name)
            .ToList();
        candidates[0] = "Алена";
        Console.WriteLine($"После candidates[0] = \"Алена\": {string.Join(", ", candidates)}");
        Console.WriteLine("Список ToList() (результат сохранён до замены):");
        foreach (string name in immediateList)
        {
            Console.WriteLine($"  {name}");
        }
        Console.WriteLine($"Тот же отложенный запрос сейчас: {Show(deferredQuery)}");
        Console.WriteLine();
    }
    static void Task2_AllAnyContains()
    {
        Console.WriteLine("ЗАДАНИЕ 2. All, Any, Contains и IEqualityComparer");
        string[] products = { "laptop", "Phone", "TABLET", "Smartwatch" };
        Console.WriteLine($"Продукты: {string.Join(", ", products)}");
        bool allLongerThan3 = products.All(p => p.Length > 3);
        Console.WriteLine($"All(Length > 3): {allLongerThan3}");
        bool anyStartsWithS = products.Any(p => p.StartsWith('S') || p.StartsWith('s'));
        Console.WriteLine($"Any(начинается с 'S' или 's'): {anyStartsWithS}");
        bool containsDefault = products.Contains("phone");
        Console.WriteLine($"Contains(\"phone\"): {containsDefault}");
        bool containsIgnoreCase = products.Contains("phone", new IgnoreCaseComparer());
        Console.WriteLine($"Contains(\"phone\", new IgnoreCaseComparer()): {containsIgnoreCase}");
        var comparer = new IgnoreCaseComparer();
        bool sameHash = comparer.GetHashCode("Phone") == comparer.GetHashCode("phone");
        Console.WriteLine($"GetHashCode(\"Phone\") == GetHashCode(\"phone\"): {sameHash}");
        Console.WriteLine();
    }
    static void Task3_FirstLastDefault()
    {
        Console.WriteLine("ЗАДАНИЕ 3. First, FirstOrDefault, Last, LastOrDefault");
        User[] users =
        {
            new User("Tom", 20),
            new User("Bob", 25),
            new User("Sam", 30),
            new User("Alice", 22)
        };
        User firstOver21 = users.First(u => u.Age > 21);
        Console.WriteLine($"First(Age > 21): {firstOver21}");
        try
        {
            Console.WriteLine(users.First(u => u.Age > 50));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"First(Age > 50): {ex.GetType().Name} — {ex.Message}");
        }
        User? over50 = users.FirstOrDefault(u => u.Age > 50);
        if (over50 is null)
        {
            Console.WriteLine("FirstOrDefault(Age > 50): null — пользователь старше 50 лет не найден");
        }
        else
        {
            Console.WriteLine($"FirstOrDefault(Age > 50): {over50}");
        }
        User guest = users.FirstOrDefault(u => u.Age > 50, new User("Guest", 0));
        Console.WriteLine($"FirstOrDefault(Age > 50, new User(\"Guest\", 0)): {guest}");
        User lastThreeLetters = users.Last(u => u.Name.Length == 3);
        Console.WriteLine($"Last(Name.Length == 3): {lastThreeLetters}");
        User? lastOver50 = users.LastOrDefault(u => u.Age > 50);
        Console.WriteLine($"LastOrDefault(Age > 50): {(lastOver50 is null ? "null" : lastOver50.ToString())}");
    }
    static string Show(IEnumerable<string> items)
    {
        string text = string.Join(", ", items);
        return text.Length > 0 ? text : "(пусто)";
    }
}
class IgnoreCaseComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.ToLower() == y.ToLower();
    }
    public int GetHashCode(string obj)
    {
        return obj.ToLower().GetHashCode();
    }
}
record class User(string Name, int Age);