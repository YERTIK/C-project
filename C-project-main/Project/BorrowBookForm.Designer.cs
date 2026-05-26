namespace Project
{
    partial class BorrowBookForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblAuthorValue = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblGenreValue = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblAvailableValue = new System.Windows.Forms.Label();
            this.lblLoanDays = new System.Windows.Forms.Label();
            this.lblLoanDaysValue = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBookTitle.Location = new System.Drawing.Point(24, 20);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(460, 28);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Название";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAuthor.Location = new System.Drawing.Point(24, 60);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(58, 19);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Автор:";
            // 
            // lblAuthorValue
            // 
            this.lblAuthorValue.AutoSize = true;
            this.lblAuthorValue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblAuthorValue.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAuthorValue.Location = new System.Drawing.Point(190, 60);
            this.lblAuthorValue.Name = "lblAuthorValue";
            this.lblAuthorValue.Size = new System.Drawing.Size(15, 19);
            this.lblAuthorValue.TabIndex = 2;
            this.lblAuthorValue.Text = "-";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblGenre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGenre.Location = new System.Drawing.Point(24, 92);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(55, 19);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Жанр:";
            // 
            // lblGenreValue
            // 
            this.lblGenreValue.AutoSize = true;
            this.lblGenreValue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblGenreValue.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblGenreValue.Location = new System.Drawing.Point(190, 92);
            this.lblGenreValue.Name = "lblGenreValue";
            this.lblGenreValue.Size = new System.Drawing.Size(15, 19);
            this.lblGenreValue.TabIndex = 4;
            this.lblGenreValue.Text = "-";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvailable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAvailable.Location = new System.Drawing.Point(24, 124);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(82, 19);
            this.lblAvailable.TabIndex = 5;
            this.lblAvailable.Text = "Доступно:";
            // 
            // lblAvailableValue
            // 
            this.lblAvailableValue.AutoSize = true;
            this.lblAvailableValue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblAvailableValue.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblAvailableValue.Location = new System.Drawing.Point(190, 124);
            this.lblAvailableValue.Name = "lblAvailableValue";
            this.lblAvailableValue.Size = new System.Drawing.Size(15, 19);
            this.lblAvailableValue.TabIndex = 6;
            this.lblAvailableValue.Text = "-";
            // 
            // lblLoanDays
            // 
            this.lblLoanDays.AutoSize = true;
            this.lblLoanDays.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoanDays.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoanDays.Location = new System.Drawing.Point(24, 156);
            this.lblLoanDays.Name = "lblLoanDays";
            this.lblLoanDays.Size = new System.Drawing.Size(94, 19);
            this.lblLoanDays.TabIndex = 7;
            this.lblLoanDays.Text = "Срок сдачи:";
            // 
            // lblLoanDaysValue
            // 
            this.lblLoanDaysValue.AutoSize = true;
            this.lblLoanDaysValue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblLoanDaysValue.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblLoanDaysValue.Location = new System.Drawing.Point(190, 156);
            this.lblLoanDaysValue.Name = "lblLoanDaysValue";
            this.lblLoanDaysValue.Size = new System.Drawing.Size(15, 19);
            this.lblLoanDaysValue.TabIndex = 8;
            this.lblLoanDaysValue.Text = "-";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblQuantity.Location = new System.Drawing.Point(24, 196);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 19);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Количество:";
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.AliceBlue;
            this.numQuantity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numQuantity.Location = new System.Drawing.Point(190, 194);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 26);
            this.numQuantity.TabIndex = 10;
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnBorrow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrow.Location = new System.Drawing.Point(190, 248);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(150, 34);
            this.btnBorrow.TabIndex = 11;
            this.btnBorrow.Text = "Взять";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(360, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 34);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorrowBookForm
            // 
            this.AcceptButton = this.btnBorrow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblLoanDaysValue);
            this.Controls.Add(this.lblLoanDays);
            this.Controls.Add(this.lblAvailableValue);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblGenreValue);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblAuthorValue);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblBookTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Взять книгу";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblAuthorValue;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblGenreValue;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Label lblLoanDays;
        private System.Windows.Forms.Label lblLoanDaysValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnCancel;
    }
}
