namespace GUI
{
    partial class InsertUC
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
            this.insert20Button = new System.Windows.Forms.Button();
            this.cancelInsertingButton = new System.Windows.Forms.Button();
            this.insert100Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // insert20Button
            // 
            this.insert20Button.Location = new System.Drawing.Point(127, 3);
            this.insert20Button.Name = "insert20Button";
            this.insert20Button.Size = new System.Drawing.Size(118, 44);
            this.insert20Button.TabIndex = 5;
            this.insert20Button.Text = "Insert 20 MB image";
            this.insert20Button.UseVisualStyleBackColor = true;
            // 
            // cancelInsertingButton
            // 
            this.cancelInsertingButton.Enabled = false;
            this.cancelInsertingButton.Location = new System.Drawing.Point(3, 53);
            this.cancelInsertingButton.Name = "cancelInsertingButton";
            this.cancelInsertingButton.Size = new System.Drawing.Size(242, 49);
            this.cancelInsertingButton.TabIndex = 4;
            this.cancelInsertingButton.Text = "Cancel inserting";
            this.cancelInsertingButton.UseVisualStyleBackColor = true;
            // 
            // insert100Button
            // 
            this.insert100Button.Location = new System.Drawing.Point(3, 3);
            this.insert100Button.Name = "insert100Button";
            this.insert100Button.Size = new System.Drawing.Size(118, 44);
            this.insert100Button.TabIndex = 3;
            this.insert100Button.Text = "Insert 100 MB image";
            this.insert100Button.UseVisualStyleBackColor = true;
            // 
            // InsertUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insert20Button);
            this.Controls.Add(this.cancelInsertingButton);
            this.Controls.Add(this.insert100Button);
            this.Name = "InsertUC";
            this.Size = new System.Drawing.Size(249, 108);
            this.ResumeLayout(false);

        }

        #endregion

        private Button insert20Button;
        private Button cancelInsertingButton;
        private Button insert100Button;
    }
}
