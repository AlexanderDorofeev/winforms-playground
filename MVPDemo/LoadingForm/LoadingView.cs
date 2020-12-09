using System;
using System.Drawing;
using System.Windows.Forms;

namespace MVPDemo.LoadingForm
{
    public partial class LoadingView : Form,ILoadingView
    {
        private readonly EventHandler _cancelButtonClick;
        public LoadingView()
        {
            InitializeComponent();
            _cancelButtonClick = (s, e) => OperationCancelled?.Invoke();
            btnCancel.Click += _cancelButtonClick;
        }

        public event Action OperationCancelled;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                btnCancel.Click -= _cancelButtonClick;
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        public void Show(IView parent)
        {
            if (parent!= null && parent is Control control)
            {
                StartPosition = FormStartPosition.Manual;
                Location = new Point(control.Location.X + control.Width/2 - Width / 2, control.Location.Y + control.Height / 2 - Height / 2);
            }
            Show();
        }
    }
}