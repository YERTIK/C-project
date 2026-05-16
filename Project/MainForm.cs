using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Helpers;
using Project.Models;

namespace Project
{
    public partial class MainForm : Form
    {
        private List<Book> allBooks;
        private List<Book> currentBooks;

        public MainForm()
        {
            InitializeComponent();

            // Блокировка изменения размера
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            InitializeDataGridView();
            LoadBooks();
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            //     dgvBooks.ColumnHeaderMouseClick += DgvBooks_ColumnHeaderMouseClick;

        }

        private void InitializeDataGridView()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = true;
            dgvBooks.RowHeadersVisible = false;

            dgvBooks.Columns.Clear();

            // Колонка с чекбоксами
            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Выбрать",
                Width = 70,
                TrueValue = true,
                FalseValue = false,
                ReadOnly = false
            };
            dgvBooks.Columns.Add(selectColumn);

            // Название
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Название",
                Width = 200,
                ReadOnly = true
            });
            // Автор
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Author",
                HeaderText = "Автор",
                Width = 200,
                ReadOnly = true
            });
            // ЖАНР
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Genre",
                HeaderText = "Жанр",
                Width = 100,
                ReadOnly = true
            });
            // Год
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Year",
                HeaderText = "Год",
                Width = 45,
                ReadOnly = true
            });

            // Всего
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Всего",
                Width = 55,
                ReadOnly = true
            });
            // Доступно
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AvailableQuantity",
                HeaderText = "Доступно",
                Width = 85,
                ReadOnly = true
            });

            dgvBooks.CellValueChanged += DgvBooks_CellValueChanged;
        }

        private void DgvBooks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBooks.Columns["Select"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dgvBooks.Rows[e.RowIndex].Cells["Select"] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    dgvBooks.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        isChecked ? System.Drawing.Color.LightBlue : System.Drawing.Color.White;
                }
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBooks.Columns["Select"].Index && e.RowIndex >= 0)
            {
                dgvBooks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        public void LoadBooks()
        {
            allBooks = DatabaseHelper.GetAllBooks();
            currentBooks = allBooks;

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = currentBooks;

            UpdateStats();
        }

        private void UpdateStats()
        {
            if (allBooks != null && allBooks.Count > 0)
            {
                int totalBooks = allBooks.Sum(b => b.Quantity);
                int availableBooks = allBooks.Sum(b => b.AvailableQuantity);
                int borrowedBooks = totalBooks - availableBooks;

                this.Text = $"Библиотека - Всего: {totalBooks}, Доступно: {availableBooks}, Взято: {borrowedBooks}";
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Собираем книги, отмеченные чекбоксами
            List<Book> selectedBooks = new List<Book>();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.IsNewRow) continue;

                DataGridViewCheckBoxCell checkBox = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBox != null && Convert.ToBoolean(checkBox.Value) == true)
                {
                    Book book = row.DataBoundItem as Book;
                    if (book != null && book.AvailableQuantity > 0)
                    {
                        selectedBooks.Add(book);
                    }
                }
            }

            // Если нет отмеченных, берем выделенные строки
            if (selectedBooks.Count == 0)
            {
                foreach (DataGridViewRow row in dgvBooks.SelectedRows)
                {
                    if (row.IsNewRow) continue;

                    Book book = row.DataBoundItem as Book;
                    if (book != null && book.AvailableQuantity > 0)
                    {
                        selectedBooks.Add(book);
                    }
                }
            }

            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("Выберите книги для взятия!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Запрашиваем количество для каждой книги
            List<Tuple<Book, int>> booksToBorrow = new List<Tuple<Book, int>>();

            foreach (Book book in selectedBooks)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Книга: {book.Title}\nДоступно: {book.AvailableQuantity} экз.\n\nСколько взять?",
                    book.Title,
                    "1");

                if (string.IsNullOrEmpty(input)) continue;

                if (int.TryParse(input, out int quantity) && quantity > 0 && quantity <= book.AvailableQuantity)
                {
                    booksToBorrow.Add(new Tuple<Book, int>(book, quantity));
                }
                else
                {
                    MessageBox.Show($"Некорректное количество для книги '{book.Title}'!", "Ошибка");
                }
            }

            if (booksToBorrow.Count == 0) return;

            // Подтверждение
            string message = "Вы берете:\n";
            foreach (var item in booksToBorrow)
            {
                message += $"• {item.Item1.Title} - {item.Item2} экз.\n";
            }

            if (MessageBox.Show(message + "\nПодтвердить?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in booksToBorrow)
                {
                    DatabaseHelper.BorrowBook(AuthManager.CurrentUser.Id, item.Item1.Id, item.Item2);
                }


                ClearCheckboxes();
                LoadBooks();
            }
        }

        private void ClearCheckboxes()
        {
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCheckBoxCell checkBox = row.Cells["Select"] as DataGridViewCheckBoxCell;
                    if (checkBox != null)
                    {
                        checkBox.Value = false;
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            dgvBooks.ClearSelection();
            ClearCheckboxes();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                currentBooks = allBooks;
            }
            else
            {
                // ТЕПЕРЬ ИЩЕМ ПО НАЗВАНИЮ, АВТОРУ И ЖАНРУ
                currentBooks = allBooks.Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Author.ToLower().Contains(searchText) ||
                    (b.Genre != null && b.Genre.ToLower().Contains(searchText))).ToList();

                // Показываем количество найденных
                if (currentBooks.Count == 0)
                {
                    MessageBox.Show($"Ничего не найдено по запросу: '{txtSearch.Text}'",
                        "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = currentBooks;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
            txtSearch.Clear();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

    }
}