using System.Windows.Forms;

namespace MVPDemo.Services
{
    public class MessageBoxPresenter:IMessageBoxPresenter
    {
        public DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
           return Show(null, text, caption, buttons, icon);
        }

        public DialogResult Show(IView mainView, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(mainView as IWin32Window,text, caption, buttons, icon);
        }
    }
}