using LinqSqliteWinForms;
using System;
using System.Windows.Forms;
namespace LinqSqliteWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}