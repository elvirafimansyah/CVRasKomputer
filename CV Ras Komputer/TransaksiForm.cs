using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Ras_Komputer
{
    public partial class TransaksiForm : UserControl
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        MenuUtama form;
        int op = -1;
        decimal publicTotal = 0;
        decimal publicKembalian = 0;
        public TransaksiForm(MenuUtama form)
        {
            InitializeComponent();
            this.form = form;
            loadCustomer();
            loadProduk();
            txtTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNamaU.Text = Util.user?.namauser ?? "";
            timer1.Start();
            generateKode();
            loadTotal();
            loadKembalian();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form.openForms(new DashboardForm());
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
        void loadCustomer()
        {
            var query = db.tbl_customer.OrderBy(x => x.namacustomer).ToList();
            comboBox1.DataSource = query;
            comboBox1.DisplayMember= "namacustomer";
            comboBox1.ValueMember= "namacustomer";
            comboBox1.SelectedIndex= -1;
        }
        void loadProduk()
        {
            var query = db.tbl_produk.OrderBy(x => x.namaproduk).ToList();
            comboBox2.DataSource = query;
            comboBox2.DisplayMember = "namaproduk";
            comboBox2.ValueMember = "namaproduk";
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem is tbl_customer a)
            {
                textBox2.Text = a.nohpcustomer;
                textBox3.Text = a.alamatcustomer;
            } else
            {
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is tbl_produk a)
            {
                txtHarga.Text = a.hargaproduk.ToString();
            }
            else
            {
                txtHarga.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtJam.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == -1)
            {
                Util.Error("Harap pilih barang");
                return;
            }

            if(numJUmlah.Value < 1)
            {
                Util.Error("Minimal jumlah adalah 1");
                return;
            }

            if(comboBox2.SelectedItem is tbl_produk a)
            {
                if(numJUmlah.Value > a.jumlahproduk)
                {
                    Util.Error($"Stok barang tidak mencukupi, stok produk {a.jumlahproduk}");
                    return;
                }

                int produkIndex = -1;
                foreach(DataGridViewRow dr in table.Rows)
                {
                    var kode = dr.Cells["kode"].Value;
                    if(kode != null)
                    {
                        if (kode.ToString() == a.kodeproduk)
                        {
                            produkIndex = dr.Index;
                        }
                    }
                }

                if(produkIndex != -1)
                {
                    var qtyCell = table.Rows[produkIndex].Cells["Qty"];
                    var subtotalCell = table.Rows[produkIndex].Cells["subtotal"];

                    decimal newQty = numJUmlah.Value + decimal.Parse(qtyCell.Value.ToString());

                    if(newQty > 0)
                    {
                        if(newQty > a.jumlahproduk)
                        {
                            Util.Error($"Stok barang tidak mencukupi, stok produk {a.jumlahproduk}");
                            return;
                        }
                    }

                    qtyCell.Value = newQty;
                    subtotalCell.Value = newQty * a.hargaproduk;
                } else
                {
                    int no = table.RowCount + 1;
                    table.Rows.Add(no, a.kodeproduk, a.namaproduk, a.hargaproduk, numJUmlah.Value, numJUmlah.Value * a.hargaproduk);
                }

                comboBox2.SelectedIndex = -1;
                numJUmlah.Value = 0;
                loadTotal();
                loadKembalian();
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 )
            {
                if(e.ColumnIndex == delete.Index)
                {
                    table.Rows.RemoveAt(e.RowIndex);
                    loadTotal();
                    updateNo();
                    loadKembalian();
                }
            }
        }
        void updateNo()
        {
            foreach (DataGridViewRow dr in table.Rows)
            {
                var no = dr.Cells["no"];
                if (no != null)
                {
                    no.Value = dr.Index + 1;
                }
            }
        }

        void loadTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow dr in table.Rows)
            {
                var subtotalCell = dr.Cells["subtotal"];
                if(subtotalCell != null)
                {
                    total += decimal.Parse(subtotalCell.Value.ToString());
                }
            }

            publicTotal = total;
            lblTotal.Text = total.ToString("N0", new CultureInfo("id-Id"));
        }

        void loadKembalian()
        {
            decimal kembalian = 0;
            if(decimal.TryParse(txtDibayar.Text, out decimal dibayar))
            {
                if(publicTotal > 0)
                {
                    kembalian = dibayar - publicTotal;
                }
            }

            publicKembalian = kembalian;
            lblKembalian.Text = kembalian.ToString("N0", new CultureInfo("id-Id"));
        }

        private void txtDibayar_TextChanged(object sender, EventArgs e)
        {
            loadKembalian();
            loadTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                Util.Error("Harap pilih pelanggan");
                return;
            }

            if(table.Rows.Count < 1)
            {
                Util.Error("Harap isi data barang");
                return;
            }

            if(txtDibayar.Text == "0" || txtDibayar.Text == "")
            {
                Util.Error("Harap isi input bayar");
                return;
            }

            if(lblKembalian.Text.Contains("-"))
            {
                Util.Error("Nominal dibayar tidak mencukupi biaya total");
                return;
            }

            if(Util.Confirm("Yakin ingin menmabah transaksi?") == DialogResult.Yes)
            {
                var transaksi = new tbl_transaksi()
                {
                    kodetransaksi = textBox1.Text,
                    tanggal = DateTime.Now.Date,
                    namacustomer = comboBox1.Text,
                    dibayar = decimal.Parse(txtDibayar.Text),
                    kembalian = publicKembalian,
                };

                db.tbl_transaksi.Add(transaksi);

                foreach(DataGridViewRow dr in table.Rows)
                {
                    var kode = dr.Cells["kode"].Value;
                    var produk = db.tbl_produk.Find(kode.ToString());
                    if(produk != null)
                    {
                        var detail = new tbl_detailtransaksi()
                        {
                            kodetransaksi = transaksi.kodetransaksi,
                            namaproduk = produk.namaproduk,
                            namacustomer = transaksi.namacustomer,
                            harga = produk.hargaproduk,
                            qty = decimal.Parse(dr.Cells["Qty"].Value.ToString()),
                            grandtotal = decimal.Parse(dr.Cells["subtotal"].Value.ToString())
                        };

                        produk.jumlahproduk = produk.jumlahproduk - decimal.Parse(dr.Cells["Qty"].Value.ToString());

                        db.tbl_detailtransaksi.Add(detail);
                    }
                } 

                if(db.SaveChanges() > 0)
                {
                    Util.Success("Berhasil menambah transaksi");
                    resetState();
                    new CetakStrukPembelianForm()
                    {
                        transaksi = transaksi
                    }.ShowDialog();
                    return;
                } else
                {
                    Util.Error("Gagal menambah transaksi");
                }
            }
        }

        void resetState()
        {
            generateKode();
            publicKembalian = 0;
            publicTotal= 0;
            loadTotal();
            loadKembalian();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            table.Rows.Clear();
            txtDibayar.Clear();
        }

        private void txtDibayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
