using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Project.Helpers;
using Project.Models;

namespace Project
{
    public partial class LoginForm : BaseForm
    {
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button Btn_vhod;
        private Button Btn_Registration;
        private Label lblLogin;
        private Label lblPassword;

        public LoginForm()
        {
            CreateControls();
            SetFormIcon();
        }
        private void SetFormIcon()
        {
            try
            {
                // Список возможных мест где может лежать иконка
                string[] possiblePaths = new[]
                {
            "book.ico",
            "icon.ico",
            "favicon.ico",
            System.IO.Path.Combine(Application.StartupPath, "book.ico"),
            System.IO.Path.Combine(Application.StartupPath, "icon.ico"),
            System.IO.Path.Combine(Application.StartupPath, "Resources", "book.ico")
        };

                foreach (string path in possiblePaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        this.Icon = new Icon(path);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки иконки: {ex.Message}");
            }
        }
        private Button btnTogglePassword;
        private void CreateControls()
        {
            this.Text = "Вход в систему";
            this.Size = new Size(400, 300);
            this.MinimumSize = new Size(400, 300);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Устанавливаем цвет фона
            this.BackColor = Color.DimGray;
            contentPanel.BackColor = Color.DimGray;

            // Создаем элементы
            lblLogin = new Label
            {
                Text = "Логин:",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(69, 25)  // Сразу задаем размер
            };

            lblPassword = new Label
            {
                Text = "Пароль:",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(69, 25)
            };

            txtLogin = new TextBox
            {
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                BackColor = Color.AliceBlue,
                Cursor = Cursors.IBeam,
                Size = new Size(200, 25)
            };

            txtPassword = new TextBox
            {
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                UseSystemPasswordChar = true,
                BackColor = Color.AliceBlue,
                Cursor = Cursors.IBeam,
                Size = new Size(200, 25)
            };

            Btn_vhod = new Button
            {
                Text = "Войти",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                BackColor = Color.LimeGreen,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 35),
                FlatAppearance = { BorderSize = 0 }
            };
            Btn_vhod.Click += Btn_vhod_Click;

            Btn_Registration = new Button
            {
                Text = "Регистрация",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                BackColor = Color.CadetBlue,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 35),
                FlatAppearance = { BorderSize = 0 }
            };
            Btn_Registration.Click += Btn_Registration_Click;

            btnTogglePassword = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI", 10), 
                Size = new Size(40, 29),
                FlatStyle = FlatStyle.Standard,
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0)
            };
            btnTogglePassword.Click += BtnTogglePassword_Click;

            contentPanel.Controls.Add(btnTogglePassword);
            // Устанавливаем имена
            Btn_vhod.Name = "Btn_vhod";
            Btn_Registration.Name = "Btn_Registration";
            lblLogin.Name = "lblLogin";
            lblPassword.Name = "lblPassword";
            txtLogin.Name = "txtLogin";
            txtPassword.Name = "txtPassword";

            // Добавляем на contentPanel
            contentPanel.Controls.Add(lblLogin);
            contentPanel.Controls.Add(lblPassword);
            contentPanel.Controls.Add(txtLogin);
            contentPanel.Controls.Add(txtPassword);
            contentPanel.Controls.Add(Btn_vhod);
            contentPanel.Controls.Add(Btn_Registration);

            // Устанавливаем начальные позиции ПОСЛЕ добавления
            SetNormalPositions();
        }
        private void BtnTogglePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "👁";
            btnTogglePassword.BackColor = txtPassword.UseSystemPasswordChar ?
           Color.White : Color.LightGray;
            btnTogglePassword.Width = 40;
            btnTogglePassword.Height = 29;
            btnTogglePassword.Font = new Font("Segoe UI", 9.75f);
        }
        private void SetNormalPositions()
        {
            // Проверяем, что все элементы существуют
            if (lblLogin == null || txtLogin == null ||
                lblPassword == null || txtPassword == null ||
                Btn_vhod == null || Btn_Registration == null)
            {
                return; // Если чего-то нет, выходим
            }

            int centerX = this.ClientSize.Width / 2;

            lblLogin.Location = new Point(centerX - 150, 50);
            txtLogin.Location = new Point(centerX - 70, 50);

            lblPassword.Location = new Point(centerX - 150, 85);
            txtPassword.Location = new Point(centerX - 70, 85);

            btnTogglePassword.Location = new Point(centerX + 135, 85);

            Btn_vhod.Location = new Point(centerX - 130, 130);
            Btn_Registration.Location = new Point(centerX + 10, 130);

        }

        protected override void CenterControlsInPanel()
        {
            // Проверяем, что все элементы существуют
            if (lblLogin == null || txtLogin == null ||
                lblPassword == null || txtPassword == null ||
                Btn_vhod == null || Btn_Registration == null)
            {
                return;
            }

            int centerX = contentPanel.Width / 2;
            int centerY = contentPanel.Height / 2;

            int startY = centerY - 80;

            lblLogin.Location = new Point(centerX - 130, startY);
            txtLogin.Location = new Point(centerX - 70, startY);

            lblPassword.Location = new Point(centerX - 130, startY + 35);
            txtPassword.Location = new Point(centerX - 70, startY + 35);

            btnTogglePassword.Location = new Point(centerX + 135, startY + 35);
            Btn_vhod.Location = new Point(centerX - 130, startY + 80);
            Btn_Registration.Location = new Point(centerX + 10, startY + 80);
        }

        protected override void ResetControlsPosition()
        {
            SetNormalPositions();
        }

        private void Btn_vhod_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                AppDialog.Warning(this, "Введите логин и пароль!");
                return;
            }

            try
            {
                var userFromDb = DatabaseHelper.GetUser(login);

                if (userFromDb == null)
                {
                    AppDialog.Error(this, "Пользователь не найден!");
                    return;
                }

                string hashedPassword = HashPassword(password);

                if (userFromDb.Password == hashedPassword)
                {
                    AuthManager.CurrentUser = userFromDb;
                    AppDialog.Success(this, $"Добро пожаловать, {userFromDb.FullName}!");

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    AppDialog.Error(this, "Неверный пароль!");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                AppDialog.Error(this, $"Ошибка при входе: {ex.Message}");
            }
        }

        private void Btn_Registration_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
            this.Hide();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
    }
}