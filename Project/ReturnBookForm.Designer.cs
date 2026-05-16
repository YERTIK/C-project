namespace Project
{
    partial class ReturnBookForm
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
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblOnHand = new System.Windows.Forms.Label();
            this.lblOnHandValue = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBookTitle.Location = new System.Drawing.Point(24, 24);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(460, 28);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Книга";
            // 
            // lblOnHand
            // 
            this.lblOnHand.AutoSize = true;
            this.lblOnHand.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblOnHand.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOnHand.Location = new System.Drawing.Point(24, 72);
            this.lblOnHand.Name = "lblOnHand";
            this.lblOnHand.Size = new System.Drawing.Size(78, 19);
            this.lblOnHand.TabIndex = 1;
            this.lblOnHand.Text = "На руках:";
            // 
            // lblOnHandValue
            // 
            this.lblOnHandValue.AutoSize = true;
            this.lblOnHandValue.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblOnHandValue.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblOnHandValue.Location = new System.Drawing.Point(190, 72);
            this.lblOnHandValue.Name = "lblOnHandValue";
            this.lblOnHandValue.Size = new System.Drawing.Size(12, 19);
            this.lblOnHandValue.TabIndex = 2;
            this.lblOnHandValue.Text = "-";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblQuantity.Location = new System.Drawing.Point(24, 116);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(196, 19);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Сколько вернуть:";
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.AliceBlue;
            this.numQuantity.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.numQuantity.Location = new System.Drawing.Point(190, 114);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 26);
            this.numQuantity.TabIndex = 4;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.LimeGreen;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(190, 168);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 34);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Вернуть";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(360, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReturnBookForm
            // 
            this.AcceptButton = this.btnReturn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(534, 230);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblOnHandValue);
            this.Controls.Add(this.lblOnHand);
            this.Controls.Add(this.lblBookTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Возврат книги";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblOnHand;
        private System.Windows.Forms.Label lblOnHandValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCancel;
    }
}
