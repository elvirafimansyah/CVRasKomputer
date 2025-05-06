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

namespace CV_Ras_Komputer
{
    public partial class MasterUser : UserControl
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        MenuUtama form;
        int op = -1;
        public MasterUser(MenuUtama form)
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
            var query = db.tbl_user.OrderBy(x => x.namauser).ToList();
            if(txtCari.Text != "")
            {
                query = query.Where(x => x.kodeuser.ToLower().Contains(txtCari.Text.ToLower()) || x.namauser.ToLower().Contains(txtCari.Text.ToLower()) || x.passworduser.ToLower().Contains(txtCari.Text.ToLower()) || x.leveluser.ToLower().Contains(txtCari.Text.ToLower())).ToList();
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
            
            for(int i =0; i < 2; i++)
            {
                sb.Append(chars[strRandom.Next(chars.Length)]);
            }

            textBox1.Text = sb.ToString() + intRandom.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            if(comboBox1.SelectedIndex == -1)
            {
                Util.Error("Harap pilih level user");
                return;
            }

            if(textBox3.Text.Length < 6)
            {
                Util.Error("Minimal jumlah password adalah 6 karakter");
                return;
            }

            var check = db.tbl_user.Where(x => x.kodeuser == textBox1.Text).ToList();
            if(check.Count > 0)
            {
                Util.Error("Kode user telah dipakai");
                return;
            }

            if(bindingInput.Current is tbl_user a)
            {
                a.kodeuser = textBox1.Text;
                db.tbl_user.Add(a);
                if(op == -1)
                {
                    if(Util.Confirm("Yakin ingin menambah data ini?") == DialogResult.Yes)
                    {
                        if(db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil menambah data");
                            loadData();
                            resetState();
                            return;
                        } else
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

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && table.Rows[e.RowIndex].DataBoundItem is tbl_user a)
            {
                op = 1;
                textBox1.Text = a.kodeuser;
                var data = db.tbl_user.Where(x => x.kodeuser == a.kodeuser).AsNoTracking().First();
                bindingInput.DataSource = data;

                if(e.ColumnIndex == delete.Index)
                {
                    if(Util.Confirm("Yakin ingin menghapus data ini?") == DialogResult.Yes)
                    {
                        db.tbl_user.Remove(a);
                        if(db.SaveChanges() > 0)
                        {
                            Util.Success("Berhasil menghapus data");
                            loadData();
                            resetState();
                            return;
                        } else
                        {
                            Util.Error("Gagal menghapus data");
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                Util.Error("Harap pilih level user");
                return;
            }

            if (textBox3.Text.Length < 6)
            {
                Util.Error("Minimal jumlah password adalah 6 karakter");
                return;
            }

            if (bindingInput.Current is tbl_user a)
            {
                a.kodeuser = textBox1.Text;
                db.tbl_user.AddOrUpdate(a);
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
            if(e.RowIndex >=0 && table.Rows[e.RowIndex].DataBoundItem is tbl_user a)
            {
                //if(e.ColumnIndex == delete.Index)
                //{
                //    table.Rows[e.RowIndex].Cells["delete"].Style.BackColor = Color.FromArgb(0, 12, 141);
                //}
            }
        }
    }
}
