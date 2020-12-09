using System.ComponentModel;

namespace MVPDemo.LoadingForm
{
    partial class LoadingView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingView));
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(19, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pbSpinner
            // 
            this.pbSpinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSpinner.Image = ((System.Drawing.Image)(resources.GetObject("pbSpinner.Image")));
            this.pbSpinner.Location = new System.Drawing.Point(24, 19);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(65, 65);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSpinner.TabIndex = 1;
            this.pbSpinner.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.pbSpinner);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(112, 132);
            this.panelMain.TabIndex = 2;
            // 
            // LoadingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(112, 132);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LoadingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.Panel panelMain;
    }
}