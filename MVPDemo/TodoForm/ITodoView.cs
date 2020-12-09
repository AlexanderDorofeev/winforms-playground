using System;
using System.Collections.Generic;
using MVPDemo.Model;

namespace MVPDemo
{
    public interface ITodoView:IForm
    {
        event Action Loaded;
        event Action AddButtonClick;
        event Action CloseButtonClick;
        event Action<int,bool> ToDoItemChecked;
        string TodoInputText { get; set; }
        void ChangeCompleted(int itemId, bool completed);
        void AddToDoItem(TodoItem item);
        void Show();
    }
}