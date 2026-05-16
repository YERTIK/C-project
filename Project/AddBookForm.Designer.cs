namespace Project
{
    partial class AddBookForm
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblLoanDays = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numLoanDays = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddGenre = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoanDays)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAuthor.Location = new System.Drawing.Point(24, 64);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(59, 19);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Автор:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblGenre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGenre.Location = new System.Drawing.Point(24, 104);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(54, 19);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Жанр:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblYear.Location = new System.Drawing.Point(24, 144);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 19);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Год:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblQuantity.Location = new System.Drawing.Point(24, 184);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(102, 19);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Количество:";
            // 
            // lblLoanDays
            // 
            this.lblLoanDays.AutoSize = true;
            this.lblLoanDays.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoanDays.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoanDays.Location = new System.Drawing.Point(24, 224);
            this.lblLoanDays.Name = "lblLoanDays";
            this.lblLoanDays.Size = new System.Drawing.Size(149, 19);
            this.lblLoanDays.TabIndex = 5;
            this.lblLoanDays.Text = "Срок сдачи (дней):";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTitle.Location = new System.Drawing.Point(190, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(320, 26);
            this.txtTitle.TabIndex = 6;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.AliceBlue;
            this.txtAuthor.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtAuthor.Location = new System.Drawing.Point(190, 61);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(320, 26);
            this.txtAuthor.TabIndex = 7;
            // 
            // cmbGenre
            // 
            this.cmbGenre.BackColor = System.Drawing.Color.AliceBlue;
            this.cmbGenre.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(190, 101);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(250, 27);
            this.cmbGenre.TabIndex = 8;
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAddGenre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGenre.FlatAppearance.BorderSize = 0;
            this.btnAddGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGenre.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddGenre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddGenre.Location = new System.Drawing.Point(450, 100);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(60, 28);
            this.btnAddGenre.TabIndex = 9;
            this.btnAddGenre.Text = "+";
            this.btnAddGenre.UseVisualStyleBackColor = false;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // numYear
            // 
            this.numYear.BackColor = System.Drawing.Color.AliceBlue;
            this.numYear.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numYear.Location = new System.Drawing.Point(190, 142);
            this.numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 26);
            this.numYear.TabIndex = 10;
            this.numYear.Value = new decimal(new int[] { 2020, 0, 0, 0 });
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.AliceBlue;
            this.numQuantity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numQuantity.Location = new System.Drawing.Point(190, 182);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 26);
            this.numQuantity.TabIndex = 11;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numLoanDays
            // 
            this.numLoanDays.BackColor = System.Drawing.Color.AliceBlue;
            this.numLoanDays.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numLoanDays.Location = new System.Drawing.Point(190, 222);
            this.numLoanDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numLoanDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLoanDays.Name = "numLoanDays";
            this.numLoanDays.Size = new System.Drawing.Size(120, 26);
            this.numLoanDays.TabIndex = 12;
            this.numLoanDays.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(190, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Добавить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(360, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 34);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddBookForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 331);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numLoanDays);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblLoanDays);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить книгу";
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoanDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblLoanDays;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numLoanDays;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddGenre;
    }
}
