using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }  // НОВОЕ ПОЛЕ - ЖАНР
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public int LoanDays { get; set; } = 14;
        public int AvailableQuantity { get; set; }
        public int BorrowedQuantity => Quantity - AvailableQuantity; 
    }
}
