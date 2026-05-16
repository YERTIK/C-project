using System;
using System.Windows.Forms;
using Project.Helpers;

namespace Project
{
    public partial class ReturnBookForm : Form
    {
        private int bookId;
        private string bookTitle;

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
            this.Text = "Возврат книги";
            this.Size = new System.Drawing.Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label с информацией
            Label lblInfo = new Label
            {
                Text = $"Книга: {bookTitle}",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(300, 20)
            };

            // Label с количеством
            Label lblCount = new Label
            {
                Text = "Сколько экземпляров вернуть?",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(200, 20)
            };

            // NumericUpDown для выбора количества
            numReturnQuantity = new NumericUpDown
            {
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(100, 20),
                Minimum = 1,
                Maximum = 100,
                Value = 1
            };

            // Кнопка "Вернуть"
            Button btnReturn = new Button
            {
                Text = "Вернуть",
                Location = new System.Drawing.Point(120, 70),
                Size = new System.Drawing.Size(100, 25)
            };
            btnReturn.Click += BtnReturn_Click;

            // Кнопка "Отмена"
            Button btnCancel = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(230, 70),
                Size = new System.Drawing.Size(100, 25)
            };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Добавляем элементы на форму
            this.Controls.AddRange(new Control[] { lblInfo, lblCount, numReturnQuantity, btnReturn, btnCancel });
        }

        private void LoadBorrowedCount()
        {
            // Получаем количество взятых экземпляров этой книги
            var borrows = DatabaseHelper.GetUserBorrowsWithDetails(AuthManager.CurrentUser.Id);
            int count = 0;

            foreach (var borrow in borrows)
            {
                if (borrow.BookId == bookId && borrow.ReturnDate == null)
                    count++;
            }

            numReturnQuantity.Maximum = count;

            if (count == 0)
            {
                MessageBox.Show("У вас нет взятых экземпляров этой книги!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            int quantity = (int)numReturnQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Укажите количество!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.ReturnBook(AuthManager.CurrentUser.Id, bookId, quantity))
            {
                MessageBox.Show($"Книга успешно возвращена! ({quantity} экз.)", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при возврате книги!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}