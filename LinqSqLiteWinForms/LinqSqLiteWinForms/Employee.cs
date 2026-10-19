using System;
namespace LinqSqliteWinForms
{
    public record Employee(int Id, string FullName, string Department, string Position, decimal Salary, DateTime HireDate);
}