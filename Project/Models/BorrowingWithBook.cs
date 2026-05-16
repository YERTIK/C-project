using System;

namespace Project.Models
{
    public class BorrowingWithBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime ReturnDue { get; set; }

        // Для отображения в DataGridView
        public string Status
        {
            /*  get
              {
                if (ReturnDate != null)
                      return "Возвращена";

                  return DateTime.Now > ReturnDue ? "Просрочена" : "На руках";
              } */
            get
            {
                if (ReturnDate != null)
                    return "Возвращена";

                // Просрочка если прошло больше 14 дней
                if (DateTime.Now > BorrowDate.AddDays(14))
                    return "Просрочена";

                return "На руках";
            }
        }
        public string DebugInfo
        {
            get
            {
                return $"Взята: {BorrowDate:dd.MM.yyyy}, " +
                       $"Должна быть возвращена: {BorrowDate.AddDays(14):dd.MM.yyyy}, " +
                       $"Сегодня: {DateTime.Now:dd.MM.yyyy}, " +
                       $"Просрочена: {DateTime.Now > BorrowDate.AddDays(14)}";
            }
        }
        public string DaysLeft
        {
            get
            {
                if (ReturnDate != null)
                    return "-";

                var days = (ReturnDue - DateTime.Now).Days;
                return days >= 0 ? $"{days} дн." : "Просрочка";
            }
        }
    }
}