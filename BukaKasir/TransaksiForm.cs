using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BukaKasir
{
    public partial class TransaksiForm : UserControl
    {
        CashierElviraEntities db = new CashierElviraEntities();
        decimal publicTotal = 0;
        decimal publicKembalian= 0;
        public TransaksiForm()
        {
            InitializeComponent();
            generateKode();
            loadPelanggan();
            loadProduk();
            timer1.Start();
            txtTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNamaU.Text = Util.user?.namauser ?? "";
            loadTotal();
            lblKembalian.Text = publicKembalian.ToString("N0", new CultureInfo("id-ID"));
        }

        void generateKode()
        {
            Random random = new Random();
            int randomInt = random.Next(10, 99);

            Random strRandom = new Random();
            const string chars = "ABCDEFGHIJKLMONPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                sb.Append(chars[strRandom.Next(chars.Length)]);
            }

            textBox1.Text = sb.ToString() + randomInt.ToString();
        }

        void loadPelanggan()
        {
            var query = db.tbl_pelanggan.ToList();
            comboBox1.DataSource = query;
            comboBox1.DisplayMember = "namapelanggan";
            comboBox1.ValueMember= "kodepelanggan";
            comboBox1.SelectedIndex= -1;
        }

        void loadProduk()
        {
            var query = db.tbl_produk.ToList();
            comboBox2.DataSource = query;
            comboBox2.DisplayMember = "namaproduk";
            comboBox2.ValueMember = "kodeproduk";
            comboBox2.SelectedIndex = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtJam.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == -1)
            {
                Util.Error("Harap pilih data produk");
                return;
            }
            if(numJumlah.Value < 1)
            {
                Util.Error("Minimal Input jumlah 1");
                return;
            }

            if(comboBox2.SelectedItem is tbl_produk a)
            {
                if(numJumlah.Value > a.jumlahproduk)
                {
                    Util.Error($"Stok produk tidak mencukupi, stok barang: {a.jumlahproduk}");
                    return;
                }

                int produkIndex = -1;
                foreach(DataGridViewRow dr in table.Rows)
                {
                    var kodeCell = dr.Cells["kode"].Value;
                    if(kodeCell != null)
                    {
                        if(kodeCell.ToString() == a.kodeproduk)
                        {
                            produkIndex = dr.Index;
                        }
                    }
                }

                if(produkIndex != -1)
                {
                    var qty = table.Rows[produkIndex].Cells["qty"];
                    var subtotal = table.Rows[produkIndex].Cells["subtotal"];

                    decimal newQty = int.Parse(qty.Value.ToString()) + numJumlah.Value;

                    if(newQty > a.jumlahproduk)
                    {
                        Util.Error($"Stok produk tidak mencukupi, stok produk: {a.jumlahproduk}");
                        return;
                    }

                    qty.Value = newQty.ToString();
                    subtotal.Value = newQty * a.hargaproduk;
                } else
                {
                    int no = table.RowCount + 1;
                    table.Rows.Add(no, a.kodeproduk, a.namaproduk, a.hargaproduk, numJumlah.Value, numJumlah.Value * a.hargaproduk);
                }

                numJumlah.Value = 0;
                loadTotal();
                loadKembalian();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem is tbl_pelanggan a)
            {
                txtNamaP.Text = a.namapelanggan;
                txtNo.Text = a.nohppelanggan;
                txtAlamat.Text = a.alamatpelanggan;
            }else
            {
                txtNamaP.Text = "";
                txtNo.Text = "";
                txtAlamat.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is tbl_produk a)
            {
                txtNamaB.Text = a.namaproduk;
                txtHarga.Text = a.hargaproduk.ToString();
            }
            else
            {
                txtNamaB.Text = "";
                txtHarga.Text = "";
            }
        }

        void loadTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow dr in table.Rows)
            {
                var subtotal = dr.Cells["subtotal"];
                if(subtotal != null)
                {
                    total += decimal.Parse(subtotal.Value.ToString());
                }
            }

            publicTotal = total;
            lblTotal.Text = publicTotal.ToString("N0", new CultureInfo("id-ID"));
        }

        private void txtDibayar_TextChanged(object sender, EventArgs e)
        {
            loadKembalian();
        }
        void loadKembalian()
        {
            decimal kembalian = 0;
            if (decimal.TryParse(txtDibayar.Text, out decimal dibayar))
            {
                if (publicTotal > 0)
                {
                    kembalian = dibayar - publicTotal;
                }
            }

            publicKembalian = kembalian;
            lblKembalian.Text = publicKembalian.ToString("N0", new CultureInfo("id-ID"));
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == delete.Index)
                {
                    table.Rows.RemoveAt(e.RowIndex);
                    updateNo();
                    loadTotal();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                Util.Error("Harap pilih data pelanggan");
                return;
            }
            if(table.Rows.Count < 1)
            {
                Util.Error("Harap isi data produk");
                return;
            }
            if(txtDibayar.Text == "" || txtDibayar.Text == "0") {
                Util.Error("Harap isi input bayar");
                return;
            }
            if(lblKembalian.Text.Contains("-"))
            {
                Util.Error("Nominal dibayar tidak mencukupi biaya total");
                return;
            }
            var pelanggan = comboBox1.SelectedItem as tbl_pelanggan;
            if(Util.Confirm("Yakin mau menambah transaksi?") == DialogResult.Yes)
            {
                var transaksi = new tbl_transaksi()
                {
                    kodetransaksi = textBox1.Text,
                    tanggaltransaksi = DateTime.Now.Date,
                    jam = DateTime.Now.TimeOfDay,
                    total = publicTotal,
                    kembalian = publicKembalian,
                    dibayar = decimal.Parse(txtDibayar.Text),
                    kodeuser = Util.user?.kodeuser ?? "",
                    kodepelanggan = pelanggan.kodepelanggan,
                };

                db.tbl_transaksi.Add(transaksi);

                foreach(DataGridViewRow dr in table.Rows)
                {
                    var kodeCell = dr.Cells["kode"].Value;
                    var produk = db.tbl_produk.Find(kodeCell.ToString());
                    if(produk != null)
                    {
                        var detail = new tbl_detailtransaksi()
                        {
                            kodetransaksi = transaksi.kodetransaksi,
                            kodeproduk = produk.kodeproduk,
                            namaproduk= produk.namaproduk,
                            hargadijual= produk.hargaproduk,
                            jumlahproduk= decimal.Parse(dr.Cells["qty"].Value.ToString()),
                            subtotal= decimal.Parse(dr.Cells["subtotal"].Value.ToString()),
                        };
                        produk.jumlahproduk = produk.jumlahproduk - decimal.Parse(dr.Cells["qty"].Value.ToString());
                        db.tbl_detailtransaksi.Add(detail);
                    }
                }

                if(db.SaveChanges() > 0)
                {
                    Util.Success("Berhasil menmabah transaksi");
                    resetState();
                    new CetakStrukPembelian()
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            numJumlah.Value= 0;
            table.Rows.Clear();
            publicTotal = 0;
            publicKembalian= 0;
            loadTotal();
            txtDibayar.Clear();
            loadKembalian();
            generateKode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetState();
        }
    }
}
