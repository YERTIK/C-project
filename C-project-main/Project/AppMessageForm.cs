using System;
using System.Drawing;
using System.Windows.Forms;
using Project.Helpers;

namespace Project
{
    public partial class AppMessageForm : Form
    {
        public AppMessageForm(string title, string message, MessageDialogMode mode)
        {
            InitializeComponent();
            Configure(title, message, mode);
        }

        private void Configure(string title, string message, MessageDialogMode mode)
        {
            Text = title;
            lblTitle.Text = title;
            lblMessage.Text = message;

            bool isConfirm = mode == MessageDialogMode.YesNo;
            btnOk.Visible = !isConfirm;
            btnYes.Visible = isConfirm;
            btnNo.Visible = isConfirm;

            AcceptButton = isConfirm ? btnYes : btnOk;
            CancelButton = btnNo;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
