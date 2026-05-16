using System;
using System.Windows.Forms;
using Project.Helpers;
using Project.Models;

namespace Project
{
    public partial class BorrowBookForm : Form
    {
        private readonly Book book;

        public int SelectedQuantity { get; private set; }

        public BorrowBookForm(Book book)
        {
            InitializeComponent();
            this.book = book;
            SetupBookInfo();
        }

        private void SetupBookInfo()
        {
            Text = "Взять книгу";
            lblBookTitle.Text = book.Title;
            lblAuthorValue.Text = book.Author;
            lblGenreValue.Text = book.Genre ?? "—";
            lblAvailableValue.Text = $"{book.AvailableQuantity} экз.";
            lblLoanDaysValue.Text = $"{(book.LoanDays > 0 ? book.LoanDays : 14)} дн.";

            numQuantity.Minimum = 1;
            numQuantity.Maximum = Math.Max(1, book.AvailableQuantity);
            numQuantity.Value = 1;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            SelectedQuantity = (int)numQuantity.Value;

            if (SelectedQuantity <= 0 || SelectedQuantity > book.AvailableQuantity)
            {
                AppDialog.Warning(this, "Укажите корректное количество.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
