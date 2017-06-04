namespace ThuctapNhom
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnnhanvien = new System.Windows.Forms.Button();
            this.btnphongban = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lbltenandloai = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnnhanvien
            // 
            this.btnnhanvien.Location = new System.Drawing.Point(12, 12);
            this.btnnhanvien.Name = "btnnhanvien";
            this.btnnhanvien.Size = new System.Drawing.Size(100, 39);
            this.btnnhanvien.TabIndex = 0;
            this.btnnhanvien.Text = "&Nhân Viên";
            this.btnnhanvien.UseVisualStyleBackColor = true;
            this.btnnhanvien.Click += new System.EventHandler(this.btnnhanvien_Click);
            // 
            // btnphongban
            // 
            this.btnphongban.Location = new System.Drawing.Point(12, 83);
            this.btnphongban.Name = "btnphongban";
            this.btnphongban.Size = new System.Drawing.Size(100, 40);
            this.btnphongban.TabIndex = 1;
            this.btnphongban.Text = "&Phòng Ban";
            this.btnphongban.UseVisualStyleBackColor = true;
            this.btnphongban.Click += new System.EventHandler(this.btnphongban_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(15, 154);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(97, 42);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "&Trợ Giúp";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lbltenandloai
            // 
            this.lbltenandloai.AutoSize = true;
            this.lbltenandloai.Location = new System.Drawing.Point(12, 356);
            this.lbltenandloai.Name = "lbltenandloai";
            this.lbltenandloai.Size = new System.Drawing.Size(0, 13);
            this.lbltenandloai.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(118, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(592, 34);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "             CHƯƠNG TRÌNH QUẢN LÍ NHÂN SỰ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(746, 398);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbltenandloai);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnphongban);
            this.Controls.Add(this.btnnhanvien);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnhanvien;
        private System.Windows.Forms.Button btnphongban;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lbltenandloai;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}