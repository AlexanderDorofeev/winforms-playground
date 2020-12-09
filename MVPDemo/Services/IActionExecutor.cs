using System;
using System.Threading;
using System.Threading.Tasks;

namespace MVPDemo.Services
{
    public interface IActionExecutor
    {
        Task ExecuteActionAsync(Func<CancellationToken, Task> action, IView mainView = null, Action cancellationAction = null);
    }
}