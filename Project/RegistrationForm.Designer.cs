namespace Project
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblPasswordStrength;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblCourse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.btnToggleConfirmPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLogin.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtLogin.Location = new System.Drawing.Point(124, 12);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(200, 26);
            this.txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtPassword.Location = new System.Drawing.Point(124, 227);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 26);
            this.txtPassword.TabIndex = 9;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(124, 263);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 26);
            this.txtConfirmPassword.TabIndex = 11;
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFullName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtFullName.Location = new System.Drawing.Point(124, 42);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 26);
            this.txtFullName.TabIndex = 3;
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.Color.AliceBlue;
            this.txtGroup.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtGroup.Location = new System.Drawing.Point(124, 72);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(200, 26);
            this.txtGroup.TabIndex = 5;
            // 
            // cmbCourse
            // 
            this.cmbCourse.BackColor = System.Drawing.Color.AliceBlue;
            this.cmbCourse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbCourse.Location = new System.Drawing.Point(124, 102);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(200, 27);
            this.cmbCourse.TabIndex = 7;
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPasswordStrength.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPasswordStrength.Location = new System.Drawing.Point(93, 292);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(240, 20);
            this.lblPasswordStrength.TabIndex = 12;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegister.Location = new System.Drawing.Point(93, 315);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(164, 30);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Зарегистрироваться";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightCoral;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(263, 315);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(70, 30);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLogin.Location = new System.Drawing.Point(24, 12);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(100, 20);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPassword.Location = new System.Drawing.Point(24, 234);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 20);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Пароль:";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblConfirmPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblConfirmPassword.Location = new System.Drawing.Point(24, 270);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(86, 20);
            this.lblConfirmPassword.TabIndex = 10;
            this.lblConfirmPassword.Text = "Повторите:";
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFullName.Location = new System.Drawing.Point(24, 45);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 20);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "ФИО:";
            // 
            // lblGroup
            // 
            this.lblGroup.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGroup.Location = new System.Drawing.Point(24, 71);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(100, 20);
            this.lblGroup.TabIndex = 4;
            this.lblGroup.Text = "Группа:";
            // 
            // lblCourse
            // 
            this.lblCourse.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCourse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCourse.Location = new System.Drawing.Point(24, 101);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(100, 20);
            this.lblCourse.TabIndex = 6;
            this.lblCourse.Text = "Курс:";
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.BackColor = System.Drawing.Color.White;
            this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTogglePassword.Location = new System.Drawing.Point(335, 228);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(30, 25);
            this.btnTogglePassword.TabIndex = 15;
            this.btnTogglePassword.Text = "👁";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // btnToggleConfirmPassword
            // 
            this.btnToggleConfirmPassword.BackColor = System.Drawing.Color.White;
            this.btnToggleConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnToggleConfirmPassword.Location = new System.Drawing.Point(335, 263);
            this.btnToggleConfirmPassword.Name = "btnToggleConfirmPassword";
            this.btnToggleConfirmPassword.Size = new System.Drawing.Size(30, 25);
            this.btnToggleConfirmPassword.TabIndex = 16;
            this.btnToggleConfirmPassword.Text = "👁";
            this.btnToggleConfirmPassword.UseVisualStyleBackColor = false;
            this.btnToggleConfirmPassword.Click += new System.EventHandler(this.btnToggleConfirmPassword_Click);
            // 
            // RegistrationForm
            // 
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(381, 360);
            this.Controls.Add(this.btnToggleConfirmPassword);
            this.Controls.Add(this.btnTogglePassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblPasswordStrength);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Button btnToggleConfirmPassword;
    }
}