using System;
using System.Linq;
using System.Windows.Forms;
using Project.Helpers;

namespace Project
{
    public partial class ReturnBookForm : Form
    {
        private readonly int bookId;
        private readonly string bookTitle;
        private int borrowedCount;

        public int SelectedQuantity { get; private set; }

        public ReturnBookForm(int bookId, string bookTitle)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.bookTitle = bookTitle;
            SetupForm();
            LoadBorrowedCount();
        }

        private void SetupForm()
        {
            Text = "Возврат книги";
            lblBookTitle.Text = bookTitle;
        }

        private void LoadBorrowedCount()
        {
            borrowedCount = DatabaseHelper.GetUserBorrowsWithDetails(AuthManager.CurrentUser.Id)
                .Count(b => b.BookId == bookId && !b.ReturnDate.HasValue);

            lblOnHandValue.Text = $"{borrowedCount} экз.";

            if (borrowedCount == 0)
            {
                AppDialog.Info(this, "У вас нет взятых экземпляров этой книги!");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            numQuantity.Minimum = 1;
            numQuantity.Maximum = borrowedCount;
            numQuantity.Value = 1;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SelectedQuantity = (int)numQuantity.Value;

            if (SelectedQuantity <= 0 || SelectedQuantity > borrowedCount)
            {
                AppDialog.Warning(this, "Укажите корректное количество.");
                return;
            }

            if (DatabaseHelper.ReturnBook(AuthManager.CurrentUser.Id, bookId, SelectedQuantity))
            {
                AppDialog.Success(this, $"Книга успешно возвращена ({SelectedQuantity} экз.)!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                AppDialog.Error(this, "Ошибка при возврате книги!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
