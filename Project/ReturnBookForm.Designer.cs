
namespace Project
{
    partial class ReturnBookForm
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
            this.components = new System.ComponentModel.Container();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblBorrowedCount = new System.Windows.Forms.Label();
            this.lblBookInfo = new System.Windows.Forms.Label();
            this.numReturnQuantity = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReturn.Location = new System.Drawing.Point(633, 395);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(139, 43);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Вернуть книгу";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // lblBorrowedCount
            // 
            this.lblBorrowedCount.AutoSize = true;
            this.lblBorrowedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBorrowedCount.Location = new System.Drawing.Point(30, 190);
            this.lblBorrowedCount.Name = "lblBorrowedCount";
            this.lblBorrowedCount.Size = new System.Drawing.Size(0, 20);
            this.lblBorrowedCount.TabIndex = 1;
            // 
            // lblBookInfo
            // 
            this.lblBookInfo.AutoSize = true;
            this.lblBookInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBookInfo.Location = new System.Drawing.Point(31, 227);
            this.lblBookInfo.Name = "lblBookInfo";
            this.lblBookInfo.Size = new System.Drawing.Size(0, 20);
            this.lblBookInfo.TabIndex = 2;
            // 
            // numReturnQuantity
            // 
            this.numReturnQuantity.Location = new System.Drawing.Point(525, 409);
            this.numReturnQuantity.Name = "numReturnQuantity";
            this.numReturnQuantity.Size = new System.Drawing.Size(82, 20);
            this.numReturnQuantity.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ReturnBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numReturnQuantity);
            this.Controls.Add(this.lblBookInfo);
            this.Controls.Add(this.lblBorrowedCount);
            this.Controls.Add(this.btnReturn);
            this.Name = "ReturnBookForm";
            this.Text = "ReturnBookForm";
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblBorrowedCount;
        private System.Windows.Forms.Label lblBookInfo;
        private System.Windows.Forms.NumericUpDown numReturnQuantity;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}