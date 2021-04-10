
namespace WF_002
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbSort = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvDSSV = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labelLopSH = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.showBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.cbbLopSH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbSort);
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dgvDSSV);
            this.groupBox1.Location = new System.Drawing.Point(25, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 471);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sach SV";
            // 
            // cbbSort
            // 
            this.cbbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSort.FormattingEnabled = true;
            this.cbbSort.Location = new System.Drawing.Point(588, 431);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Size = new System.Drawing.Size(173, 24);
            this.cbbSort.TabIndex = 6;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(492, 432);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 4;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(388, 432);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Del";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(273, 432);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(148, 432);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Location = new System.Drawing.Point(26, 34);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.ReadOnly = true;
            this.dgvDSSV.RowHeadersWidth = 51;
            this.dgvDSSV.RowTemplate.Height = 24;
            this.dgvDSSV.Size = new System.Drawing.Size(735, 352);
            this.dgvDSSV.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(698, -40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(252, -38);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(454, -38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(223, 22);
            this.txtSearch.TabIndex = 9;
            // 
            // labelLopSH
            // 
            this.labelLopSH.AutoSize = true;
            this.labelLopSH.Location = new System.Drawing.Point(12, -37);
            this.labelLopSH.Name = "labelLopSH";
            this.labelLopSH.Size = new System.Drawing.Size(55, 17);
            this.labelLopSH.TabIndex = 7;
            this.labelLopSH.Text = "Lop SH";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(708, 24);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 26);
            this.searchBtn.TabIndex = 10;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(262, 26);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(75, 23);
            this.showBtn.TabIndex = 11;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(464, 26);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(223, 22);
            this.searchBox.TabIndex = 9;
            // 
            // cbbLopSH
            // 
            this.cbbLopSH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLopSH.FormattingEnabled = true;
            this.cbbLopSH.Location = new System.Drawing.Point(96, 24);
            this.cbbLopSH.Name = "cbbLopSH";
            this.cbbLopSH.Size = new System.Drawing.Size(149, 24);
            this.cbbLopSH.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lop SH";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 570);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cbbLopSH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelLopSH);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labelLopSH;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox cbbLopSH;
        private System.Windows.Forms.Label label1;
    }
}

