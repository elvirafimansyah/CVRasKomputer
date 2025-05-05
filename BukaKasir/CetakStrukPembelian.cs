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

namespace BukaKasir
{
    public partial class CetakStrukPembelian : Form
    {
        public tbl_transaksi transaksi;
        public CetakStrukPembelian()
        {
            InitializeComponent();
        }

        private void CetakStrukPembelian_Load(object sender, EventArgs e)
        {
            var detailList = transaksi.tbl_detailtransaksi;
            strukPembelianReport1.SetDataSource(detailList);
            var namaadmin = Util.user?.namauser ?? "";
            strukPembelianReport1.SetParameterValue("namaadmin", namaadmin);
            strukPembelianReport1.SetParameterValue("namapelanggan", transaksi.tbl_pelanggan?.namapelanggan ?? "");
            strukPembelianReport1.SetParameterValue("kodetransaksi", transaksi.kodetransaksi);
            strukPembelianReport1.SetParameterValue("total", transaksi.total.ToString("N0", new CultureInfo("id-ID")));
            strukPembelianReport1.SetParameterValue("kembalian", transaksi.kembalian.ToString("N0", new CultureInfo("id-ID")));
            strukPembelianReport1.SetParameterValue("dibayar", transaksi.dibayar.ToString("N0", new CultureInfo("id-ID")));

            crystalReportViewer1.ReportSource = strukPembelianReport1;
        }
    }
}
