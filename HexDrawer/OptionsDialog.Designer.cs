namespace HexDrawer
{
    partial class OptionsDialog
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
            this.HexesPerInchUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MarginUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ChangeColourButton = new System.Windows.Forms.Button();
            this.ColourPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ColourDialog = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.GridStyleDropDown = new System.Windows.Forms.ComboBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.GridPage = new System.Windows.Forms.TabPage();
            this.TuckBoxPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OkButton = new System.Windows.Forms.Button();
            this.CustomCancelButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TuckBoxHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.TuckBoxWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.TuckBoxDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HexesPerInchUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarginUpDown)).BeginInit();
            this.TabControl.SuspendLayout();
            this.GridPage.SuspendLayout();
            this.TuckBoxPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxDepthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // HexesPerInchUpDown
            // 
            this.HexesPerInchUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexesPerInchUpDown.Location = new System.Drawing.Point(146, 33);
            this.HexesPerInchUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HexesPerInchUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HexesPerInchUpDown.Name = "HexesPerInchUpDown";
            this.HexesPerInchUpDown.Size = new System.Drawing.Size(539, 20);
            this.HexesPerInchUpDown.TabIndex = 3;
            this.HexesPerInchUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Polygons Per Inch:";
            // 
            // MarginUpDown
            // 
            this.MarginUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MarginUpDown.DecimalPlaces = 1;
            this.MarginUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MarginUpDown.Location = new System.Drawing.Point(150, 2);
            this.MarginUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MarginUpDown.Name = "MarginUpDown";
            this.MarginUpDown.Size = new System.Drawing.Size(539, 20);
            this.MarginUpDown.TabIndex = 5;
            this.MarginUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Margin in Inches: (At least)";
            // 
            // ChangeColourButton
            // 
            this.ChangeColourButton.Location = new System.Drawing.Point(227, 59);
            this.ChangeColourButton.Name = "ChangeColourButton";
            this.ChangeColourButton.Size = new System.Drawing.Size(81, 24);
            this.ChangeColourButton.TabIndex = 8;
            this.ChangeColourButton.Text = "Change";
            this.ChangeColourButton.UseVisualStyleBackColor = true;
            this.ChangeColourButton.Click += new System.EventHandler(this.ChangeColourButton_Click);
            // 
            // ColourPanel
            // 
            this.ColourPanel.BackColor = System.Drawing.Color.Gray;
            this.ColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColourPanel.Location = new System.Drawing.Point(146, 59);
            this.ColourPanel.Name = "ColourPanel";
            this.ColourPanel.Size = new System.Drawing.Size(75, 24);
            this.ColourPanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Colour:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grid Style:";
            // 
            // GridStyleDropDown
            // 
            this.GridStyleDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridStyleDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GridStyleDropDown.FormattingEnabled = true;
            this.GridStyleDropDown.Location = new System.Drawing.Point(146, 6);
            this.GridStyleDropDown.Name = "GridStyleDropDown";
            this.GridStyleDropDown.Size = new System.Drawing.Size(539, 21);
            this.GridStyleDropDown.TabIndex = 1;
            // 
            // TabControl
            // 
            this.TabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControl.Controls.Add(this.GridPage);
            this.TabControl.Controls.Add(this.TuckBoxPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 26);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(701, 294);
            this.TabControl.TabIndex = 12;
            // 
            // GridPage
            // 
            this.GridPage.Controls.Add(this.label3);
            this.GridPage.Controls.Add(this.ColourPanel);
            this.GridPage.Controls.Add(this.label1);
            this.GridPage.Controls.Add(this.ChangeColourButton);
            this.GridPage.Controls.Add(this.GridStyleDropDown);
            this.GridPage.Controls.Add(this.HexesPerInchUpDown);
            this.GridPage.Controls.Add(this.label4);
            this.GridPage.Location = new System.Drawing.Point(4, 25);
            this.GridPage.Name = "GridPage";
            this.GridPage.Padding = new System.Windows.Forms.Padding(3);
            this.GridPage.Size = new System.Drawing.Size(693, 265);
            this.GridPage.TabIndex = 0;
            this.GridPage.Text = "Grid";
            this.GridPage.UseVisualStyleBackColor = true;
            // 
            // TuckBoxPage
            // 
            this.TuckBoxPage.Controls.Add(this.label7);
            this.TuckBoxPage.Controls.Add(this.label6);
            this.TuckBoxPage.Controls.Add(this.label5);
            this.TuckBoxPage.Controls.Add(this.TuckBoxDepthUpDown);
            this.TuckBoxPage.Controls.Add(this.TuckBoxWidthUpDown);
            this.TuckBoxPage.Controls.Add(this.TuckBoxHeightUpDown);
            this.TuckBoxPage.Location = new System.Drawing.Point(4, 25);
            this.TuckBoxPage.Name = "TuckBoxPage";
            this.TuckBoxPage.Padding = new System.Windows.Forms.Padding(3);
            this.TuckBoxPage.Size = new System.Drawing.Size(693, 265);
            this.TuckBoxPage.TabIndex = 1;
            this.TuckBoxPage.Text = "Tuck Box";
            this.TuckBoxPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Controls.Add(this.CustomCancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 29);
            this.panel1.TabIndex = 13;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(533, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 11;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CustomCancelButton
            // 
            this.CustomCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CustomCancelButton.Location = new System.Drawing.Point(614, 3);
            this.CustomCancelButton.Name = "CustomCancelButton";
            this.CustomCancelButton.Size = new System.Drawing.Size(75, 23);
            this.CustomCancelButton.TabIndex = 12;
            this.CustomCancelButton.Text = "Cancel";
            this.CustomCancelButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.MarginUpDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 26);
            this.panel2.TabIndex = 14;
            // 
            // TuckBoxHeightUpDown
            // 
            this.TuckBoxHeightUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TuckBoxHeightUpDown.DecimalPlaces = 1;
            this.TuckBoxHeightUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TuckBoxHeightUpDown.Location = new System.Drawing.Point(146, 6);
            this.TuckBoxHeightUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TuckBoxHeightUpDown.Name = "TuckBoxHeightUpDown";
            this.TuckBoxHeightUpDown.Size = new System.Drawing.Size(539, 20);
            this.TuckBoxHeightUpDown.TabIndex = 6;
            this.TuckBoxHeightUpDown.Value = new decimal(new int[] {
            38,
            0,
            0,
            65536});
            // 
            // TuckBoxWidthUpDown
            // 
            this.TuckBoxWidthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TuckBoxWidthUpDown.DecimalPlaces = 1;
            this.TuckBoxWidthUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TuckBoxWidthUpDown.Location = new System.Drawing.Point(146, 32);
            this.TuckBoxWidthUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.TuckBoxWidthUpDown.Name = "TuckBoxWidthUpDown";
            this.TuckBoxWidthUpDown.Size = new System.Drawing.Size(539, 20);
            this.TuckBoxWidthUpDown.TabIndex = 7;
            this.TuckBoxWidthUpDown.Value = new decimal(new int[] {
            27,
            0,
            0,
            65536});
            // 
            // TuckBoxDepthUpDown
            // 
            this.TuckBoxDepthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TuckBoxDepthUpDown.DecimalPlaces = 1;
            this.TuckBoxDepthUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TuckBoxDepthUpDown.Location = new System.Drawing.Point(146, 58);
            this.TuckBoxDepthUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.TuckBoxDepthUpDown.Name = "TuckBoxDepthUpDown";
            this.TuckBoxDepthUpDown.Size = new System.Drawing.Size(539, 20);
            this.TuckBoxDepthUpDown.TabIndex = 8;
            this.TuckBoxDepthUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Height in Inches:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Width in Inches:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Depth in Inches:";
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 349);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Shown += new System.EventHandler(this.OptionsDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HexesPerInchUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarginUpDown)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.GridPage.ResumeLayout(false);
            this.GridPage.PerformLayout();
            this.TuckBoxPage.ResumeLayout(false);
            this.TuckBoxPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuckBoxDepthUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown HexesPerInchUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MarginUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeColourButton;
        private System.Windows.Forms.Panel ColourPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog ColourDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GridStyleDropDown;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage GridPage;
        private System.Windows.Forms.TabPage TuckBoxPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CustomCancelButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown TuckBoxDepthUpDown;
        private System.Windows.Forms.NumericUpDown TuckBoxWidthUpDown;
        private System.Windows.Forms.NumericUpDown TuckBoxHeightUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}