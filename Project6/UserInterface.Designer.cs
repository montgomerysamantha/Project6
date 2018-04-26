namespace Project6
{
    partial class UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.uxPrimeOneLabel = new System.Windows.Forms.Label();
            this.uxPrimeTwoLabel = new System.Windows.Forms.Label();
            this.uxNumDigLabel = new System.Windows.Forms.Label();
            this.uxFindPrimePath = new System.Windows.Forms.Button();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxFirstPrimeBox = new System.Windows.Forms.TextBox();
            this.uxSecondPrimeBox = new System.Windows.Forms.TextBox();
            this.uxDigitsBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxDigitsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPrimeOneLabel
            // 
            this.uxPrimeOneLabel.AutoSize = true;
            this.uxPrimeOneLabel.Location = new System.Drawing.Point(37, 38);
            this.uxPrimeOneLabel.Name = "uxPrimeOneLabel";
            this.uxPrimeOneLabel.Size = new System.Drawing.Size(61, 13);
            this.uxPrimeOneLabel.TabIndex = 0;
            this.uxPrimeOneLabel.Text = "First Prime: ";
            // 
            // uxPrimeTwoLabel
            // 
            this.uxPrimeTwoLabel.AutoSize = true;
            this.uxPrimeTwoLabel.Location = new System.Drawing.Point(40, 89);
            this.uxPrimeTwoLabel.Name = "uxPrimeTwoLabel";
            this.uxPrimeTwoLabel.Size = new System.Drawing.Size(76, 13);
            this.uxPrimeTwoLabel.TabIndex = 1;
            this.uxPrimeTwoLabel.Text = "Second Prime:";
            // 
            // uxNumDigLabel
            // 
            this.uxNumDigLabel.AutoSize = true;
            this.uxNumDigLabel.Location = new System.Drawing.Point(40, 137);
            this.uxNumDigLabel.Name = "uxNumDigLabel";
            this.uxNumDigLabel.Size = new System.Drawing.Size(88, 13);
            this.uxNumDigLabel.TabIndex = 2;
            this.uxNumDigLabel.Text = "Number of Digits:";
            // 
            // uxFindPrimePath
            // 
            this.uxFindPrimePath.Location = new System.Drawing.Point(133, 182);
            this.uxFindPrimePath.Name = "uxFindPrimePath";
            this.uxFindPrimePath.Size = new System.Drawing.Size(156, 41);
            this.uxFindPrimePath.TabIndex = 3;
            this.uxFindPrimePath.Text = "Find Prime Path";
            this.uxFindPrimePath.UseVisualStyleBackColor = true;
            this.uxFindPrimePath.Click += new System.EventHandler(this.uxFindPrimePath_Click);
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(12, 249);
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.ReadOnly = true;
            this.uxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextBox.Size = new System.Drawing.Size(422, 125);
            this.uxTextBox.TabIndex = 4;
            // 
            // uxFirstPrimeBox
            // 
            this.uxFirstPrimeBox.Location = new System.Drawing.Point(229, 38);
            this.uxFirstPrimeBox.Name = "uxFirstPrimeBox";
            this.uxFirstPrimeBox.Size = new System.Drawing.Size(100, 20);
            this.uxFirstPrimeBox.TabIndex = 5;
            // 
            // uxSecondPrimeBox
            // 
            this.uxSecondPrimeBox.Location = new System.Drawing.Point(229, 81);
            this.uxSecondPrimeBox.Name = "uxSecondPrimeBox";
            this.uxSecondPrimeBox.Size = new System.Drawing.Size(100, 20);
            this.uxSecondPrimeBox.TabIndex = 6;
            // 
            // uxDigitsBox
            // 
            this.uxDigitsBox.Location = new System.Drawing.Point(229, 129);
            this.uxDigitsBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxDigitsBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxDigitsBox.Name = "uxDigitsBox";
            this.uxDigitsBox.Size = new System.Drawing.Size(120, 20);
            this.uxDigitsBox.TabIndex = 7;
            this.uxDigitsBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 386);
            this.Controls.Add(this.uxDigitsBox);
            this.Controls.Add(this.uxSecondPrimeBox);
            this.Controls.Add(this.uxFirstPrimeBox);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxFindPrimePath);
            this.Controls.Add(this.uxNumDigLabel);
            this.Controls.Add(this.uxPrimeTwoLabel);
            this.Controls.Add(this.uxPrimeOneLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInterface";
            this.Text = "Prime Changer";
            ((System.ComponentModel.ISupportInitialize)(this.uxDigitsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxPrimeOneLabel;
        private System.Windows.Forms.Label uxPrimeTwoLabel;
        private System.Windows.Forms.Label uxNumDigLabel;
        private System.Windows.Forms.Button uxFindPrimePath;
        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.TextBox uxFirstPrimeBox;
        private System.Windows.Forms.TextBox uxSecondPrimeBox;
        private System.Windows.Forms.NumericUpDown uxDigitsBox;
    }
}

