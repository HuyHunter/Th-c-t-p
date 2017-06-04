namespace ThuctapNhom
{
    partial class FormThongTinPhongBan
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
            this.dvgphongban = new System.Windows.Forms.DataGridView();
            this.btnthoat = new System.Windows.Forms.Button();
            this.lbltenphongban = new System.Windows.Forms.Label();
            this.txtsoluongnv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgphongban)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgphongban
            // 
            this.dvgphongban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgphongban.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dvgphongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgphongban.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvgphongban.Location = new System.Drawing.Point(0, 152);
            this.dvgphongban.Name = "dvgphongban";
            this.dvgphongban.Size = new System.Drawing.Size(1140, 501);
            this.dvgphongban.TabIndex = 0;
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(1053, 12);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 23);
            this.btnthoat.TabIndex = 1;
            this.btnthoat.Text = "&Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // lbltenphongban
            // 
            this.lbltenphongban.AutoSize = true;
            this.lbltenphongban.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenphongban.Location = new System.Drawing.Point(29, 36);
            this.lbltenphongban.Name = "lbltenphongban";
            this.lbltenphongban.Size = new System.Drawing.Size(185, 37);
            this.lbltenphongban.TabIndex = 4;
            this.lbltenphongban.Text = "Phòng Ban";
            // 
            // txtsoluongnv
            // 
            this.txtsoluongnv.Location = new System.Drawing.Point(106, 105);
            this.txtsoluongnv.Name = "txtsoluongnv";
            this.txtsoluongnv.Size = new System.Drawing.Size(163, 20);
            this.txtsoluongnv.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Số Lượng nv";
            // 
            // FormThongTinPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1140, 653);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtsoluongnv);
            this.Controls.Add(this.lbltenphongban);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.dvgphongban);
            this.Name = "FormThongTinPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPhongBan";
            this.Load += new System.EventHandler(this.FormPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgphongban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgphongban;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label lbltenphongban;
        private System.Windows.Forms.TextBox txtsoluongnv;
        private System.Windows.Forms.Label label4;
    }
}