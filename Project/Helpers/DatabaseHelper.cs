using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Project.Models;

namespace Project.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=library.db;Version=3;";

        // Инициализация БД (вызывается при старте)
        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Таблица пользователей
                string createUsers = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Login TEXT UNIQUE NOT NULL,
                Password TEXT NOT NULL,
                FullName TEXT NOT NULL,
                UserGroup TEXT NOT NULL,
                Course INTEGER NOT NULL,
                RegistrationDate DATETIME NOT NULL,
                IsAdmin BOOLEAN DEFAULT 0
            )";

                // Таблица книг (обновленная)
                string createBooks = @"
            CREATE TABLE IF NOT EXISTS Books (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Author TEXT NOT NULL,
                Genre TEXT,                    -- НОВАЯ КОЛОНКА
                ISBN TEXT,
                Year INTEGER,
                Quantity INTEGER DEFAULT 1
            )";

                // Таблица выдач
                string createBorrowings = @"
            CREATE TABLE IF NOT EXISTS Borrowings (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                BookId INTEGER NOT NULL,
                BorrowDate DATETIME NOT NULL,
                ReturnDate DATETIME,
                FOREIGN KEY (UserId) REFERENCES Users(Id),
                FOREIGN KEY (BookId) REFERENCES Books(Id)
            )";

                using (var cmd = new SQLiteCommand(createUsers, connection))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createBooks, connection))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand(createBorrowings, connection))
                    cmd.ExecuteNonQuery();

                // ВАЖНО: Пытаемся добавить колонку Genre, если её нет
                try
                {
                    string alterTable = "ALTER TABLE Books ADD COLUMN Genre TEXT";
                    using (var cmd = new SQLiteCommand(alterTable, connection))
                    {
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Колонка Genre успешно добавлена");
                    }
                }
                catch
                {
                    // Если колонка уже существует - игнорируем ошибку
                    System.Diagnostics.Debug.WriteLine("Колонка Genre уже существует");
                }
            }
        }

        // Получить пользователя по логину
        public static User GetUser(string login)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Login = @login";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Login = reader["Login"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Group = reader["UserGroup"].ToString(),
                                    Course = Convert.ToInt32(reader["Course"]),
                                    RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                                    IsAdmin = Convert.ToInt32(reader["IsAdmin"]) == 1
                                };
                            }
                            else
                            {
                                // Пользователь не найден
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        // Проверить существование пользователя
        public static bool UserExists(string login)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Login = @login";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // Добавить нового пользователя
        public static bool AddUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                INSERT INTO Users (Login, Password, FullName, UserGroup, Course, RegistrationDate, IsAdmin)
                VALUES (@login, @password, @fullname, @group, @course, @regdate, @isadmin)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", user.Login);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@fullname", user.FullName);
                        cmd.Parameters.AddWithValue("@group", user.Group);
                        cmd.Parameters.AddWithValue("@course", user.Course);
                        cmd.Parameters.AddWithValue("@regdate", user.RegistrationDate);
                        cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin ? 1 : 0);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static List<BorrowingWithBook> GetUserBorrowsWithBooks(int userId)
        {
            var borrows = new List<BorrowingWithBook>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT b.*, bk.Title as BookTitle, bk.Author as BookAuthor
            FROM Borrowings b
            JOIN Books bk ON b.BookId = bk.Id
            WHERE b.UserId = @userId AND b.ReturnDate IS NULL";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            borrows.Add(new BorrowingWithBook
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BookTitle = reader["BookTitle"].ToString(),
                                BookAuthor = reader["BookAuthor"].ToString(),
                                BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                                ReturnDate = reader["ReturnDate"] == DBNull.Value ?
                                    (DateTime?)null : Convert.ToDateTime(reader["ReturnDate"]),
                                ReturnDue = Convert.ToDateTime(reader["BorrowDate"]).AddDays(14)
                            });
                        }
                    }
                }
            }
            return borrows;
        }

        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT b.*, 
                       (SELECT COUNT(*) FROM Borrowings WHERE BookId = b.Id AND ReturnDate IS NULL) as BorrowedCount
                FROM Books b";

                    using (var cmd = new SQLiteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int totalQuantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 1;
                            int borrowedCount = Convert.ToInt32(reader["BorrowedCount"]);

                            books.Add(new Book
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Genre = reader["Genre"]?.ToString() ?? "",  // НОВОЕ ПОЛЕ
                                ISBN = reader["ISBN"]?.ToString(),
                                Year = reader["Year"] != DBNull.Value ? Convert.ToInt32(reader["Year"]) : 0,
                                Quantity = totalQuantity,
                                AvailableQuantity = totalQuantity - borrowedCount
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки книг: {ex.Message}");
            }

            return books;
        }

        // Взять книгу
        public static bool BorrowBook(int userId, int bookId, int quantity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            string query = @"
                        INSERT INTO Borrowings (UserId, BookId, BorrowDate, ReturnDate)
                        VALUES (@userId, @bookId, @borrowDate, NULL)";

                            using (var cmd = new SQLiteCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@userId", userId);
                                cmd.Parameters.AddWithValue("@bookId", bookId);
                                cmd.Parameters.AddWithValue("@borrowDate", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); 
                return false;
            }
        }

        // Вернуть книгу
        public static bool ReturnBook(int userId, int bookId, int quantity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                UPDATE Borrowings 
                SET ReturnDate = @returnDate
                WHERE UserId = @userId 
                  AND BookId = @bookId 
                  AND ReturnDate IS NULL
                LIMIT @quantity";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@returnDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Получить взятые книги пользователя
        public static List<Borrowing> GetUserBorrows(int userId)
        {
            var borrows = new List<Borrowing>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Borrowings WHERE UserId = @userId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            borrows.Add(new Borrowing
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                                ReturnDate = reader["ReturnDate"] == DBNull.Value ?
                                    (DateTime?)null : Convert.ToDateTime(reader["ReturnDate"])
                            });
                        }
                    }
                }
            }
            return borrows;
        }
        public static List<BorrowingWithBook> GetUserBorrowsWithDetails(int userId)
        {
            var borrows = new List<BorrowingWithBook>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT b.*, 
                   bk.Title as BookTitle, 
                   bk.Author as BookAuthor,
                   bk.Quantity as TotalQuantity
            FROM Borrowings b
            JOIN Books bk ON b.BookId = bk.Id
            WHERE b.UserId = @userId AND b.ReturnDate IS NULL";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var borrowDate = Convert.ToDateTime(reader["BorrowDate"]);

                            borrows.Add(new BorrowingWithBook
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BookTitle = reader["BookTitle"].ToString(),
                                BookAuthor = reader["BookAuthor"].ToString(),
                                BorrowDate = borrowDate,
                                ReturnDate = reader["ReturnDate"] == DBNull.Value ?
                                    (DateTime?)null : Convert.ToDateTime(reader["ReturnDate"]),
                                ReturnDue = borrowDate.AddDays(14)
                            });
                        }
                    }
                }
            }
            return borrows;
        }
        // Добавить тестовые книги (вызовите один раз)
        public static void AddTestBooks()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    var books = new List<Book>
            {
                // Русская классика
                new Book { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869, Quantity = 5 },
                new Book { Title = "Анна Каренина", Author = "Лев Толстой", Genre = "Роман", Year = 1877, Quantity = 3 },
                new Book { Title = "Преступление и наказание", Author = "Федор Достоевский", Genre = "Роман", Year = 1866, Quantity = 4 },
                new Book { Title = "Идиот", Author = "Федор Достоевский", Genre = "Роман", Year = 1869, Quantity = 2 },
                new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967, Quantity = 4 },
                new Book { Title = "Евгений Онегин", Author = "Александр Пушкин", Genre = "Поэзия", Year = 1833, Quantity = 3 },
                
                // Детективы
                new Book { Title = "Десять негритят", Author = "Агата Кристи", Genre = "Детектив", Year = 1939, Quantity = 3 },
                new Book { Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Genre = "Детектив", Year = 1934, Quantity = 2 },
                new Book { Title = "Собака Баскервилей", Author = "Артур Конан Дойл", Genre = "Детектив", Year = 1902, Quantity = 2 },
                new Book { Title = "Шерлок Холмс", Author = "Артур Конан Дойл", Genre = "Детектив", Year = 1887, Quantity = 3 },
                
                // Фантастика
                new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Фантастика", Year = 1949, Quantity = 4 },
                new Book { Title = "Маленький принц", Author = "Антуан де Сент-Экзюпери", Genre = "Сказка", Year = 1943, Quantity = 4 },
                new Book { Title = "Метро 2033", Author = "Дмитрий Глуховский", Genre = "Фантастика", Year = 2005, Quantity = 3 },
                new Book { Title = "451 градус по Фаренгейту", Author = "Рэй Брэдбери", Genre = "Фантастика", Year = 1953, Quantity = 3 },
                
                // Приключения
                new Book { Title = "Три мушкетера", Author = "Александр Дюма", Genre = "Приключения", Year = 1844, Quantity = 3 },
                new Book { Title = "Граф Монте-Кристо", Author = "Александр Дюма", Genre = "Приключения", Year = 1844, Quantity = 2 },
                new Book { Title = "Таинственный остров", Author = "Жюль Верн", Genre = "Приключения", Year = 1874, Quantity = 2 },
                
                // Поэзия
                new Book { Title = "Ромео и Джульетта", Author = "Уильям Шекспир", Genre = "Поэзия", Year = 1597, Quantity = 3 },
                new Book { Title = "Гамлет", Author = "Уильям Шекспир", Genre = "Поэзия", Year = 1603, Quantity = 2 },
                
                // Триллер
                new Book { Title = "Сияние", Author = "Стивен Кинг", Genre = "Триллер", Year = 1977, Quantity = 2 },
                new Book { Title = "Оно", Author = "Стивен Кинг", Genre = "Ужасы", Year = 1986, Quantity = 2 },
                new Book { Title = "Зеленая миля", Author = "Стивен Кинг", Genre = "Драма", Year = 1996, Quantity = 2 }
            };

                    int addedCount = 0;
                    foreach (var book in books)
                    {
                        string query = @"
                    INSERT INTO Books (Title, Author, Genre, ISBN, Year, Quantity)
                    VALUES (@title, @author, @genre, '', @year, @quantity)";

                        using (var cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@title", book.Title);
                            cmd.Parameters.AddWithValue("@author", book.Author);
                            cmd.Parameters.AddWithValue("@genre", book.Genre ?? "");
                            cmd.Parameters.AddWithValue("@year", book.Year);
                            cmd.Parameters.AddWithValue("@quantity", book.Quantity);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0) addedCount++;
                        }
                    }

                    MessageBox.Show($"Добавлено {addedCount} книг с жанрами!", "Успех");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public static bool AddBook(Book book)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                INSERT INTO Books (Title, Author, Genre, ISBN, Year, Quantity)
                VALUES (@title, @author, @genre, @isbn, @year, @quantity)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@title", book.Title);
                        cmd.Parameters.AddWithValue("@author", book.Author);
                        cmd.Parameters.AddWithValue("@genre", book.Genre ?? "");
                        cmd.Parameters.AddWithValue("@isbn", book.ISBN ?? "");
                        cmd.Parameters.AddWithValue("@year", book.Year);
                        cmd.Parameters.AddWithValue("@quantity", book.Quantity);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
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
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Находим и удаляем дубликаты, оставляя по одному экземпляру с наименьшим ID
                    string removeDuplicates = @"
                DELETE FROM Books 
                WHERE Id NOT IN (
                    SELECT MIN(Id)
                    FROM Books
                    GROUP BY Title, Author, Year
                )";

                    using (var cmd = new SQLiteCommand(removeDuplicates, connection))
                    {
                        int deleted = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Удалено {deleted} дубликатов книг!", "Очистка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }
        public static void ResetBooksTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Очищаем связанные таблицы
                    string clearBorrowings = "DELETE FROM Borrowings";
                    string clearBooks = "DELETE FROM Books";

                    using (var cmd = new SQLiteCommand(clearBorrowings, connection))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SQLiteCommand(clearBooks, connection))
                        cmd.ExecuteNonQuery();
                }

                // Добавляем книги заново
                AddTestBooks();

                MessageBox.Show("Таблица книг полностью пересоздана!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public static void FixMissingGenres()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Обновляем жанры для книг, где они пустые
                    string updateGenres = @"
                UPDATE Books 
                SET Genre = CASE 
                    WHEN Title LIKE '%Война и мир%' THEN 'Роман'
                    WHEN Title LIKE '%Преступление и наказание%' THEN 'Роман'
                    WHEN Title LIKE '%Мастер и Маргарита%' THEN 'Роман'
                    WHEN Title LIKE '%Анна Каренина%' THEN 'Роман'
                    WHEN Title LIKE '%Евгений Онегин%' THEN 'Поэзия'
                    WHEN Title LIKE '%1984%' THEN 'Фантастика'
                    WHEN Title LIKE '%Десять негритят%' THEN 'Детектив'
                    ELSE Genre
                END
                WHERE Genre IS NULL OR Genre = ''";

                    using (var cmd = new SQLiteCommand(updateGenres, connection))
                    {
                        int updated = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Обновлено жанров: {updated}", "Успех");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public static void MergeDuplicateBooks()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Получаем все уникальные книги
                    string getUniques = @"
                SELECT MIN(Id) as KeepId, Title, Author, Year, SUM(Quantity) as TotalQuantity
                FROM Books
                GROUP BY Title, Author, Year
                HAVING COUNT(*) > 1";

                    var duplicates = new List<(int KeepId, int TotalQuantity)>();

                    using (var cmd = new SQLiteCommand(getUniques, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int keepId = Convert.ToInt32(reader["KeepId"]);
                            int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                            duplicates.Add((keepId, totalQuantity));
                        }
                    }

                    // Обновляем количество в оставляемой записи
                    foreach (var dup in duplicates)
                    {
                        string update = "UPDATE Books SET Quantity = @qty WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(update, connection))
                        {
                            cmd.Parameters.AddWithValue("@qty", dup.TotalQuantity);
                            cmd.Parameters.AddWithValue("@id", dup.KeepId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Удаляем дубликаты (кроме оставленных)
                    string deleteDuplicates = @"
                DELETE FROM Books 
                WHERE Id NOT IN (
                    SELECT MIN(Id)
                    FROM Books
                    GROUP BY Title, Author, Year
                )";

                    using (var cmd = new SQLiteCommand(deleteDuplicates, connection))
                    {
                        int deleted = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Объединено и удалено {deleted} дубликатов!", "Очистка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public static List<BorrowingHistory> GetUserBorrowingHistory(int userId)
        {
            var history = new List<BorrowingHistory>();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT b.*, 
                       bk.Title as BookTitle, 
                       bk.Author as BookAuthor
                FROM Borrowings b
                JOIN Books bk ON b.BookId = bk.Id
                WHERE b.UserId = @userId
                ORDER BY b.BorrowDate DESC";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                history.Add(new BorrowingHistory
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    UserId = userId,
                                    BookId = Convert.ToInt32(reader["BookId"]),
                                    BookTitle = reader["BookTitle"].ToString(),
                                    BookAuthor = reader["BookAuthor"].ToString(),
                                    BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                                    ReturnDate = reader["ReturnDate"] == DBNull.Value ?
                                        (DateTime?)null : Convert.ToDateTime(reader["ReturnDate"])
                                });
                            }
                        }
                    }
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
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        // 1. Возвращаем все книги пользователя
                        string returnBooks = @"
                    UPDATE Borrowings 
                    SET ReturnDate = @returnDate
                    WHERE UserId = @userId AND ReturnDate IS NULL";

                        using (var cmd = new SQLiteCommand(returnBooks, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@returnDate", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Удаляем записи о взятии книг
                        string deleteBorrowings = "DELETE FROM Borrowings WHERE UserId = @userId";
                        using (var cmd = new SQLiteCommand(deleteBorrowings, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Удаляем пользователя
                        string deleteUser = "DELETE FROM Users WHERE Id = @userId";
                        using (var cmd = new SQLiteCommand(deleteUser, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            int deleted = cmd.ExecuteNonQuery();

                            if (deleted > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка удаления: {ex.Message}");
                return false;
            }
        }
    }
}