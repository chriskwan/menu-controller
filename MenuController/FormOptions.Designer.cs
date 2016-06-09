namespace MenuController
{
    partial class FormOptions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDisplayBehavior = new System.Windows.Forms.ComboBox();
            this.cboOrientation = new System.Windows.Forms.ComboBox();
            this.cboButtonSize = new System.Windows.Forms.ComboBox();
            this.ckAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Button size:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(253, 351);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(334, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Orientation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Display behavior:";
            // 
            // cboDisplayBehavior
            // 
            this.cboDisplayBehavior.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MenuController.Settings.Default, "DisplayBehavior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboDisplayBehavior.FormattingEnabled = true;
            this.cboDisplayBehavior.Items.AddRange(new object[] {
            "None",
            "Auto-resize compatible windows",
            "Auto-hide Menu Controller"});
            this.cboDisplayBehavior.Location = new System.Drawing.Point(15, 127);
            this.cboDisplayBehavior.Name = "cboDisplayBehavior";
            this.cboDisplayBehavior.Size = new System.Drawing.Size(394, 21);
            this.cboDisplayBehavior.TabIndex = 6;
            this.cboDisplayBehavior.Text = global::MenuController.Settings.Default.DisplayBehavior;
            // 
            // cboOrientation
            // 
            this.cboOrientation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MenuController.Settings.Default, "Orientation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboOrientation.FormattingEnabled = true;
            this.cboOrientation.Items.AddRange(new object[] {
            "Horizontal - Top",
            "Horizontal - Bottom",
            "Vertical - Left",
            "Vertical - Right"});
            this.cboOrientation.Location = new System.Drawing.Point(15, 78);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(394, 21);
            this.cboOrientation.TabIndex = 4;
            this.cboOrientation.Text = global::MenuController.Settings.Default.Orientation;
            // 
            // cboButtonSize
            // 
            this.cboButtonSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MenuController.Settings.Default, "ButtonSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboButtonSize.FormattingEnabled = true;
            this.cboButtonSize.Items.AddRange(new object[] {
            "50 x 50",
            "75 x 75",
            "100 x 100",
            "125 x 125",
            "150 x 150",
            "175 x 175",
            "200 x 200",
            "225 x 225",
            "250 x 250",
            "275 x 275",
            "300 x 300"});
            this.cboButtonSize.Location = new System.Drawing.Point(15, 31);
            this.cboButtonSize.Name = "cboButtonSize";
            this.cboButtonSize.Size = new System.Drawing.Size(394, 21);
            this.cboButtonSize.TabIndex = 0;
            this.cboButtonSize.Text = global::MenuController.Settings.Default.ButtonSize;
            // 
            // ckAlwaysOnTop
            // 
            this.ckAlwaysOnTop.AutoSize = true;
            this.ckAlwaysOnTop.Checked = global::MenuController.Settings.Default.AlwaysOnTop;
            this.ckAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAlwaysOnTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MenuController.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ckAlwaysOnTop.Location = new System.Drawing.Point(20, 175);
            this.ckAlwaysOnTop.Name = "ckAlwaysOnTop";
            this.ckAlwaysOnTop.Size = new System.Drawing.Size(92, 17);
            this.ckAlwaysOnTop.TabIndex = 8;
            this.ckAlwaysOnTop.Text = "Always on top";
            this.ckAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 386);
            this.Controls.Add(this.ckAlwaysOnTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDisplayBehavior);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboOrientation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboButtonSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboButtonSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOrientation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDisplayBehavior;
        private System.Windows.Forms.CheckBox ckAlwaysOnTop;
    }
}