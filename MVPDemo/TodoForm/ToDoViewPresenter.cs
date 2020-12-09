using MVPDemo.Model;
using MVPDemo.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPDemo.Presenters
{
    public class ToDoViewPresenter : IToDoViewPresenter
    {
        private readonly ITodoView _view;
        private readonly IMessageBoxPresenter _messageBoxPresenter;
        private readonly IToDoItemRepository _repository;
        private readonly IActionExecutor _actionExecutor;

        public ToDoViewPresenter(ITodoView view, IToDoItemRepository repository, IActionExecutor actionExecutor, IMessageBoxPresenter messageBoxPresenter)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _actionExecutor = actionExecutor ?? throw new ArgumentNullException(nameof(actionExecutor));
            _messageBoxPresenter = messageBoxPresenter ?? throw new ArgumentNullException(nameof(messageBoxPresenter));

            view.CloseButtonClick += view.Dispose;
            view.AddButtonClick += OnAddButtonClick;
            view.ToDoItemChecked += OnChangeItemChecked;
            view.Loaded += OnLoaded;
        }

        private async void OnChangeItemChecked(int id, bool hasChecked)
        {
            await _actionExecutor.ExecuteActionAsync(c => ChangeItemStateAsync(id, hasChecked, c), _view, () => _view.ChangeCompleted(id, !hasChecked));
        }

        private async void OnAddButtonClick() => await _actionExecutor.ExecuteActionAsync(AddItemAsync, _view);

        private async void OnLoaded() => await _actionExecutor.ExecuteActionAsync(GetItemsAsync, _view);

        public void Show() => _view.Show();
        
        private async Task ChangeItemStateAsync(int id, bool hasChecked, CancellationToken cancellationToken)
        {
            //  throw new Exception("Can't do that"); //uncomment to test exception handing
            //  await Task.Delay(5000, cancellationToken); //uncomment to test cancellation
            
            var item = await _repository.GetByIdAsync(id, cancellationToken);
            item.Completed = hasChecked;
            await _repository.SaveChangesAsync(cancellationToken);
        }

        private async Task GetItemsAsync(CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync(cancellationToken);
            foreach (var todoItem in items)
            {
                _view.AddToDoItem(todoItem);
            }
        }

        private async Task AddItemAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(_view.TodoInputText))
            {
                var item = new TodoItem(null, _view.TodoInputText, false);
                _repository.Add(item);
                await _repository.SaveChangesAsync(cancellationToken);
                _view.AddToDoItem(item);
                _view.TodoInputText = string.Empty;
            }
            else
            {
                _messageBoxPresenter.Show(_view, "You must provide a title", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void Dispose()
        {
            _view.CloseButtonClick -= _view.Hide;
            _view.AddButtonClick -= OnAddButtonClick;
            _view.ToDoItemChecked -= OnChangeItemChecked;
            _view.Loaded -= OnLoaded;
            _view?.Dispose();
        }
    }
}