namespace iden_hash
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
            this.comboBoxHash = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.textBoxF1Path = new System.Windows.Forms.TextBox();
            this.textBoxF1Hash = new System.Windows.Forms.TextBox();
            this.textBoxF2Path = new System.Windows.Forms.TextBox();
            this.textBoxF2Hash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxHash
            // 
            this.comboBoxHash.FormattingEnabled = true;
            this.comboBoxHash.Items.AddRange(new object[] {
            "SHA1",
            "SHA256",
            "SHA512"});
            this.comboBoxHash.Location = new System.Drawing.Point(25, 30);
            this.comboBoxHash.Name = "comboBoxHash";
            this.comboBoxHash.Size = new System.Drawing.Size(221, 21);
            this.comboBoxHash.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hash Type";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(28, 125);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(218, 56);
            this.buttonCheck.TabIndex = 2;
            this.buttonCheck.Text = "Check Files";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // textBoxF1Path
            // 
            this.textBoxF1Path.Location = new System.Drawing.Point(368, 30);
            this.textBoxF1Path.Name = "textBoxF1Path";
            this.textBoxF1Path.Size = new System.Drawing.Size(400, 20);
            this.textBoxF1Path.TabIndex = 3;
            // 
            // textBoxF1Hash
            // 
            this.textBoxF1Hash.Location = new System.Drawing.Point(368, 56);
            this.textBoxF1Hash.Name = "textBoxF1Hash";
            this.textBoxF1Hash.Size = new System.Drawing.Size(400, 20);
            this.textBoxF1Hash.TabIndex = 4;
            // 
            // textBoxF2Path
            // 
            this.textBoxF2Path.Location = new System.Drawing.Point(368, 135);
            this.textBoxF2Path.Name = "textBoxF2Path";
            this.textBoxF2Path.Size = new System.Drawing.Size(400, 20);
            this.textBoxF2Path.TabIndex = 5;
            // 
            // textBoxF2Hash
            // 
            this.textBoxF2Hash.Location = new System.Drawing.Point(368, 161);
            this.textBoxF2Hash.Name = "textBoxF2Hash";
            this.textBoxF2Hash.Size = new System.Drawing.Size(400, 20);
            this.textBoxF2Hash.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "File 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "File 1 Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hash";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "File 2 Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Hash";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 225);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxF2Hash);
            this.Controls.Add(this.textBoxF2Path);
            this.Controls.Add(this.textBoxF1Hash);
            this.Controls.Add(this.textBoxF1Path);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHash);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.TextBox textBoxF1Path;
        private System.Windows.Forms.TextBox textBoxF1Hash;
        private System.Windows.Forms.TextBox textBoxF2Path;
        private System.Windows.Forms.TextBox textBoxF2Hash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

