namespace project
{
    partial class FormKhachhang
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKhachhang = new System.Windows.Forms.DataGridView();
            this.ColumMakhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTenkhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumNgaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumGioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDiachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSodienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(229, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Khách Hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKhachhang);
            this.groupBox2.Location = new System.Drawing.Point(1, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Khách Hàng";
            // 
            // dgvKhachhang
            // 
            this.dgvKhachhang.AllowUserToAddRows = false;
            this.dgvKhachhang.AllowUserToDeleteRows = false;
            this.dgvKhachhang.AllowUserToResizeColumns = false;
            this.dgvKhachhang.AllowUserToResizeRows = false;
            this.dgvKhachhang.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvKhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumMakhachhang,
            this.ColumTenkhachhang,
            this.ColumNgaysinh,
            this.ColumGioitinh,
            this.ColumDiachi,
            this.ColumSodienthoai});
            this.dgvKhachhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachhang.Location = new System.Drawing.Point(3, 18);
            this.dgvKhachhang.Name = "dgvKhachhang";
            this.dgvKhachhang.RowHeadersVisible = false;
            this.dgvKhachhang.Size = new System.Drawing.Size(705, 195);
            this.dgvKhachhang.TabIndex = 0;
            // 
            // ColumMakhachhang
            // 
            this.ColumMakhachhang.DataPropertyName = "Makhachhang";
            this.ColumMakhachhang.HeaderText = "Mã Khách Hàng";
            this.ColumMakhachhang.Name = "ColumMakhachhang";
            // 
            // ColumTenkhachhang
            // 
            this.ColumTenkhachhang.DataPropertyName = "Tenkhachhang";
            this.ColumTenkhachhang.HeaderText = "Tên Khách Hàng";
            this.ColumTenkhachhang.Name = "ColumTenkhachhang";
            this.ColumTenkhachhang.Width = 150;
            // 
            // ColumNgaysinh
            // 
            this.ColumNgaysinh.DataPropertyName = "Ngaysinh";
            this.ColumNgaysinh.HeaderText = "Ngày Sinh";
            this.ColumNgaysinh.Name = "ColumNgaysinh";
            // 
            // ColumGioitinh
            // 
            this.ColumGioitinh.DataPropertyName = "Gioitinh";
            this.ColumGioitinh.HeaderText = "Giới Tính";
            this.ColumGioitinh.Name = "ColumGioitinh";
            // 
            // ColumDiachi
            // 
            this.ColumDiachi.DataPropertyName = "Diachi";
            this.ColumDiachi.HeaderText = "Địa Chỉ";
            this.ColumDiachi.Name = "ColumDiachi";
            this.ColumDiachi.Width = 150;
            // 
            // ColumSodienthoai
            // 
            this.ColumSodienthoai.DataPropertyName = "Sodienthoai";
            this.ColumSodienthoai.HeaderText = "Số Điện Thoại";
            this.ColumSodienthoai.Name = "ColumSodienthoai";
            // 
            // FormKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(718, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormKhachhang";
            this.Text = "Bảng Thông Tin Khách Hàng";
            this.Load += new System.EventHandler(this.FormKhachhang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumMakhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTenkhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumNgaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumGioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDiachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumSodienthoai;
    }
}