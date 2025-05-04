using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.ViewerObjectModel;

namespace CashierElvira
{
    public partial class TransaksiForm : UserControl
    {
        CashierElviraEntities db = new CashierElviraEntities();
        decimal publicTotal = 0;
        decimal publicKembalian = 0;

        public TransaksiForm()
        {
            InitializeComponent();
            loadPelanggan();
            loadProduk();
            generateKode();
           
            txtTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNama.Text = Util.user?.namauser ?? "";
            loadTotal();
            txtKembalian.Text = publicKembalian.ToString();
        }
        void loadPelanggan()
        {
            var query = db.tbl_pelanggan.OrderBy(x => x.namapelanggan).ToList();
            cbPelanggan.DataSource = query;
            cbPelanggan.DisplayMember  = "namapelanggan";
            cbPelanggan.ValueMember  = "kodepelanggan";
            cbPelanggan.SelectedIndex  = -1;
        }
        void loadProduk()
        {
            var query = db.tbl_produk.OrderBy(x => x.namaproduk).ToList();
            cbProduk.DataSource = query;
            cbProduk.DisplayMember = "namaproduk";
            cbProduk.ValueMember = "kodeproduk";
            cbProduk.SelectedIndex = -1;
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

            txtKode.Text = sb.ToString() + randomNumber.ToString();
        }

        private void cbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPelanggan.SelectedItem is tbl_pelanggan p)
            {
                txtNamaP.Text = p.namapelanggan;
                txtAlamat.Text = p.alamatpelanggan;
                txtNoHP.Text = p.nohppelanggan;
            } else
            {
                txtNamaP.Text = "";
                txtAlamat.Text = "";
                txtNoHP.Text = "";
            }
        }

        private void cbProduk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduk.SelectedItem is tbl_produk p)
            {
                txtNamaB.Text = p.namaproduk;
                txtHarga.Text = p.hargaproduk.ToString();
            }
            else
            {
                txtNamaB.Text = "";
                txtHarga.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtJam.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void TransaksiForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval += 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(numJumlah.Value < 1)
            {
                Util.Error("Jumlah barang minimal 1");
                return;
            }
            if(cbProduk.SelectedItem is tbl_produk a)
            {
                if (numJumlah.Value > a.jumlahproduk)
                {
                    Util.Error("Stok produk tidak mencukupi");
                    return;
                }

                if (Util.Confirm("Yakin mau menambah produk ini?") == DialogResult.Yes)
                {
                    int produkIndex = -1;
                    foreach (DataGridViewRow dr in table.Rows)
                    {
                        var kodeProduk = dr.Cells["kode"].Value;
                        if (kodeProduk != null)
                        {
                            if (kodeProduk.ToString() == a.kodeproduk)
                            {
                                produkIndex = dr.Index;
                            }
                        }
                    }
                    if (produkIndex != -1)
                    {
                        var qtyCell = table.Rows[produkIndex].Cells["qty"];
                        var subtotalCell = table.Rows[produkIndex].Cells["subtotal"];

                        decimal newQty = decimal.Parse(qtyCell.Value.ToString()) + numJumlah.Value;
                        if (newQty > a.jumlahproduk)
                        {
                            Util.Error("Stok produk tidak mencukupi");
                            return;
                        }

                        if (qtyCell != null && subtotalCell != null)
                        {
                            qtyCell.Value = newQty.ToString();
                            subtotalCell.Value = (newQty * a.hargaproduk).ToString();
                        }

                        numJumlah.Value = 0;
                    }
                    else
                    {
                        int no = table.RowCount + 1;
                        table.Rows.Add(no, a.kodeproduk, a.namaproduk, a.hargaproduk, numJumlah.Value, a.hargaproduk * numJumlah.Value);
                        numJumlah.Value = 0;
                    }
                    loadTotal();
                }
            } else
            {
                Util.Error("Harap pilih data barang");
                return;
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == hapus.Index)
                {
                    table.Rows.RemoveAt(e.RowIndex);
                    updateNo();
                    loadTotal();
                }
            }
        }

        void updateNo()
        {
            foreach(DataGridViewRow dr in table.Rows)
            {
                var noCell = dr.Cells["no"];
                if(noCell != null)
                {
                    noCell.Value = (dr.Index + 1).ToString();
                }
            } 
        }

        private void table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && table.Rows[e.RowIndex].DataBoundItem is tbl_produk a)
            {
                if (e.ColumnIndex == no.Index)
                {
                    e.Value = e.RowIndex + 1;
                }
            }
        }

        void loadTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow dr in table.Rows)
            {
                var subtotal = dr.Cells["subtotal"].Value;
                if (subtotal != null)
                {
                    total += decimal.Parse(subtotal.ToString());
                }
            }
            publicTotal = total;
            lblTotal.Text = publicTotal.ToString("N0");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            decimal kembalian = 0;
            if(decimal.TryParse(txtDibayar.Text, out decimal dibayar))
            {
                if(publicTotal != 0)
                {
                    kembalian = dibayar - publicTotal;
                }
            }

            publicKembalian = kembalian;
            txtKembalian.Text = publicKembalian.ToString();
        }

        private void txtDibayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbPelanggan.SelectedIndex == -1)
            {
                Util.Error("Harap pilih data pelanggan");
                return;
            }
            if(table.Rows.Count < 1)
            {
                Util.Error("Harap isi data produk");
                return;
            }
            if(txtKembalian.Text.Contains("-"))
            {
                Util.Error("Nominal dibayar tidak mencukupi biaya total");
                return;
            }
            if (txtDibayar.Text == "0" || txtDibayar.Text == "")
            {
                Util.Error("Harap isi input bayar");
                return;
            }
            var pelanggan = cbPelanggan.SelectedItem as tbl_pelanggan;
           
            if(Util.Confirm("Yakin ingin menambah transaksi?") == DialogResult.Yes)
            {
                var transaksi = new tbl_transaksi()
                {
                    kodetransaksi = txtKode.Text,
                    tanggaltransaksi = DateTime.Now.Date,
                    jam = DateTime.Now.TimeOfDay,
                    total = publicTotal,
                    kodeuser = Util.user.kodeuser,
                    kodepelanggan = pelanggan.kodepelanggan,
                    dibayar = decimal.Parse(txtDibayar.Text),
                    kembalian = publicKembalian
                };
                db.tbl_transaksi.Add(transaksi);
               
                foreach(DataGridViewRow dr in table.Rows)
                {
                    var kodeProduk = dr.Cells["kode"].Value;
                    var produk = db.tbl_produk.Find(kodeProduk.ToString());
                    if(produk != null)
                    {
                        var detail = new tbl_detailtransaksi()
                        {
                            kodetransaksi = transaksi.kodetransaksi,
                            kodeproduk = produk.kodeproduk,
                            namaproduk = produk.namaproduk,
                            hargadijual = produk.hargaproduk,
                            jumlahproduk = decimal.Parse(dr.Cells["qty"].Value.ToString()),
                            subtotal = decimal.Parse(dr.Cells["subtotal"].Value.ToString()),
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
                } else { 
                    Util.Error("Gagal menmabah transaksi");
                }
            }
        }

        void resetState()
        {
            table.Rows.Clear();
            cbPelanggan.SelectedIndex = -1;
            cbProduk.SelectedIndex = -1;
            publicTotal = 0;
            publicKembalian= 0;
            txtKembalian.Clear();
            txtDibayar.Clear();
            generateKode();
            numJumlah.Value = 0;
            loadTotal();
        }
    }
}
