using System.Windows.Forms;

namespace MVPDemo.Services
{
    public interface IMessageBoxPresenter
    {
        DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
        
        DialogResult Show(IView mainView,string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}