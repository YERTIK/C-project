using System;

namespace Project.Models
{
    public class BorrowingHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public string Status
        {
            get
            {
                if (ReturnDate.HasValue)
                    return "Возвращена";

                if (DateTime.Now > BorrowDate.AddDays(14))
                    return "Просрочена";

                return "На руках";
            }
        }

        public int DaysKept
        {
            get
            {
                if (ReturnDate.HasValue)
                    return (int)(ReturnDate.Value - BorrowDate).TotalDays;
                else
                    return (int)(DateTime.Now - BorrowDate).TotalDays;
            }
        }

        public DateTime ReturnDue => BorrowDate.AddDays(14);
    }
}