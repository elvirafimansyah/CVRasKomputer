namespace BukaKasir
{
    partial class MasterProduk
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numStok = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.DataGridView();
            this.bindingData = new System.Windows.Forms.BindingSource(this.components);
            this.bindingInput = new System.Windows.Forms.BindingSource(this.components);
            this.kodeprodukDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaprodukDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaprodukDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuanprodukDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlahprodukDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbldetailtransaksiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Produk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.label2.Location = new System.Drawing.Point(26, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Semua produk akan tampil disini";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kode Produk";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(362, 23);
            this.textBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nama";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingInput, "namaproduk", true));
            this.textBox2.Location = new System.Drawing.Point(29, 211);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(362, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Harga";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingInput, "hargaproduk", true));
            this.textBox3.Location = new System.Drawing.Point(29, 287);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(362, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Stok Produk";
            // 
            // numStok
            // 
            this.numStok.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingInput, "jumlahproduk", true));
            this.numStok.Location = new System.Drawing.Point(29, 366);
            this.numStok.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.numStok.Name = "numStok";
            this.numStok.Size = new System.Drawing.Size(362, 23);
            this.numStok.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingInput, "satuanproduk", true));
            this.textBox4.Location = new System.Drawing.Point(29, 442);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(362, 23);
            this.textBox4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Satuan";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(274, 487);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(2)))), ((int)(((byte)(183)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(28, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(2)))), ((int)(((byte)(183)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(151, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 44);
            this.button3.TabIndex = 9;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(457, 105);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(522, 23);
            this.txtCari.TabIndex = 11;
            this.txtCari.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCari_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Cari";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(2)))), ((int)(((byte)(183)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1001, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 44);
            this.button4.TabIndex = 13;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(1101, 95);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 44);
            this.button5.TabIndex = 12;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AutoGenerateColumns = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.table.BackgroundColor = System.Drawing.Color.White;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeprodukDataGridViewTextBoxColumn,
            this.namaprodukDataGridViewTextBoxColumn,
            this.hargaprodukDataGridViewTextBoxColumn,
            this.satuanprodukDataGridViewTextBoxColumn,
            this.jumlahprodukDataGridViewTextBoxColumn,
            this.tbldetailtransaksiDataGridViewTextBoxColumn,
            this.delete});
            this.table.DataSource = this.bindingData;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table.DefaultCellStyle = dataGridViewCellStyle1;
            this.table.GridColor = System.Drawing.Color.Gainsboro;
            this.table.Location = new System.Drawing.Point(419, 155);
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.Size = new System.Drawing.Size(772, 563);
            this.table.TabIndex = 14;
            this.table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellClick);
            this.table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.table_CellFormatting);
            // 
            // bindingData
            // 
            this.bindingData.DataSource = typeof(BukaKasir.tbl_produk);
            // 
            // bindingInput
            // 
            this.bindingInput.DataSource = typeof(BukaKasir.tbl_produk);
            // 
            // kodeprodukDataGridViewTextBoxColumn
            // 
            this.kodeprodukDataGridViewTextBoxColumn.DataPropertyName = "kodeproduk";
            this.kodeprodukDataGridViewTextBoxColumn.FillWeight = 101.2346F;
            this.kodeprodukDataGridViewTextBoxColumn.HeaderText = "Kode Produk";
            this.kodeprodukDataGridViewTextBoxColumn.Name = "kodeprodukDataGridViewTextBoxColumn";
            this.kodeprodukDataGridViewTextBoxColumn.ReadOnly = true;
            this.kodeprodukDataGridViewTextBoxColumn.Width = 123;
            // 
            // namaprodukDataGridViewTextBoxColumn
            // 
            this.namaprodukDataGridViewTextBoxColumn.DataPropertyName = "namaproduk";
            this.namaprodukDataGridViewTextBoxColumn.FillWeight = 110.5853F;
            this.namaprodukDataGridViewTextBoxColumn.HeaderText = "Nama Produk";
            this.namaprodukDataGridViewTextBoxColumn.Name = "namaprodukDataGridViewTextBoxColumn";
            this.namaprodukDataGridViewTextBoxColumn.ReadOnly = true;
            this.namaprodukDataGridViewTextBoxColumn.Width = 126;
            // 
            // hargaprodukDataGridViewTextBoxColumn
            // 
            this.hargaprodukDataGridViewTextBoxColumn.DataPropertyName = "hargaproduk";
            this.hargaprodukDataGridViewTextBoxColumn.FillWeight = 117.6896F;
            this.hargaprodukDataGridViewTextBoxColumn.HeaderText = "Harga Produk";
            this.hargaprodukDataGridViewTextBoxColumn.Name = "hargaprodukDataGridViewTextBoxColumn";
            this.hargaprodukDataGridViewTextBoxColumn.ReadOnly = true;
            this.hargaprodukDataGridViewTextBoxColumn.Width = 128;
            // 
            // satuanprodukDataGridViewTextBoxColumn
            // 
            this.satuanprodukDataGridViewTextBoxColumn.DataPropertyName = "satuanproduk";
            this.satuanprodukDataGridViewTextBoxColumn.FillWeight = 126.5487F;
            this.satuanprodukDataGridViewTextBoxColumn.HeaderText = "Satuan Produk";
            this.satuanprodukDataGridViewTextBoxColumn.Name = "satuanprodukDataGridViewTextBoxColumn";
            this.satuanprodukDataGridViewTextBoxColumn.ReadOnly = true;
            this.satuanprodukDataGridViewTextBoxColumn.Width = 133;
            // 
            // jumlahprodukDataGridViewTextBoxColumn
            // 
            this.jumlahprodukDataGridViewTextBoxColumn.DataPropertyName = "jumlahproduk";
            this.jumlahprodukDataGridViewTextBoxColumn.FillWeight = 131.137F;
            this.jumlahprodukDataGridViewTextBoxColumn.HeaderText = "Jumlah Produk";
            this.jumlahprodukDataGridViewTextBoxColumn.Name = "jumlahprodukDataGridViewTextBoxColumn";
            this.jumlahprodukDataGridViewTextBoxColumn.ReadOnly = true;
            this.jumlahprodukDataGridViewTextBoxColumn.Width = 135;
            // 
            // tbldetailtransaksiDataGridViewTextBoxColumn
            // 
            this.tbldetailtransaksiDataGridViewTextBoxColumn.DataPropertyName = "tbl_detailtransaksi";
            this.tbldetailtransaksiDataGridViewTextBoxColumn.HeaderText = "tbl_detailtransaksi";
            this.tbldetailtransaksiDataGridViewTextBoxColumn.Name = "tbldetailtransaksiDataGridViewTextBoxColumn";
            this.tbldetailtransaksiDataGridViewTextBoxColumn.ReadOnly = true;
            this.tbldetailtransaksiDataGridViewTextBoxColumn.Visible = false;
            this.tbldetailtransaksiDataGridViewTextBoxColumn.Width = 152;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delete.FillWeight = 12.80478F;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // MasterProduk
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.table);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numStok);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MasterProduk";
            this.Size = new System.Drawing.Size(1214, 773);
            this.Tag = "Master Produk";
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numStok;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.BindingSource bindingData;
        private System.Windows.Forms.BindingSource bindingInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeprodukDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaprodukDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaprodukDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuanprodukDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlahprodukDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbldetailtransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}
