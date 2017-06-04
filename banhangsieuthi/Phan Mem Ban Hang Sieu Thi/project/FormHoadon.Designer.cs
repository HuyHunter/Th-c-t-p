namespace project
{
    partial class FormHoadon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHoadon = new System.Windows.Forms.DataGridView();
            this.ColumMahoadon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTennhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTenkhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumGiaban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumNgaymua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTienthanhtoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHoadon);
            this.groupBox1.Location = new System.Drawing.Point(0, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 271);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DS Hóa Đơn";
            // 
            // dgvHoadon
            // 
            this.dgvHoadon.AllowUserToAddRows = false;
            this.dgvHoadon.AllowUserToDeleteRows = false;
            this.dgvHoadon.AllowUserToResizeColumns = false;
            this.dgvHoadon.AllowUserToResizeRows = false;
            this.dgvHoadon.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumMahoadon,
            this.ColumTennhanvien,
            this.ColumTenkhachhang,
            this.ColumTensanpham,
            this.ColumGiaban,
            this.ColumNgaymua,
            this.ColumTienthanhtoan});
            this.dgvHoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoadon.Location = new System.Drawing.Point(3, 18);
            this.dgvHoadon.Name = "dgvHoadon";
            this.dgvHoadon.RowHeadersVisible = false;
            this.dgvHoadon.Size = new System.Drawing.Size(851, 250);
            this.dgvHoadon.TabIndex = 0;
            // 
            // ColumMahoadon
            // 
            this.ColumMahoadon.DataPropertyName = "Mahoadon";
            this.ColumMahoadon.HeaderText = "Mã Hóa Đơn";
            this.ColumMahoadon.Name = "ColumMahoadon";
            // 
            // ColumTennhanvien
            // 
            this.ColumTennhanvien.DataPropertyName = "Tennhanvien";
            this.ColumTennhanvien.HeaderText = "Nhân Viên Bán Hàng";
            this.ColumTennhanvien.Name = "ColumTennhanvien";
            this.ColumTennhanvien.Width = 150;
            // 
            // ColumTenkhachhang
            // 
            this.ColumTenkhachhang.DataPropertyName = "Tenkhachhang";
            this.ColumTenkhachhang.HeaderText = "Tên Khách Hàng";
            this.ColumTenkhachhang.Name = "ColumTenkhachhang";
            this.ColumTenkhachhang.Width = 150;
            // 
            // ColumTensanpham
            // 
            this.ColumTensanpham.DataPropertyName = "Tensanpham";
            this.ColumTensanpham.HeaderText = "Tên Sản Phẩm";
            this.ColumTensanpham.Name = "ColumTensanpham";
            this.ColumTensanpham.Width = 150;
            // 
            // ColumGiaban
            // 
            this.ColumGiaban.DataPropertyName = "Giaban";
            this.ColumGiaban.HeaderText = "Giá Bán";
            this.ColumGiaban.Name = "ColumGiaban";
            // 
            // ColumNgaymua
            // 
            this.ColumNgaymua.DataPropertyName = "Ngaymua";
            this.ColumNgaymua.HeaderText = "Ngày Bán";
            this.ColumNgaymua.Name = "ColumNgaymua";
            // 
            // ColumTienthanhtoan
            // 
            this.ColumTienthanhtoan.DataPropertyName = "Tienthanhtoan";
            this.ColumTienthanhtoan.HeaderText = "Tiền Thanh Toán";
            this.ColumTienthanhtoan.Name = "ColumTienthanhtoan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(5, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(852, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Hóa Đơn";
            // 
            // FormHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(860, 369);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormHoadon";
            this.Text = "Danh Sách Hóa Đơn";
            this.Load += new System.EventHandler(this.FormHoadon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHoadon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumMahoadon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTennhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTenkhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumGiaban;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumNgaymua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTienthanhtoan;
    }
}