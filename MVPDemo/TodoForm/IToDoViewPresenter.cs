using System;

namespace MVPDemo.Presenters
{
    public interface IToDoViewPresenter : IDisposable
    {
        void Show();
    }
}