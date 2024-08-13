namespace TSPJamaica
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GreedySearchRadioButton = new System.Windows.Forms.RadioButton();
            this.AStarRadioButton = new System.Windows.Forms.RadioButton();
            this.BestFirstSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.StartVertexComboBox = new System.Windows.Forms.ComboBox();
            this.EndVertexComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1191, 548);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // GreedySearchRadioButton
            // 
            this.GreedySearchRadioButton.AutoSize = true;
            this.GreedySearchRadioButton.Location = new System.Drawing.Point(150, 12);
            this.GreedySearchRadioButton.Name = "GreedySearchRadioButton";
            this.GreedySearchRadioButton.Size = new System.Drawing.Size(96, 17);
            this.GreedySearchRadioButton.TabIndex = 3;
            this.GreedySearchRadioButton.TabStop = true;
            this.GreedySearchRadioButton.Text = "Greedy Search";
            this.GreedySearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // AStarRadioButton
            // 
            this.AStarRadioButton.AutoSize = true;
            this.AStarRadioButton.Location = new System.Drawing.Point(150, 35);
            this.AStarRadioButton.Name = "AStarRadioButton";
            this.AStarRadioButton.Size = new System.Drawing.Size(73, 17);
            this.AStarRadioButton.TabIndex = 4;
            this.AStarRadioButton.TabStop = true;
            this.AStarRadioButton.Text = "A* Search";
            this.AStarRadioButton.UseVisualStyleBackColor = true;
            // 
            // BestFirstSearchRadioButton
            // 
            this.BestFirstSearchRadioButton.AutoSize = true;
            this.BestFirstSearchRadioButton.Location = new System.Drawing.Point(150, 58);
            this.BestFirstSearchRadioButton.Name = "BestFirstSearchRadioButton";
            this.BestFirstSearchRadioButton.Size = new System.Drawing.Size(105, 17);
            this.BestFirstSearchRadioButton.TabIndex = 5;
            this.BestFirstSearchRadioButton.TabStop = true;
            this.BestFirstSearchRadioButton.Text = "Best First Search";
            this.BestFirstSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(278, 58);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.AutoSize = true;
            this.DisplayLabel.Location = new System.Drawing.Point(392, 14);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(41, 13);
            this.DisplayLabel.TabIndex = 6;
            this.DisplayLabel.Text = "Display";
            // 
            // StartVertexComboBox
            // 
            this.StartVertexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartVertexComboBox.FormattingEnabled = true;
            this.StartVertexComboBox.Location = new System.Drawing.Point(12, 12);
            this.StartVertexComboBox.Name = "StartVertexComboBox";
            this.StartVertexComboBox.Size = new System.Drawing.Size(121, 21);
            this.StartVertexComboBox.TabIndex = 0;
            // 
            // EndVertexComboBox
            // 
            this.EndVertexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EndVertexComboBox.FormattingEnabled = true;
            this.EndVertexComboBox.Location = new System.Drawing.Point(12, 54);
            this.EndVertexComboBox.Name = "EndVertexComboBox";
            this.EndVertexComboBox.Size = new System.Drawing.Size(121, 21);
            this.EndVertexComboBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 699);
            this.Controls.Add(this.EndVertexComboBox);
            this.Controls.Add(this.StartVertexComboBox);
            this.Controls.Add(this.DisplayLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.BestFirstSearchRadioButton);
            this.Controls.Add(this.AStarRadioButton);
            this.Controls.Add(this.GreedySearchRadioButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton GreedySearchRadioButton;
        private System.Windows.Forms.RadioButton AStarRadioButton;
        private System.Windows.Forms.RadioButton BestFirstSearchRadioButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label DisplayLabel;
        private System.Windows.Forms.ComboBox StartVertexComboBox;
        private System.Windows.Forms.ComboBox EndVertexComboBox;
    }
}

