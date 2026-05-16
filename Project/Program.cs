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

            // Инициализация файлов данных (Data/*.txt)
            DatabaseHelper.InitializeDatabase();

            // Раскомментируйте, чтобы добавить тестовые книги в books.txt
            // DatabaseHelper.AddTestBooks();

            // DatabaseHelper.FixMissingGenres();
            Application.Run(new LoginForm());
        }
    }
}