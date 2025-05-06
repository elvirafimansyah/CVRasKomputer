using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CV_Ras_Komputer
{
    public partial class MasterCustomer : UserControl
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        MenuUtama form;
        int op = -1;
        public MasterCustomer(MenuUtama form)
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
            var query = db.tbl_customer.OrderBy(x => x.namacustomer).ToList();
            if (txtCari.Text != "")
            {
                query = query.Where(x => x.kodecustomer.ToLower().Contains(txtCari.Text.ToLower()) || x.namacustomer.ToLower().Contains(txtCari.Text.ToLower()) || x.nohpcustomer.ToLower().Contains(txtCari.Text.ToLower()) || x.alamatcustomer.ToLower().Contains(txtCari.Text.ToLower())).ToList();
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

        private void MasterCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            
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

            if (textBox3.Text.Length < 6)
            {
                Util.Error("No telepon berupa digit (10-15 karakter)");
                return;
            }

            var check = db.tbl_customer.Where(x => x.kodecustomer == textBox1.Text).ToList();
            if (check.Count > 0)
            {
                Util.Error("Kode customer telah dipakai");
                return;
            }

            if (bindingInput.Current is tbl_customer a)
            {
                a.kodecustomer = textBox1.Text;
                db.tbl_customer.Add(a);
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

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && table.Rows[e.RowIndex].DataBoundItem is tbl_customer a)
            {
                op = 1;
                textBox1.Text = a.kodecustomer;
                var data = db.tbl_customer.Where(x => x.kodecustomer == a.kodecustomer).AsNoTracking().First();
                bindingInput.DataSource = data;

                if (e.ColumnIndex == delete.Index)
                {
                    if (Util.Confirm("Yakin ingin menghapus data ini?") == DialogResult.Yes)
                    {
                        db.tbl_customer.Remove(a);
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

            if (textBox3.Text.Length < 6)
            {
                Util.Error("No telepon berupa digit (10-15 karakter)");
                return;
            }

            if (bindingInput.Current is tbl_customer a)
            {
                a.kodecustomer = textBox1.Text;
                db.tbl_customer.AddOrUpdate(a);
                if (op != -1)
                {
                    try
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
                    } catch(DbEntityValidationException ex)
                    {
                        string message = String.Empty;
                        foreach(var validationErrors in ex.EntityValidationErrors)
                        {
                            foreach(var validationError in validationErrors.ValidationErrors)
                            {
                                message += String.Format("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }

                        Util.Error(message);
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }
    }
}
