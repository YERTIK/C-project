using System;

using System.Collections.Generic;

using System.Drawing;

using System.Linq;

using System.Windows.Forms;

using Project.Helpers;

using Project.Models;



namespace Project

{

    public partial class ProfileForm : Form

    {

        private List<BorrowingWithBook> activeBooks;

        private List<BorrowingHistory> historyBooks;

        private bool showHistory = false; // false - активные, true - история

      //  private RadioButton rbActive;

       // private RadioButton rbHistory;

        public ProfileForm()

        {

            InitializeComponent();

            SetupDataGridView();

            LoadUserData();

            SetupViewToggle();

            LoadActiveBooks();



            // дабавляем конпку массового возврата

         

        }

        private void SetupViewToggle()

        {

            // Создаем переключатель (RadioButton) или кнопки

            rbActive.Checked = true; // По умолчанию показываем активные

            rbHistory.Checked = false;



            // Подписываемся на события

            rbActive.CheckedChanged += ViewToggle_CheckedChanged;

            rbHistory.CheckedChanged += ViewToggle_CheckedChanged;

        }



        private void ViewToggle_CheckedChanged(object sender, EventArgs e)

        {

            if (rbActive.Checked)

            {

                showHistory = false;

                LoadActiveBooks();

                this.Text = "Личный кабинет - Книги на руках";

            }

            else if (rbHistory.Checked)

            {

                showHistory = true;



                LoadHistory();

                this.Text = "Личный кабинет - История взятий";

            }

        }



        private void SetupDataGridView()

        {

            dgvBorrowedBooks.AutoGenerateColumns = false;

            dgvBorrowedBooks.AllowUserToAddRows = false;

            dgvBorrowedBooks.ReadOnly = true;

            dgvBorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            // ЗАПРЕЩАЕМ ИЗМЕНЕНИЕ РАЗМЕРОВ

            dgvBorrowedBooks.AllowUserToResizeColumns = false;

            dgvBorrowedBooks.AllowUserToResizeRows = false;



            // Перенос текста

            dgvBorrowedBooks.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvBorrowedBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            dgvBorrowedBooks.Columns.Clear();



            // Название

            dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

            {

                DataPropertyName = "BookTitle",

                HeaderText = "Название книги",

                Width = 300,

                Resizable = DataGridViewTriState.False

            });



            // Автор

            dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

            {

                DataPropertyName = "BookAuthor",

                HeaderText = "Автор",

                Width = 200,

                Resizable = DataGridViewTriState.False

            });



            // Дата взятия

            dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

            {

                DataPropertyName = "BorrowDate",

                HeaderText = "Взята",

                Width = 100,

                Resizable = DataGridViewTriState.False,

                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }

            });



            // Срок возврата

            dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

            {

                DataPropertyName = "ReturnDue",

                HeaderText = "Срок",

                Width = 100,

                Resizable = DataGridViewTriState.False,

                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }

            });



            // Статус

            dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

            {

                DataPropertyName = "Status",

                HeaderText = "Статус",

                Width = 100,

                Resizable = DataGridViewTriState.False

            });



            // Кнопка возврата

            DataGridViewButtonColumn btnReturn = new DataGridViewButtonColumn

            {

                Name = "Return",

                HeaderText = "",

                Text = "Вернуть",

                UseColumnTextForButtonValue = true,

                Width = 80,

                Resizable = DataGridViewTriState.False

            };

            dgvBorrowedBooks.Columns.Add(btnReturn);

        }

        private void LoadUserData()

        {

            try

            {

                var user = AuthManager.CurrentUser;



                if (user != null)

                {

                    lblFullName.Text = $"ФИО: {user.FullName}";

                    lblGroup.Text = $"Группа: {user.Group}";

                    lblCourse.Text = $"Курс: {user.Course}";

                    lblRegistrationDate.Text = $"Дата регистрации: {user.RegistrationDate:dd.MM.yyyy}";

                    lblLogin.Text = $"Логин: {user.Login}";

                }

            }

            catch (Exception ex)

            {

                AppDialog.Error(this, $"Ошибка загрузки данных: {ex.Message}");

            }

        }



        private void LoadActiveBooks()

        {

            try

            {

                dgvBorrowedBooks.ReadOnly = false;



                dgvBorrowedBooks.Columns.Clear();

                // Колонка с чекбоксом

                /*  DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn

                  {

                      Name = "Select",

                      HeaderText = "Выбрать",

                      Width = 60,

                      TrueValue = true,

                      FalseValue = false,

                      ReadOnly = false

                  }; 

                  dgvBorrowedBooks.Columns.Add(selectColumn);*/

                // Колонки для активных книг

                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BookTitle",

                    HeaderText = "Название",

                    Width = 250,

                     ReadOnly = true

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BookAuthor",

                    HeaderText = "Автор",

                    Width = 200,

                     ReadOnly = true

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BorrowDate",

                    HeaderText = "Взята",

                    Width = 100,

                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },

                     ReadOnly = true

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "ReturnDue",

                    HeaderText = "Срок",

                    Width = 100,

                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },

                     ReadOnly = true

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "Status",

                    HeaderText = "Статус",

                    Width = 100,

                     ReadOnly = true

                });



                // ВАЖНО: Добавляем колонку с кнопкой

                DataGridViewButtonColumn btnReturn = new DataGridViewButtonColumn

                {

                    Name = "Return",  // ЭТО ИМЯ МЫ ПРОВЕРЯЕМ В CellClick

                    HeaderText = "",

                    Text = "Вернуть",

                    UseColumnTextForButtonValue = true,

                    Width = 80,

                     ReadOnly = true

                };

                dgvBorrowedBooks.Columns.Add(btnReturn);



                // Загрузка данных

                activeBooks = DatabaseHelper.GetUserBorrowsWithDetails(AuthManager.CurrentUser.Id)

                    .Where(b => b.ReturnDate == null).ToList();



                dgvBorrowedBooks.DataSource = null;

                dgvBorrowedBooks.DataSource = activeBooks;



                UpdateActiveStats();

                // Подписывваемся для немедленного обновления при клике на чекбокс

                dgvBorrowedBooks.CellValueChanged += DgvBorrowedBooks_CellValueChanged;

                dgvBorrowedBooks.CurrentCellDirtyStateChanged += DgvBorrowedBooks_CurentCellDirtyStateChanged;

            }

            catch (Exception ex)

            {

                AppDialog.Error(this, $"Ошибка загрузки книг: {ex.Message}");

            }

        }

        private void DgvBorrowedBooks_CurentCellDirtyStateChanged(object sender, EventArgs e)

        {

            if (dgvBorrowedBooks.IsCurrentCellDirty)

            {

                dgvBorrowedBooks.CommitEdit(DataGridViewDataErrorContexts.Commit);

            }

        }

        private void DgvBorrowedBooks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBorrowedBooks.Columns["Select"] == null || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvBorrowedBooks.Columns["Select"].Index)
            {
                var cell = dgvBorrowedBooks.Rows[e.RowIndex].Cells["Select"] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    dgvBorrowedBooks.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        isChecked ? Color.LightBlue : Color.White;
                }
            }
        }

        private void LoadHistory()

        {

            try

            {

                // Очищаем и настраиваем колонки для истории

                dgvBorrowedBooks.Columns.Clear();



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BookTitle",

                    HeaderText = "Название книги",

                    Width = 200

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BookAuthor",

                    HeaderText = "Автор",

                    Width = 150

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "BorrowDate",

                    HeaderText = "Взята",

                    Width = 120,

                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "ReturnDate",

                    HeaderText = "Возвращена",

                    Width = 120,

                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "Status",

                    HeaderText = "Статус",

                    Width = 100

                });



                dgvBorrowedBooks.Columns.Add(new DataGridViewTextBoxColumn

                {

                    DataPropertyName = "DaysKept",

                    HeaderText = "Дней",

                    Width = 50,

                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

                });



                // Загружаем историю

                historyBooks = DatabaseHelper.GetUserBorrowingHistory(AuthManager.CurrentUser.Id);



                dgvBorrowedBooks.DataSource = null;

                dgvBorrowedBooks.DataSource = historyBooks;  // ИСПРАВЛЕНО!



                UpdateHistoryStats();

            }

            catch (Exception ex)

            {

                AppDialog.Error(this, $"Ошибка загрузки истории: {ex.Message}");

            }

        }



        private void UpdateActiveStats()

        {

            if (activeBooks != null)

            {

                int total = activeBooks.Count;

                int overdue = activeBooks.Count(b => b.Status == "Просрочена");



                lblStats.Text = $"Книг на руках: {total} | Просрочено: {overdue}";



                // Подсвечиваем просроченные

                foreach (DataGridViewRow row in dgvBorrowedBooks.Rows)

                {

                    var book = row.DataBoundItem as BorrowingWithBook;

                    if (book != null)

                    {

                        if (book.Status == "Просрочена")

                        {

                            row.DefaultCellStyle.BackColor = Color.LightCoral;

                            row.DefaultCellStyle.ForeColor = Color.White;

                        }

                        else

                        {

                            row.DefaultCellStyle.BackColor = Color.White;

                            row.DefaultCellStyle.ForeColor = Color.Black;

                        }

                    }

                }

            }

        }



        private void UpdateHistoryStats()

        {

            if (historyBooks != null)

            {

                int total = historyBooks.Count;

                int returned = historyBooks.Count(h => h.Status == "Возвращена");

                int overdue = historyBooks.Count(h => h.Status == "Просрочена");



                lblStats.Text = $"Всего книг: {total} | Возвращено: {returned} | Просрочено: {overdue}";

            }

        }



        private void btnReturnBook_Click(object sender, EventArgs e)

        {

            if (dgvBorrowedBooks.SelectedRows.Count == 0)

            {

                AppDialog.Info(this, "Выберите книгу для возврата!");

                return;

            }



            var selectedBook = (BorrowingWithBook)dgvBorrowedBooks.SelectedRows[0].DataBoundItem;

            ReturnSelectedBook(selectedBook);

        }



        private void btnBack_Click(object sender, EventArgs e)

        {

            MainForm mainForm = new MainForm();

            mainForm.Show();

            this.Close();

        }



        private void dgvBorrowedBooks_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            // Проверяем, что кликнули по кнопке (колонка "Return") и не по заголовку

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)

            {

                // Получаем название колонки

                string columnName = dgvBorrowedBooks.Columns[e.ColumnIndex].Name;



                // Если это колонка с кнопкой возврата

                if (columnName == "Return" && rbActive.Checked)

                {

                    // Получаем выбранную книгу

                    var selectedBook = activeBooks[e.RowIndex];



                    ReturnSelectedBook(selectedBook);

                }

            }

        }



        private void BtnReturntAll_Click(object sender, EventArgs e)

        {

            if(activeBooks == null || activeBooks.Count == 0)

            {

                AppDialog.Info(this, "У вас нет книг на руках!");

                return;

            }

            string bookList = "Вы возвращаете:\n";

            foreach (var book in activeBooks)

            {

                bookList += $"{ book.BookTitle}\n";

            }

            if (AppDialog.Confirm(this, bookList + "\n\nВернуть все книги?", "Подтверждение возврата"))

            {

                int succesCount = 0;

                foreach(var book in activeBooks)

                {

                    if(DatabaseHelper.ReturnBook(AuthManager.CurrentUser.Id, book.BookId, 1))

                    {

                        succesCount ++;

                    }

                }

                AppDialog.Success(this, $"Успешно возвращено {succesCount} из {activeBooks.Count} книг!", "Результат");

                LoadActiveBooks();

            }

        }



        private void BtnReturnSelected_Click(object sender, EventArgs e)

        {

            if(activeBooks == null || activeBooks.Count == 0)

            {

                AppDialog.Info(this, "У вас нет книг на руках!");

                return;

            }



            using (Form selectedForm = new Form())

            {

                selectedForm.Text = "Выбранные книги для возврата";

                selectedForm.Size = new Size(480, 420);

                selectedForm.StartPosition = FormStartPosition.CenterParent;

                selectedForm.BackColor = Color.DimGray;

                selectedForm.Font = new Font("Times New Roman", 12F);

                selectedForm.FormBorderStyle = FormBorderStyle.FixedDialog;

                selectedForm.MaximizeBox = false;

                selectedForm.MinimizeBox = false;



                Label lblHint = new Label

                {

                    Text = "Отметьте книги для возврата:",

                    Location = new Point(24, 20),

                    Size = new Size(420, 24),

                    ForeColor = Color.White,

                    Font = new Font("Times New Roman", 12F, FontStyle.Bold)

                };



                CheckedListBox clbBooks = new CheckedListBox

                {

                    Location = new Point(24, 52),

                    Size = new Size(420, 260),

                    CheckOnClick = true,

                    BackColor = Color.AliceBlue,

                    Font = new Font("Times New Roman", 12F)

                };

                foreach(var book in activeBooks)

                {

                    clbBooks.Items.Add(book.BookTitle, false);

                }

                Button btnOK = new Button

                {

                    Text = "Вернуть выбранные",

                    Location = new Point(24, 330),

                    Size = new Size(180, 34),

                    BackColor = Color.LimeGreen,

                    ForeColor = Color.White,

                    FlatStyle = FlatStyle.Flat,

                    Font = new Font("Times New Roman", 12F, FontStyle.Bold)

                };

                btnOK.FlatAppearance.BorderSize = 0;



                Button btnCancel = new Button

                {

                    Text = "Отмена",

                    Location = new Point(220, 330),

                    Size = new Size(150, 34),

                    BackColor = Color.LightCoral,

                    ForeColor = Color.White,

                    FlatStyle = FlatStyle.Flat,

                    Font = new Font("Times New Roman", 12F, FontStyle.Bold)

                };

                btnCancel.FlatAppearance.BorderSize = 0;

                btnOK.Click += (s, ev) =>

                {

                    List<BorrowingWithBook> toReturn = new List<BorrowingWithBook>();

                    for (int i = 0; i < clbBooks.CheckedItems.Count; i++)

                    {

                        string selectedTitle = clbBooks.CheckedItems[i].ToString();

                        var book = activeBooks.FirstOrDefault(b => b.BookTitle == selectedTitle);

                        if (book != null)

                            toReturn.Add(book);

                    }

                    if (toReturn.Count == 0)

                    {

                        AppDialog.Info(selectedForm, "Выберите книги для возврата!");

                        return;

                    }

                    string confirm = "Вы возвращаете:\n";

                    foreach (var book in toReturn)

                        confirm += $"• {book.BookTitle}\n";



                    if (AppDialog.Confirm(selectedForm, confirm + "\n\nПодтвердить?", "Подтверждение"))

                    {

                        int success = 0;

                        foreach (var book in toReturn)

                        {

                            if (DatabaseHelper.ReturnBook(AuthManager.CurrentUser.Id, book.BookId, 1))

                                success++;

                        }

                        AppDialog.Success(selectedForm, $"Возвращено {success} из {toReturn.Count} книг!");

                        selectedForm.DialogResult = DialogResult.OK;

                        selectedForm.Close();

                        LoadActiveBooks();

                    }

                };

                btnCancel.Click += (s, ev) => selectedForm.Close();

                selectedForm.Controls.Add(lblHint);

                selectedForm.Controls.Add(clbBooks);

                selectedForm.Controls.Add(btnOK);

                selectedForm.Controls.Add(btnCancel);



                selectedForm.ShowDialog();



            }

        }



        private void ReturnSelectedBook(BorrowingWithBook selectedBook)

        {

            using (var returnForm = new ReturnBookForm(selectedBook.BookId, selectedBook.BookTitle))

            {

                if (returnForm.ShowDialog(this) == DialogResult.OK && !showHistory)

                    LoadActiveBooks();

            }

        }

    }

}


