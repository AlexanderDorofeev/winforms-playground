using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Options;
using MVPDemo.LoadingForm;

namespace MVPDemo.Services
{
    public class ActionExecutor : IActionExecutor
    {
        private readonly ILoadingView _loadingView;
        private readonly IMessageBoxPresenter _messageBoxPresenter;
        private readonly IOptions<ActionExecutorOptions> _options;

        public ActionExecutor(ILoadingView loadingView, IMessageBoxPresenter messageBoxPresenter, IOptions<ActionExecutorOptions> options)
        {
            _loadingView = loadingView ?? throw new ArgumentNullException(nameof(loadingView));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messageBoxPresenter = messageBoxPresenter ?? throw new ArgumentNullException(nameof(messageBoxPresenter));
        }

        public async Task ExecuteActionAsync(Func<CancellationToken, Task> action, IView mainView = null, Action cancellationAction = null)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            using var cts = new CancellationTokenSource();

            void OnCancel()
            {
                cts.Cancel();
                _loadingView.Hide();
            }

            try
            {
                _loadingView.OperationCancelled += OnCancel;
                var activityTask = action(cts.Token);
                var notifyDelayTask = Task.Delay(_options.Value.NotifyLoadingAfterMilliseconds);
                var winner = await Task.WhenAny(activityTask, notifyDelayTask);
                if (winner == notifyDelayTask)
                {
                    if (mainView != null)  mainView.Enabled = false;
                    _loadingView.Show(mainView);
                }
                
                await activityTask;
            }
            catch (TaskCanceledException)
            {
                cancellationAction?.Invoke();
            }
            catch (Exception e)
            {
                _messageBoxPresenter.Show(mainView, $"Unexpected error occured: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await Task.Delay(1,cts.Token);
                cancellationAction?.Invoke();
            }
            finally
            {
                if (mainView != null)  mainView.Enabled = true;
                _loadingView.OperationCancelled -= OnCancel;
                _loadingView.Hide();
            }
        }
    }
}