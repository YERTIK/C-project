using System;
using System.Windows.Forms;
using Project.Helpers;

namespace Project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Инициализация базы данных
            DatabaseHelper.InitializeDatabase();

            // Раскомментируйте эту строку, чтобы добавить тестовые книги
            // DatabaseHelper.AddTestBooks();

            //  DatabaseHelper.FixMissingGenres();
            Application.Run(new LoginForm());
        }
    }
}