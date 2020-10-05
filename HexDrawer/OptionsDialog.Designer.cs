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
            this.CustomCancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.ColourDialog = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.GridStyleDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.HexesPerInchUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarginUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // HexesPerInchUpDown
            // 
            this.HexesPerInchUpDown.Location = new System.Drawing.Point(153, 33);
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
            this.HexesPerInchUpDown.Size = new System.Drawing.Size(132, 20);
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
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Polygons Per Inch:";
            // 
            // MarginUpDown
            // 
            this.MarginUpDown.DecimalPlaces = 1;
            this.MarginUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MarginUpDown.Location = new System.Drawing.Point(153, 59);
            this.MarginUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MarginUpDown.Name = "MarginUpDown";
            this.MarginUpDown.Size = new System.Drawing.Size(132, 20);
            this.MarginUpDown.TabIndex = 5;
            this.MarginUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Margin in Inches: (At least)";
            // 
            // ChangeColourButton
            // 
            this.ChangeColourButton.Location = new System.Drawing.Point(210, 85);
            this.ChangeColourButton.Name = "ChangeColourButton";
            this.ChangeColourButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeColourButton.TabIndex = 8;
            this.ChangeColourButton.Text = "Change";
            this.ChangeColourButton.UseVisualStyleBackColor = true;
            this.ChangeColourButton.Click += new System.EventHandler(this.ChangeColourButton_Click);
            // 
            // ColourPanel
            // 
            this.ColourPanel.BackColor = System.Drawing.Color.Gray;
            this.ColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColourPanel.Location = new System.Drawing.Point(153, 85);
            this.ColourPanel.Name = "ColourPanel";
            this.ColourPanel.Size = new System.Drawing.Size(51, 23);
            this.ColourPanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Colour:";
            // 
            // CustomCancelButton
            // 
            this.CustomCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CustomCancelButton.Location = new System.Drawing.Point(210, 132);
            this.CustomCancelButton.Name = "CustomCancelButton";
            this.CustomCancelButton.Size = new System.Drawing.Size(75, 23);
            this.CustomCancelButton.TabIndex = 10;
            this.CustomCancelButton.Text = "Cancel";
            this.CustomCancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(129, 132);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grid Style:";
            // 
            // GridStyleDropDown
            // 
            this.GridStyleDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GridStyleDropDown.FormattingEnabled = true;
            this.GridStyleDropDown.Location = new System.Drawing.Point(153, 6);
            this.GridStyleDropDown.Name = "GridStyleDropDown";
            this.GridStyleDropDown.Size = new System.Drawing.Size(132, 21);
            this.GridStyleDropDown.TabIndex = 1;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 167);
            this.Controls.Add(this.GridStyleDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CustomCancelButton);
            this.Controls.Add(this.ChangeColourButton);
            this.Controls.Add(this.ColourPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MarginUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HexesPerInchUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.Shown += new System.EventHandler(this.OptionsDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HexesPerInchUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarginUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown HexesPerInchUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MarginUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeColourButton;
        private System.Windows.Forms.Panel ColourPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CustomCancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ColorDialog ColourDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GridStyleDropDown;
    }
}