
namespace Project
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.dgvBorrowedBooks = new System.Windows.Forms.DataGridView();
            this.lblStats = new System.Windows.Forms.Label();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbHistory = new System.Windows.Forms.RadioButton();
            this.BtnReturntAll = new System.Windows.Forms.Button();
            this.BtnReturnSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightCoral;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(37, 391);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.AliceBlue;
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFullName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFullName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullName.Location = new System.Drawing.Point(37, 43);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(2, 21);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.AliceBlue;
            this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGroup.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGroup.Location = new System.Drawing.Point(37, 78);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(2, 21);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCourse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCourse.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCourse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCourse.Location = new System.Drawing.Point(37, 113);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(2, 21);
            this.lblCourse.TabIndex = 4;
            this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.BackColor = System.Drawing.Color.AliceBlue;
            this.lblRegistrationDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRegistrationDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblRegistrationDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistrationDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRegistrationDate.Location = new System.Drawing.Point(37, 145);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(2, 21);
            this.lblRegistrationDate.TabIndex = 5;
            this.lblRegistrationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.AliceBlue;
            this.lblLogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLogin.Location = new System.Drawing.Point(37, 175);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(2, 21);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvBorrowedBooks
            // 
            this.dgvBorrowedBooks.AllowUserToResizeColumns = false;
            this.dgvBorrowedBooks.AllowUserToResizeRows = false;
            this.dgvBorrowedBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowedBooks.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvBorrowedBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowedBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBorrowedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowedBooks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvBorrowedBooks.Location = new System.Drawing.Point(405, 32);
            this.dgvBorrowedBooks.Name = "dgvBorrowedBooks";
            this.dgvBorrowedBooks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrowedBooks.RowHeadersVisible = false;
            this.dgvBorrowedBooks.Size = new System.Drawing.Size(854, 417);
            this.dgvBorrowedBooks.TabIndex = 7;
            this.dgvBorrowedBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrowedBooks_CellClick);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.BackColor = System.Drawing.Color.AliceBlue;
            this.lblStats.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStats.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStats.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStats.Location = new System.Drawing.Point(37, 212);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(2, 21);
            this.lblStats.TabIndex = 8;
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.BackColor = System.Drawing.Color.DimGray;
            this.rbActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbActive.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rbActive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbActive.Location = new System.Drawing.Point(496, 2);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(68, 23);
            this.rbActive.TabIndex = 10;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Актив";
            this.rbActive.UseVisualStyleBackColor = false;
            // 
            // rbHistory
            // 
            this.rbHistory.AutoSize = true;
            this.rbHistory.BackColor = System.Drawing.Color.DimGray;
            this.rbHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbHistory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbHistory.Location = new System.Drawing.Point(405, 2);
            this.rbHistory.Name = "rbHistory";
            this.rbHistory.Size = new System.Drawing.Size(83, 23);
            this.rbHistory.TabIndex = 11;
            this.rbHistory.TabStop = true;
            this.rbHistory.Text = "История";
            this.rbHistory.UseVisualStyleBackColor = false;
            // 
            // BtnReturntAll
            // 
            this.BtnReturntAll.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnReturntAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReturntAll.FlatAppearance.BorderSize = 0;
            this.BtnReturntAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReturntAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.BtnReturntAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReturntAll.Location = new System.Drawing.Point(37, 345);
            this.BtnReturntAll.Name = "BtnReturntAll";
            this.BtnReturntAll.Size = new System.Drawing.Size(125, 40);
            this.BtnReturntAll.TabIndex = 12;
            this.BtnReturntAll.Text = "Вернуть всё";
            this.BtnReturntAll.UseVisualStyleBackColor = false;
            this.BtnReturntAll.Click += new System.EventHandler(this.BtnReturntAll_Click);
            // 
            // BtnReturnSelected
            // 
            this.BtnReturnSelected.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnReturnSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReturnSelected.FlatAppearance.BorderSize = 0;
            this.BtnReturnSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReturnSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.BtnReturnSelected.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReturnSelected.Location = new System.Drawing.Point(37, 286);
            this.BtnReturnSelected.Name = "BtnReturnSelected";
            this.BtnReturnSelected.Size = new System.Drawing.Size(125, 53);
            this.BtnReturnSelected.TabIndex = 13;
            this.BtnReturnSelected.Text = "Вернуть Выбранные";
            this.BtnReturnSelected.UseVisualStyleBackColor = false;
            this.BtnReturnSelected.Click += new System.EventHandler(this.BtnReturnSelected_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1271, 450);
            this.Controls.Add(this.BtnReturnSelected);
            this.Controls.Add(this.BtnReturntAll);
            this.Controls.Add(this.rbHistory);
            this.Controls.Add(this.rbActive);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.dgvBorrowedBooks);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblRegistrationDate);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbHistory;
        public System.Windows.Forms.DataGridView dgvBorrowedBooks;
        private System.Windows.Forms.Button BtnReturntAll;
        private System.Windows.Forms.Button BtnReturnSelected;
    }
}