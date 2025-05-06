using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CV_Ras_Komputer
{
    public partial class MasterProduk : UserControl
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        MenuUtama form;
        int op = -1;
        public MasterProduk(MenuUtama form)
        {
            InitializeComponent();
            this.form = form;
            bindingInput.Clear();
            bindingInput.AddNew();
            loadData();
            generateKode();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            form.openForms(new DashboardForm());
        }
        void loadData()
        {
            bindingData.Clear();
            var query = db.tbl_produk.OrderBy(x => x.namaproduk).ToList();
            if (txtCari.Text != "")
            {
                query = query.Where(x => x.kodeproduk.ToLower().Contains(txtCari.Text.ToLower()) || x.namaproduk.ToLower().Contains(txtCari.Text.ToLower()) || x.hargaproduk.ToString().ToLower().Contains(txtCari.Text.ToLower()) || x.satuanproduk.ToLower().Contains(txtCari.Text.ToLower()) || x.jumlahproduk.ToString().ToLower().Contains(txtCari.Text.ToLower())).ToList();
            }

            bindingData.DataSource = query;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtCari.Clear();
            loadData();
        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        void generateKode()
        {
            Random random = new Random();
            int intRandom = random.Next(10, 99);

            Random strRandom = new Random();
            const string chars = "ABCDEFGHIJKLMONPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                sb.Append(chars[strRandom.Next(chars.Length)]);
            }

            textBox1.Text = sb.ToString() + intRandom.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            if(numJumlah.Value < 1)
            {
                Util.Error("Minimal jumlah produk 1");
                return;
            }
            if(textBox3.Text == "0" || textBox3.Text == "")
            {
                Util.Error("Harap isi input harga");
                return;
            }

            var check = db.tbl_produk.Where(x => x.kodeproduk== textBox1.Text).ToList();
            if (check.Count > 0)
            {
                Util.Error("Kode produk telah dipakai");
                return;
            }

            if (bindingInput.Current is tbl_produk a)
            {
                a.kodeproduk= textBox1.Text;
                db.tbl_produk.Add(a);
                if (op == -1)
                {
                    if (Util.Confirm("Yakin ingin menambah data ini?") == DialogResult.Yes)
                    {
                        if (db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil menambah data");
                            loadData();
                            resetState();
                            return;
                        }
                        else
                        {
                            Util.Error("Gagal menambah data");
                        }
                    }
                }
            }
        }

        void resetState()
        {
            bindingInput.Clear();
            bindingInput.AddNew();
            op = -1;
            generateKode();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && table.Rows[e.RowIndex].DataBoundItem is tbl_produk a)
            {
                op = 1;
                textBox1.Text = a.kodeproduk;
                var data = db.tbl_produk.Where(x => x.kodeproduk == a.kodeproduk).AsNoTracking().First();
                bindingInput.DataSource = data;

                if (e.ColumnIndex == delete.Index)
                {
                    if (Util.Confirm("Yakin ingin menghapus data ini?") == DialogResult.Yes)
                    {
                        db.tbl_produk.Remove(a);
                        if (db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil menghapus data");
                            loadData();
                            resetState();
                            return;
                        }
                        else
                        {
                            Util.Error("Gagal menghapus data");
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            if (numJumlah.Value < 1)
            {
                Util.Error("Minimal jumlah produk 1");
                return;
            }
            if (textBox3.Text == "0" || textBox3.Text == "")
            {
                Util.Error("Harap isi input harga");
                return;
            }

            if (bindingInput.Current is tbl_produk a)
            {
                a.kodeproduk = textBox1.Text;
                db.tbl_produk.AddOrUpdate(a);
                if (op != -1)
                {
                    if (Util.Confirm("Yakin ingin mengubah data ini?") == DialogResult.Yes)
                    {
                        if (db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil mengubah data");
                            loadData();
                            resetState();
                            return;
                        }
                        else
                        {
                            Util.Error("Gagal mengubah data, harap ubah data!");
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex >=0 && table.Rows[e.RowIndex].DataBoundItem is tbl_produk a)
            {
                if(a.jumlahproduk < 1)
                {
                    table.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    table.Rows[e.RowIndex].DefaultCellStyle.ForeColor= Color.White;
                } else
                {
                    table.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    table.Rows[e.RowIndex].DefaultCellStyle.ForeColor= Color.Black;
                }
            }
        }
    }
}
