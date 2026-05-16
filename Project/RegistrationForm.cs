using System;
using System.Drawing;
using System.Windows.Forms;
using Project.Helpers;
using Project.Models;

namespace Project
{
    public partial class RegistrationForm : Form
    {
        // Цвета для подсказок
        private Color hintColor = Color.Gray;
        private Color normalColor = Color.Black;

        // Тексты подсказок
        private string loginHint = "например: vp24a-0000";
        private string fullNameHint = "например: Иванов Иван Иванович";
        private string groupHint = "например: Вп-21";
        private string passwordHint = "Минимум 6 символов";

        public RegistrationForm()
        {
            InitializeComponent();
            SetupPlaceholders();
            SetupCourseComboBox();
            SetupPasswordStrengthChecker();
        }
        // Настройка серых подсказок (placeholder'ов)
        private void SetupPlaceholders()
        {
            // Логин
            txtLogin.Text = loginHint;
            txtLogin.ForeColor = hintColor;
            txtLogin.Enter += (s, e) => RemovePlaceholder(txtLogin, loginHint);
            txtLogin.Leave += (s, e) => SetPlaceholder(txtLogin, loginHint);

            // ФИО
            txtFullName.Text = fullNameHint;
            txtFullName.ForeColor = hintColor;
            txtFullName.Enter += (s, e) => RemovePlaceholder(txtFullName, fullNameHint);
            txtFullName.Leave += (s, e) => SetPlaceholder(txtFullName, fullNameHint);

            // Группа
            txtGroup.Text = groupHint;
            txtGroup.ForeColor = hintColor;
            txtGroup.Enter += (s, e) => RemovePlaceholder(txtGroup, groupHint);
            txtGroup.Leave += (s, e) => SetPlaceholder(txtGroup, groupHint);

            // Пароль
            txtPassword.Text = passwordHint;
            txtPassword.ForeColor = hintColor;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Enter += (s, e) => RemovePasswordPlaceholder();
            txtPassword.Leave += (s, e) => SetPasswordPlaceholder();

            // Подтверждение пароля
            txtConfirmPassword.Text = passwordHint;
            txtConfirmPassword.ForeColor = hintColor;
            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.Enter += (s, e) => RemoveConfirmPasswordPlaceholder();
            txtConfirmPassword.Leave += (s, e) => SetConfirmPasswordPlaceholder();
        }

        private void RemovePlaceholder(TextBox textBox, string hint)
        {
            if (textBox.Text == hint)
            {
                textBox.Text = "";
                textBox.ForeColor = normalColor;

                if (textBox == txtPassword || textBox == txtConfirmPassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void SetPlaceholder(TextBox textBox, string hint)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = hint;
                textBox.ForeColor = hintColor;

                if (textBox == txtPassword || textBox == txtConfirmPassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePasswordPlaceholder()
        {
            if (txtPassword.Text == passwordHint)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = normalColor;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void SetPasswordPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = passwordHint;
                txtPassword.ForeColor = hintColor;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void RemoveConfirmPasswordPlaceholder()
        {
            if (txtConfirmPassword.Text == passwordHint)
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = normalColor;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void SetConfirmPasswordPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                txtConfirmPassword.Text = passwordHint;
                txtConfirmPassword.ForeColor = hintColor;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        // Настройка выпадающего списка для курса
        private void SetupCourseComboBox()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("1 курс");
            cmbCourse.Items.Add("2 курс");
            cmbCourse.Items.Add("3 курс");
            cmbCourse.Items.Add("4 курс");
            cmbCourse.SelectedIndex = 0; // 1 курс по умолчанию
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Проверка надежности пароля
        private void SetupPasswordStrengthChecker()
        {
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != passwordHint && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                CheckPasswordStrength(txtPassword.Text);
            }
            else
            {
                lblPasswordStrength.Text = "";
                lblPasswordStrength.ForeColor = Color.Black;
            }
        }

        private void CheckPasswordStrength(string password)
        {
            int score = 0;

            // Длина
            if (password.Length >= 6) score++;
            if (password.Length >= 8) score++;

            // Цифры
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"\d")) score++;

            // Спецсимволы
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"!@#$%^&*~")) score++;
            // Заглавные буквы
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]")) score++;
            // Маленькие буквы
           if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]")) score++;
            // Определяем надежность
            switch (score)
            {
                case 1:
                   /* lblPasswordStrength.Text = "⚫ Пароль должен быть не менее 6 символов";
                    lblPasswordStrength.ForeColor = Color.Red;
                    break; */
                case 2:
                case 3:
                    lblPasswordStrength.Text = "🟡 Слабый пароль";
                    lblPasswordStrength.ForeColor = Color.Orange;
                    break;
                case 4:
                    lblPasswordStrength.Text = "🟢 Средний пароль";
                    lblPasswordStrength.ForeColor = Color.Gold;
                    break;
                case 5:
                    lblPasswordStrength.Text = "💪 Надежный пароль";
                    lblPasswordStrength.ForeColor = Color.Lime;
                    break;
            }
        }

        // Кнопка регистрации
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Получаем реальные значения (без подсказок)
            string login = txtLogin.Text == loginHint ? "" : txtLogin.Text;
            string fullName = txtFullName.Text == fullNameHint ? "" : txtFullName.Text;
            string group = txtGroup.Text == groupHint ? "" : txtGroup.Text;
            string password = txtPassword.Text == passwordHint ? "" : txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text == passwordHint ? "" : txtConfirmPassword.Text;

            // Валидация
            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(group) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка длины пароля
            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен быть не менее 6 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка уникальности логина
            if (DatabaseHelper.UserExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем курс из выпадающего списка
            int course = cmbCourse.SelectedIndex + 1;

            // Создание нового пользователя
            var newUser = new User
            {
                Login = login,
                Password = HashPassword(password),
                FullName = fullName,
                Group = group,
                Course = course,
                RegistrationDate = DateTime.Now,
                IsAdmin = false
            };

            // Сохранение в БД
            if (DatabaseHelper.AddUser(newUser))
            {
                MessageBox.Show($"Регистрация прошла успешно!\nКурс: {course}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // Если текст серый (placeholder) - не показываем
            if (txtPassword.ForeColor == Color.Gray)
                return;

            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "👁";
            btnTogglePassword.BackColor = txtPassword.UseSystemPasswordChar ?
 Color.White : Color.LightGray;
        }

        private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            // Если текст серый (placeholder) - не показываем
            if (txtConfirmPassword.ForeColor == Color.Gray)
                return;
           
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            btnToggleConfirmPassword.Text = txtConfirmPassword.UseSystemPasswordChar ? "👁" : "👁";
            btnToggleConfirmPassword.BackColor = txtConfirmPassword.UseSystemPasswordChar ?
 Color.White : Color.LightGray;


        }
    }
}