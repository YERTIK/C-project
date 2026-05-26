using System;

using System.Linq;

using System.Windows.Forms;

using Microsoft.VisualBasic;

using Project.Helpers;

using Project.Models;



namespace Project

{

    public partial class AddBookForm : Form

    {

        public AddBookForm()

        {

            InitializeComponent();

            numYear.Value = Math.Max(numYear.Minimum, Math.Min(numYear.Maximum, DateTime.Now.Year));

            LoadGenres();

        }



        private void LoadGenres()

        {

            string selected = cmbGenre.Text;

            cmbGenre.Items.Clear();

            cmbGenre.Items.AddRange(GenreHelper.GetGenres().Cast<object>().ToArray());



            if (!string.IsNullOrWhiteSpace(selected))

                cmbGenre.Text = selected;

            else if (cmbGenre.Items.Count > 0)

                cmbGenre.SelectedIndex = 0;

        }



        private void btnAddGenre_Click(object sender, EventArgs e)

        {

            string newGenre = Interaction.InputBox(

                "Введите название нового жанра:",

                "Новый жанр",

                string.Empty).Trim();



            if (string.IsNullOrWhiteSpace(newGenre))

                return;



            if (GenreHelper.GenreExists(newGenre))

            {

                AppDialog.Info(this, "Такой жанр уже есть в списке.", "Жанр");

                cmbGenre.Text = newGenre;

                return;

            }



            if (GenreHelper.AddGenre(newGenre))

            {

                LoadGenres();

                cmbGenre.Text = newGenre;

                AppDialog.Success(this, $"Жанр «{newGenre}» добавлен в список.");

            }

        }



        private void btnSave_Click(object sender, EventArgs e)

        {

            string title = txtTitle.Text.Trim();

            string author = txtAuthor.Text.Trim();

            string genre = cmbGenre.Text.Trim();



            if (string.IsNullOrWhiteSpace(title))

            {

                AppDialog.Warning(this, "Введите название книги.");

                txtTitle.Focus();

                return;

            }



            if (string.IsNullOrWhiteSpace(author))

            {

                AppDialog.Warning(this, "Введите автора.");

                txtAuthor.Focus();

                return;

            }



            if (string.IsNullOrWhiteSpace(genre))

            {

                AppDialog.Warning(this, "Выберите или введите жанр.");

                cmbGenre.Focus();

                return;

            }



            if (!GenreHelper.GenreExists(genre))

                GenreHelper.AddGenre(genre);



            int year = (int)numYear.Value;

            int quantity = (int)numQuantity.Value;

            int loanDays = (int)numLoanDays.Value;



            if (year < 1000 || year > DateTime.Now.Year + 1)

            {

                AppDialog.Warning(this, $"Год должен быть от 1000 до {DateTime.Now.Year + 1}.");

                numYear.Focus();

                return;

            }



            var book = new Book

            {

                Title = title,

                Author = author,

                Genre = genre,

                Year = year,

                Quantity = quantity,

                LoanDays = loanDays,

                AvailableQuantity = quantity

            };



            if (DatabaseHelper.AddBook(book))

            {

                AppDialog.Success(this, $"Книга «{title}» добавлена в каталог.");

                DialogResult = DialogResult.OK;

                Close();

            }

            else

            {

                AppDialog.Error(this, "Не удалось сохранить книгу.");

            }

        }



        private void btnCancel_Click(object sender, EventArgs e)

        {

            DialogResult = DialogResult.Cancel;

            Close();

        }

    }

}

