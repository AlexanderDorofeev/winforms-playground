namespace MVPDemo
{
    partial class ToDoView
    {
    

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTodoTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkListTodo = new System.Windows.Forms.CheckedListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTodoTItle
            // 
            this.txtTodoTitle.Location = new System.Drawing.Point(12, 7);
            this.txtTodoTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTodoTitle.Name = "txtTodoTItle";
            this.txtTodoTitle.Size = new System.Drawing.Size(431, 23);
            this.txtTodoTitle.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(450, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // chkListTodo
            // 
            this.chkListTodo.FormattingEnabled = true;
            this.chkListTodo.Location = new System.Drawing.Point(12, 39);
            this.chkListTodo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkListTodo.Name = "chkListTodo";
            this.chkListTodo.Size = new System.Drawing.Size(510, 148);
            this.chkListTodo.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(217, 207);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 27);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // ToDoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 242);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chkListTodo);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTodoTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToDoView";
            this.Text = "Todo list";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.CheckedListBox chkListTodo;

        private System.Windows.Forms.Button btnAdd;

        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.TextBox txtTodoTitle;

        #endregion
    }
}