namespace Project
{
    partial class AppMessageForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Заголовок";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMessage.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblMessage.Location = new System.Drawing.Point(24, 58);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(420, 120);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Сообщение";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(195, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 34);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.LimeGreen;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnYes.Location = new System.Drawing.Point(28, 196);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(150, 34);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Да";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.LightCoral;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNo.Location = new System.Drawing.Point(361, 196);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(150, 34);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "Нет";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // AppMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(541, 252);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сообщение";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}
