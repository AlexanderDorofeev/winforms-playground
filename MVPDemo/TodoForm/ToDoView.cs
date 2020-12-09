using System;
using System.Windows.Forms;
using MVPDemo.Model;

namespace MVPDemo
{
    public partial class ToDoView : Form, ITodoView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        private readonly EventHandler _addButtonClickHandler;
        private readonly EventHandler _exitButtonClickHandler;
        private readonly ItemCheckEventHandler _itemCheckedEventHandler;
        private readonly EventHandler _loadedEventHandler;
        
        private bool _isCheckedProgrammatically;

        public ToDoView()
        {
            InitializeComponent();
            _loadedEventHandler = (s, e) => Loaded?.Invoke();
            _addButtonClickHandler = (s, a) => AddButtonClick?.Invoke();
            _itemCheckedEventHandler = (s, e) =>
            {
                if (!_isCheckedProgrammatically)
                {
                    ToDoItemChecked?.Invoke(((TodoItem) chkListTodo.Items[e.Index]).Id.Value, e.NewValue == CheckState.Checked);
                }
            };
            _exitButtonClickHandler = (s, e) => CloseButtonClick?.Invoke();

            chkListTodo.ItemCheck += _itemCheckedEventHandler;
            btnAdd.Click += _addButtonClickHandler;
            btnExit.Click += _exitButtonClickHandler;
            Load += _loadedEventHandler;
            chkListTodo.DisplayMember = nameof(TodoItem.Title);
        }

        public string TodoInputText
        {
            get => txtTodoTitle.Text;
            set => txtTodoTitle.Text = value;
        }

        public void ChangeCompleted(int itemId, bool completed)
        {
            for (var i = 0; i < chkListTodo.Items.Count; i++)
            {
                var item = (TodoItem) chkListTodo.Items[i];
                if (item.Id == itemId)
                {
                    _isCheckedProgrammatically = true;
                    chkListTodo.SetItemChecked(i, completed);
                    _isCheckedProgrammatically = false;
                    break;
                }
            }
        }

        public void AddToDoItem(TodoItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var index = chkListTodo.Items.Add(item);
            
            //biding via ValueMember does not work for this control
            _isCheckedProgrammatically = true;
            chkListTodo.SetItemChecked(index, item.Completed);
            _isCheckedProgrammatically = false;
        }

        public event Action Loaded;
        public event Action AddButtonClick;
        public event Action CloseButtonClick;
        public event Action<int, bool> ToDoItemChecked;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                btnAdd.Click -= _addButtonClickHandler;
                chkListTodo.ItemCheck -= _itemCheckedEventHandler;
                btnExit.Click -= _exitButtonClickHandler;
                Load -= _loadedEventHandler;
                components?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}