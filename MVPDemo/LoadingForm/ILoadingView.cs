using System;

namespace MVPDemo.LoadingForm
{
    public interface ILoadingView:IForm
    {
        event Action OperationCancelled;
        void Show(IView parent);
    }
}