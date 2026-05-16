using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Project.Models;

namespace Project.Helpers
{
    public static class DatabaseHelper
    {
        private const string UsersFile = "users.txt";
        private const string BooksFile = "books.txt";
        private const string BorrowingsFile = "borrowings.txt";
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        private static string UsersPath => TextFileStorage.GetFilePath(UsersFile);
        private static string BooksPath => TextFileStorage.GetFilePath(BooksFile);
        private static string BorrowingsPath => TextFileStorage.GetFilePath(BorrowingsFile);

        public static void InitializeDatabase()
        {
            TextFileStorage.EnsureFileExists(UsersPath);
            TextFileStorage.EnsureFileExists(BooksPath);
            TextFileStorage.EnsureFileExists(BorrowingsPath);
            GenreHelper.InitializeGenres();
            EnsureAdminUser();
            EnsureSampleBooks();
        }

        private static void EnsureAdminUser()
        {
            var users = LoadUsers();
            bool changed = false;

            foreach (var user in users)
            {
                if (string.Equals(user.Login, "admin", StringComparison.OrdinalIgnoreCase) && !user.IsAdmin)
                {
                    user.IsAdmin = true;
                    changed = true;
                }
            }

            if (changed)
                SaveUsers(users);
        }

        public static User GetUser(string login)
        {
            try
            {
                foreach (var user in LoadUsers())
                {
                    if (string.Equals(user.Login, login, StringComparison.OrdinalIgnoreCase))
                        return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка при поиске пользователя: {ex.Message}");
                return null;
            }
        }

        public static bool UserExists(string login)
        {
            return LoadUsers().Any(u =>
                string.Equals(u.Login, login, StringComparison.OrdinalIgnoreCase));
        }

        public static bool AddUser(User user)
        {
            try
            {
                var users = LoadUsers();
                if (users.Any(u => string.Equals(u.Login, user.Login, StringComparison.OrdinalIgnoreCase)))
                    return false;

                user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
                users.Add(user);
                SaveUsers(users);
                return true;
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка при регистрации: {ex.Message}");
                return false;
            }
        }

        public static List<BorrowingWithBook> GetUserBorrowsWithBooks(int userId)
        {
            return GetUserBorrowsWithDetails(userId);
        }

        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            try
            {
                var allBooks = LoadBooks();
                var borrowings = LoadBorrowings();
                var activeBorrowCounts = borrowings
                    .Where(b => !b.ReturnDate.HasValue)
                    .GroupBy(b => b.BookId)
                    .ToDictionary(g => g.Key, g => g.Count());

                foreach (var book in allBooks)
                {
                    int borrowedCount = activeBorrowCounts.ContainsKey(book.Id)
                        ? activeBorrowCounts[book.Id]
                        : 0;

                    book.AvailableQuantity = book.Quantity - borrowedCount;
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки книг: {ex.Message}");
            }

            return books;
        }

        public static bool BorrowBook(int userId, int bookId, int quantity)
        {
            try
            {
                var borrowings = LoadBorrowings();
                int nextId = borrowings.Count == 0 ? 1 : borrowings.Max(b => b.Id) + 1;
                var now = DateTime.Now;

                for (int i = 0; i < quantity; i++)
                {
                    borrowings.Add(new Borrowing
                    {
                        Id = nextId++,
                        UserId = userId,
                        BookId = bookId,
                        BorrowDate = now,
                        ReturnDate = null
                    });
                }

                SaveBorrowings(borrowings);
                return true;
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
                return false;
            }
        }

        public static bool ReturnBook(int userId, int bookId, int quantity)
        {
            try
            {
                var borrowings = LoadBorrowings();
                var active = borrowings
                    .Where(b => b.UserId == userId && b.BookId == bookId && !b.ReturnDate.HasValue)
                    .Take(quantity)
                    .ToList();

                if (active.Count == 0)
                    return false;

                var now = DateTime.Now;
                foreach (var borrowing in active)
                    borrowing.ReturnDate = now;

                SaveBorrowings(borrowings);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Borrowing> GetUserBorrows(int userId)
        {
            return LoadBorrowings().Where(b => b.UserId == userId).ToList();
        }

        public static List<BorrowingWithBook> GetUserBorrowsWithDetails(int userId)
        {
            var books = LoadBooks().ToDictionary(b => b.Id);
            var result = new List<BorrowingWithBook>();

            foreach (var borrowing in LoadBorrowings()
                .Where(b => b.UserId == userId && !b.ReturnDate.HasValue))
            {
                if (!books.TryGetValue(borrowing.BookId, out var book))
                    continue;

                result.Add(new BorrowingWithBook
                {
                    Id = borrowing.Id,
                    BookId = borrowing.BookId,
                    BookTitle = book.Title,
                    BookAuthor = book.Author,
                    BorrowDate = borrowing.BorrowDate,
                    ReturnDate = borrowing.ReturnDate,
                    ReturnDue = borrowing.BorrowDate.AddDays(book.LoanDays > 0 ? book.LoanDays : 14),
                    LoanDays = book.LoanDays > 0 ? book.LoanDays : 14
                });
            }

            return result;
        }

        public static void AddTestBooks()
        {
            try
            {
                var books = LoadBooks();
                var testBooks = new List<Book>
                {
                    new Book { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869, Quantity = 5 },
                    new Book { Title = "Анна Каренина", Author = "Лев Толстой", Genre = "Роман", Year = 1877, Quantity = 3 },
                    new Book { Title = "Преступление и наказание", Author = "Федор Достоевский", Genre = "Роман", Year = 1866, Quantity = 4 },
                    new Book { Title = "Идиот", Author = "Федор Достоевский", Genre = "Роман", Year = 1869, Quantity = 2 },
                    new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967, Quantity = 4 },
                    new Book { Title = "Евгений Онегин", Author = "Александр Пушкин", Genre = "Поэзия", Year = 1833, Quantity = 3 },
                    new Book { Title = "Десять негритят", Author = "Агата Кристи", Genre = "Детектив", Year = 1939, Quantity = 3 },
                    new Book { Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Genre = "Детектив", Year = 1934, Quantity = 2 },
                    new Book { Title = "Собака Баскервилей", Author = "Артур Конан Дойл", Genre = "Детектив", Year = 1902, Quantity = 2 },
                    new Book { Title = "Шерлок Холмс", Author = "Артур Конан Дойл", Genre = "Детектив", Year = 1887, Quantity = 3 },
                    new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Фантастика", Year = 1949, Quantity = 4 },
                    new Book { Title = "Маленький принц", Author = "Антуан де Сент-Экзюпери", Genre = "Сказка", Year = 1943, Quantity = 4 },
                    new Book { Title = "Метро 2033", Author = "Дмитрий Глуховский", Genre = "Фантастика", Year = 2005, Quantity = 3 },
                    new Book { Title = "451 градус по Фаренгейту", Author = "Рэй Брэдбери", Genre = "Фантастика", Year = 1953, Quantity = 3 },
                    new Book { Title = "Три мушкетера", Author = "Александр Дюма", Genre = "Приключения", Year = 1844, Quantity = 3 },
                    new Book { Title = "Граф Монте-Кристо", Author = "Александр Дюма", Genre = "Приключения", Year = 1844, Quantity = 2 },
                    new Book { Title = "Таинственный остров", Author = "Жюль Верн", Genre = "Приключения", Year = 1874, Quantity = 2 },
                    new Book { Title = "Ромео и Джульетта", Author = "Уильям Шекспир", Genre = "Поэзия", Year = 1597, Quantity = 3 },
                    new Book { Title = "Гамлет", Author = "Уильям Шекспир", Genre = "Поэзия", Year = 1603, Quantity = 2 },
                    new Book { Title = "Сияние", Author = "Стивен Кинг", Genre = "Триллер", Year = 1977, Quantity = 2 },
                    new Book { Title = "Оно", Author = "Стивен Кинг", Genre = "Ужасы", Year = 1986, Quantity = 2 },
                    new Book { Title = "Зеленая миля", Author = "Стивен Кинг", Genre = "Драма", Year = 1996, Quantity = 2 }
                };

                int nextId = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;
                int addedCount = 0;

                foreach (var book in testBooks)
                {
                    book.Id = nextId++;
                    book.ISBN = string.Empty;
                    books.Add(book);
                    addedCount++;
                }

                SaveBooks(books);
                AppDialog.Success(null, $"Добавлено {addedCount} книг с жанрами!");
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
            }
        }

        public static bool AddBook(Book book)
        {
            try
            {
                var books = LoadBooks();
                book.Id = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;
                if (string.IsNullOrWhiteSpace(book.ISBN))
                    book.ISBN = GenerateUniqueIsbn(book.Id, books);
                books.Add(book);
                SaveBooks(books);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка добавления книги: {ex.Message}");
                return false;
            }
        }

        public static void RemoveDuplicateBooks()
        {
            try
            {
                var books = LoadBooks();
                int before = books.Count;

                books = books
                    .GroupBy(b => new { b.Title, b.Author, b.Year })
                    .Select(g => g.OrderBy(b => b.Id).First())
                    .ToList();

                SaveBooks(books);
                AppDialog.Success(null, $"Удалено {before - books.Count} дубликатов книг!", "Очистка");
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
            }
        }

        public static void ResetBooksTable()
        {
            try
            {
                SaveBorrowings(new List<Borrowing>());
                SaveBooks(new List<Book>());
                AddTestBooks();
                AppDialog.Success(null, "Таблица книг полностью пересоздана!");
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
            }
        }

        public static void FixMissingGenres()
        {
            try
            {
                var books = LoadBooks();
                int updated = 0;

                foreach (var book in books)
                {
                    if (!string.IsNullOrWhiteSpace(book.Genre))
                        continue;

                    string genre = GetGenreByTitle(book.Title);
                    if (string.IsNullOrEmpty(genre))
                        continue;

                    book.Genre = genre;
                    updated++;
                }

                SaveBooks(books);
                AppDialog.Success(null, $"Обновлено жанров: {updated}");
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
            }
        }

        public static void MergeDuplicateBooks()
        {
            try
            {
                var books = LoadBooks();
                int before = books.Count;
                var merged = new List<Book>();

                foreach (var group in books.GroupBy(b => new { b.Title, b.Author, b.Year }))
                {
                    var keep = group.OrderBy(b => b.Id).First();
                    keep.Quantity = group.Sum(b => b.Quantity);
                    merged.Add(keep);
                }

                SaveBooks(merged);
                AppDialog.Success(null, $"Объединено и удалено {before - merged.Count} дубликатов!", "Очистка");
            }
            catch (Exception ex)
            {
                AppDialog.Error(null, $"Ошибка: {ex.Message}");
            }
        }

        public static List<BorrowingHistory> GetUserBorrowingHistory(int userId)
        {
            var history = new List<BorrowingHistory>();

            try
            {
                var books = LoadBooks().ToDictionary(b => b.Id);

                foreach (var borrowing in LoadBorrowings()
                    .Where(b => b.UserId == userId)
                    .OrderByDescending(b => b.BorrowDate))
                {
                    if (!books.TryGetValue(borrowing.BookId, out var book))
                        continue;

                    history.Add(new BorrowingHistory
                    {
                        Id = borrowing.Id,
                        UserId = userId,
                        BookId = borrowing.BookId,
                        BookTitle = book.Title,
                        BookAuthor = book.Author,
                        BorrowDate = borrowing.BorrowDate,
                        ReturnDate = borrowing.ReturnDate,
                        LoanDays = book.LoanDays > 0 ? book.LoanDays : 14
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки истории: {ex.Message}");
            }

            return history;
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                var users = LoadUsers();
                if (!users.Any(u => u.Id == userId))
                    return false;

                var borrowings = LoadBorrowings();
                var now = DateTime.Now;

                foreach (var borrowing in borrowings.Where(b => b.UserId == userId && !b.ReturnDate.HasValue))
                    borrowing.ReturnDate = now;

                borrowings.RemoveAll(b => b.UserId == userId);
                users.RemoveAll(u => u.Id == userId);

                SaveBorrowings(borrowings);
                SaveUsers(users);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка удаления: {ex.Message}");
                return false;
            }
        }

        private static List<User> LoadUsers()
        {
            var users = new List<User>();

            foreach (var fields in TextFileStorage.ReadRecords(UsersPath))
            {
                if (fields.Length < 8)
                    continue;

                users.Add(new User
                {
                    Id = ParseInt(fields[0]),
                    Login = fields[1],
                    Password = fields[2],
                    FullName = fields[3],
                    Group = fields[4],
                    Course = ParseInt(fields[5]),
                    RegistrationDate = ParseDate(fields[6]),
                    IsAdmin = fields[7] == "1"
                });
            }

            return users;
        }

        private static void SaveUsers(List<User> users)
        {
            var records = users.Select(u => new[]
            {
                u.Id.ToString(),
                u.Login ?? string.Empty,
                u.Password ?? string.Empty,
                u.FullName ?? string.Empty,
                u.Group ?? string.Empty,
                u.Course.ToString(),
                FormatDate(u.RegistrationDate),
                u.IsAdmin ? "1" : "0"
            });

            TextFileStorage.WriteRecords(UsersPath, records);
        }

        private static List<Book> LoadBooks()
        {
            var books = new List<Book>();

            foreach (var fields in TextFileStorage.ReadRecords(BooksPath))
            {
                if (fields.Length < 7)
                    continue;

                books.Add(new Book
                {
                    Id = ParseInt(fields[0]),
                    Title = fields[1],
                    Author = fields[2],
                    Genre = fields[3],
                    ISBN = fields[4],
                    Year = ParseInt(fields[5]),
                    Quantity = ParseInt(fields[6]),
                    LoanDays = fields.Length >= 8 ? ParseInt(fields[7]) : 14
                });
            }

            return books;
        }

        private static void SaveBooks(List<Book> books)
        {
            var records = books.Select(b => new[]
            {
                b.Id.ToString(),
                b.Title ?? string.Empty,
                b.Author ?? string.Empty,
                b.Genre ?? string.Empty,
                b.ISBN ?? string.Empty,
                b.Year.ToString(),
                b.Quantity.ToString(),
                (b.LoanDays > 0 ? b.LoanDays : 14).ToString()
            });

            TextFileStorage.WriteRecords(BooksPath, records);
        }

        private static List<Borrowing> LoadBorrowings()
        {
            var borrowings = new List<Borrowing>();

            foreach (var fields in TextFileStorage.ReadRecords(BorrowingsPath))
            {
                if (fields.Length < 5)
                    continue;

                borrowings.Add(new Borrowing
                {
                    Id = ParseInt(fields[0]),
                    UserId = ParseInt(fields[1]),
                    BookId = ParseInt(fields[2]),
                    BorrowDate = ParseDate(fields[3]),
                    ReturnDate = string.IsNullOrWhiteSpace(fields[4]) ? (DateTime?)null : ParseDate(fields[4])
                });
            }

            return borrowings;
        }

        private static void SaveBorrowings(List<Borrowing> borrowings)
        {
            var records = borrowings.Select(b => new[]
            {
                b.Id.ToString(),
                b.UserId.ToString(),
                b.BookId.ToString(),
                FormatDate(b.BorrowDate),
                b.ReturnDate.HasValue ? FormatDate(b.ReturnDate.Value) : string.Empty
            });

            TextFileStorage.WriteRecords(BorrowingsPath, records);
        }

        private static int ParseInt(string value)
        {
            int result;
            return int.TryParse(value, out result) ? result : 0;
        }

        private static DateTime ParseDate(string value)
        {
            DateTime result;
            if (DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return result;

            return DateTime.TryParse(value, out result) ? result : DateTime.MinValue;
        }

        private static string FormatDate(DateTime value) =>
            value.ToString(DateFormat, CultureInfo.InvariantCulture);

        private static string GetGenreByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

            if (title.IndexOf("Война и мир", StringComparison.OrdinalIgnoreCase) >= 0) return "Роман";
            if (title.IndexOf("Преступление и наказание", StringComparison.OrdinalIgnoreCase) >= 0) return "Роман";
            if (title.IndexOf("Мастер и Маргарита", StringComparison.OrdinalIgnoreCase) >= 0) return "Роман";
            if (title.IndexOf("Анна Каренина", StringComparison.OrdinalIgnoreCase) >= 0) return "Роман";
            if (title.IndexOf("Евгений Онегин", StringComparison.OrdinalIgnoreCase) >= 0) return "Поэзия";
            if (title.IndexOf("1984", StringComparison.OrdinalIgnoreCase) >= 0) return "Фантастика";
            if (title.IndexOf("Десять негритят", StringComparison.OrdinalIgnoreCase) >= 0) return "Детектив";

            return string.Empty;
        }

        private static void EnsureSampleBooks()
        {
            var books = LoadBooks();
            if (books.Count > 0)
                return;

            var sampleBooks = new List<Book>
            {
                new Book { Title = "Тень Империи", Author = "Алекс Ворон", Genre = "Фантастика", Year = 2021, Quantity = 5, LoanDays = 14, ISBN = "9785171234567" },
                new Book { Title = "Последний Рубеж", Author = "Игорь Стрелков", Genre = "Боевик", Year = 2019, Quantity = 3, LoanDays = 10, ISBN = "9785049876543" },
                new Book { Title = "Дом у Озера", Author = "Мария Лесная", Genre = "Роман", Year = 2018, Quantity = 2, LoanDays = 7, ISBN = "9785698123456" },
                new Book { Title = "Код Пустоты", Author = "Никита Орлов", Genre = "Детектив", Year = 2022, Quantity = 4, LoanDays = 12, ISBN = "9785177777771" },
                new Book { Title = "Северный Ветер", Author = "Анна Волкова", Genre = "Роман", Year = 2017, Quantity = 6, LoanDays = 9, ISBN = "9785444412345" },
                new Book { Title = "Черный Сектор", Author = "Денис Карпов", Genre = "Фантастика", Year = 2020, Quantity = 8, LoanDays = 15, ISBN = "9785123498765" },
                new Book { Title = "Пепел Города", Author = "Артем Клин", Genre = "Боевик", Year = 2016, Quantity = 2, LoanDays = 5, ISBN = "9785000011112" },
                new Book { Title = "Тайна Архива", Author = "Ольга Миронова", Genre = "Детектив", Year = 2023, Quantity = 7, LoanDays = 14, ISBN = "9785111122223" }
            };

            int nextId = 1;
            foreach (var book in sampleBooks)
            {
                book.Id = nextId++;
                books.Add(book);
            }

            foreach (var genre in sampleBooks.Select(b => b.Genre).Distinct())
            {
                if (!GenreHelper.GenreExists(genre))
                    GenreHelper.AddGenre(genre);
            }

            SaveBooks(books);
        }

        private static string GenerateUniqueIsbn(int bookId, List<Book> existingBooks)
        {
            var used = new HashSet<string>(
                existingBooks.Where(b => !string.IsNullOrWhiteSpace(b.ISBN)).Select(b => b.ISBN));

            for (int offset = 0; offset < 10000; offset++)
            {
                string isbn = "978" + (bookId + offset).ToString("D10");
                if (!used.Contains(isbn))
                    return isbn;
            }

            return "978" + DateTime.Now.Ticks.ToString().Substring(0, 10);
        }
    }
}
