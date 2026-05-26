using System.Windows.Forms;

namespace Project.Helpers
{
    public enum MessageDialogMode
    {
        Ok,
        YesNo
    }

    public static class AppDialog
    {
        public static void Info(IWin32Window owner, string message, string title = "Информация")
        {
            Show(owner, title, message, MessageDialogMode.Ok);
        }

        public static void Success(IWin32Window owner, string message, string title = "Успех")
        {
            Show(owner, title, message, MessageDialogMode.Ok);
        }

        public static void Warning(IWin32Window owner, string message, string title = "Проверка")
        {
            Show(owner, title, message, MessageDialogMode.Ok);
        }

        public static void Error(IWin32Window owner, string message, string title = "Ошибка")
        {
            Show(owner, title, message, MessageDialogMode.Ok);
        }

        public static bool Confirm(IWin32Window owner, string message, string title = "Подтверждение")
        {
            return Show(owner, title, message, MessageDialogMode.YesNo) == DialogResult.Yes;
        }

        public static DialogResult Show(IWin32Window owner, string title, string message, MessageDialogMode mode)
        {
            using (var form = new AppMessageForm(title, message, mode))
                return form.ShowDialog(owner);
        }
    }
}
