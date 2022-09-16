namespace GUI
{
    partial class SelectUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelLoadingButton = new System.Windows.Forms.Button();
            this.loadAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelLoadingButton
            // 
            this.cancelLoadingButton.Enabled = false;
            this.cancelLoadingButton.Location = new System.Drawing.Point(4, 56);
            this.cancelLoadingButton.Name = "cancelLoadingButton";
            this.cancelLoadingButton.Size = new System.Drawing.Size(242, 49);
            this.cancelLoadingButton.TabIndex = 5;
            this.cancelLoadingButton.Text = "Cancel loading";
            this.cancelLoadingButton.UseVisualStyleBackColor = true;
            this.cancelLoadingButton.Click += new System.EventHandler(this.cancelLoadingButton_Click);
            // 
            // loadAllButton
            // 
            this.loadAllButton.Location = new System.Drawing.Point(3, 3);
            this.loadAllButton.Name = "loadAllButton";
            this.loadAllButton.Size = new System.Drawing.Size(242, 49);
            this.loadAllButton.TabIndex = 6;
            this.loadAllButton.Text = "Load all";
            this.loadAllButton.UseVisualStyleBackColor = true;
            this.loadAllButton.Click += new System.EventHandler(this.loadAllButton_Click);
            // 
            // SelectUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadAllButton);
            this.Controls.Add(this.cancelLoadingButton);
            this.Name = "SelectUC";
            this.Size = new System.Drawing.Size(249, 108);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cancelLoadingButton;
        private Button loadAllButton;
    }
}
