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

namespace CashierElvira
{
    public partial class MasterPelanggan : UserControl
    {
        CashierElviraEntities db = new CashierElviraEntities();
        int op = -1;

        public MasterPelanggan()
        {
            InitializeComponent();
            loadData();
            generateKode();
            bindingInput.Clear();
            bindingInput.AddNew();
        }
        void loadData()
        {
            bindingData.Clear();
            var query = db.tbl_pelanggan.OrderBy(x => x.namapelanggan).ToList();
            if (txtCari.Text != "")
            {
                query = query.Where(x => x.kodepelanggan.ToLower().Contains(txtCari.Text.ToLower()) || x.namapelanggan.ToLower().Contains(txtCari.Text.ToLower()) || x.nohppelanggan.ToLower().Contains(txtCari.Text.ToLower()) || x.alamatpelanggan.ToLower().Contains(txtCari.Text.ToLower())).ToList();
            }
            bindingData.DataSource = query;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCari.Clear();
            loadData();
        }
        void generateKode()
        {
            Random random = new Random();
            int randomNumber = random.Next(10, 99);

            Random strRandom = new Random();
            const string chars = "ABDEFGHIJKLMONOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                sb.Append(chars[strRandom.Next(chars.Length)]);
            }

            textBox1.Text = sb.ToString() + randomNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }
       
            var checkKode = db.tbl_pelanggan.Where(x => x.kodepelanggan == textBox1.Text).ToList();
            if (checkKode.Count > 0)
            {
                Util.Error("Kode pelanggan telah dipakai");
                return;
            }

            if (bindingInput.Current is tbl_pelanggan a)
            {
                a.kodepelanggan = textBox1.Text;
                db.tbl_pelanggan.Add(a);
                if (Util.Confirm("Yakin mau menambah data ini?") == DialogResult.Yes)
                {
                    if (db.SaveChanges() > 0)
                    {
                        Util.Success("Berhasil menmabah data");
                        loadData();
                        resetState();
                        return;
                    }
                    else
                    {
                        Util.Error("Gagal menmabah data");
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

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && table.Rows[e.RowIndex].DataBoundItem is tbl_pelanggan a)
            {
                op = 1;
                var data = db.tbl_pelanggan.Where(x => x.kodepelanggan == a.kodepelanggan).AsNoTracking().First();
                textBox1.Text = a.kodepelanggan;
                bindingInput.DataSource = data;

                if (e.ColumnIndex == hapus.Index)
                {
                    if (Util.Confirm("Yakin mau menghapus data?") == DialogResult.Yes)
                    {
                        db.tbl_pelanggan.Remove(a);
                        if (db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil menghapus data");
                            loadData();
                            resetState();
                            return;
                        }
                        else
                        {
                            Util.Error("Gagal menghapus data, harap mengubah data");
                        }
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (op == -1)
            {
                Util.Error("Harap pilih data terlebih dahulu!");
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            if (bindingInput.Current is tbl_pelanggan a)
            {
                a.kodepelanggan = textBox1.Text;
                db.tbl_pelanggan.AddOrUpdate(a);
                if (Util.Confirm("Yakin mau mengubah data ini?") == DialogResult.Yes)
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
                        Util.Error("Gagal mengubah data");
                    }
                }
            }

        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
