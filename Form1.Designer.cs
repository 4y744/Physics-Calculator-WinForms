namespace PhysicsCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.typeLabel1 = new System.Windows.Forms.Label();
            this.typeLabel2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // typeLabel1
            // 
            this.typeLabel1.AutoSize = true;
            this.typeLabel1.Location = new System.Drawing.Point(7, 15);
            this.typeLabel1.Name = "typeLabel1";
            this.typeLabel1.Size = new System.Drawing.Size(45, 15);
            this.typeLabel1.TabIndex = 2;
            this.typeLabel1.Text = "m (kg):";
            // 
            // typeLabel2
            // 
            this.typeLabel2.AutoSize = true;
            this.typeLabel2.Location = new System.Drawing.Point(7, 44);
            this.typeLabel2.Name = "typeLabel2";
            this.typeLabel2.Size = new System.Drawing.Size(54, 15);
            this.typeLabel2.TabIndex = 3;
            this.typeLabel2.Text = "a (m/s2):";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "F",
            "p",
            "A",
            "P",
            "Ep",
            "Ek",
            "m (F)",
            "m (Ep)",
            "m (Ek)",
            "a (F)",
            "v (Ek)",
            "h (Ep)",
            "t (P)",
            "F (A)",
            "F (p)"});
            this.comboBox1.Location = new System.Drawing.Point(195, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(112, 78);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(13, 15);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Result:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "F",
            "p",
            "A",
            "P",
            "Ep",
            "Ek",
            "m (F)",
            "m (Ep)",
            "m (Ek)",
            "a (F)",
            "v (Ek)",
            "h (Ep)",
            "t (P)",
            "F (A)",
            "F (p)"});
            this.comboBox2.Location = new System.Drawing.Point(195, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 23);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.typeLabel2);
            this.Controls.Add(this.typeLabel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label typeLabel1;
        private Label typeLabel2;
        private ComboBox comboBox1;
        private Label resultLabel;
        private Label label1;
        private ComboBox comboBox2;
    }
}