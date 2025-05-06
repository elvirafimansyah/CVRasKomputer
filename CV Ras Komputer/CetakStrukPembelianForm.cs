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
    public partial class CetakStrukPembelianForm : Form
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        public tbl_transaksi transaksi;
        public CetakStrukPembelianForm()
        {
            InitializeComponent();
        }

        private void CetakStrukPembelianForm_Load(object sender, EventArgs e)
        {
            var detailTransaksi = db.tbl_detailtransaksi.Where(x => x.kodetransaksi == transaksi.kodetransaksi).ToList();
            strukPembelianReport1.SetDataSource(detailTransaksi);
            strukPembelianReport1.SetParameterValue("namapelanggan", transaksi.namacustomer);
            strukPembelianReport1.SetParameterValue("kodeuser", Util.user?.namauser ?? "");
            strukPembelianReport1.SetParameterValue("kodetransaksi", transaksi.kodetransaksi);
            strukPembelianReport1.SetParameterValue("total", detailTransaksi.Sum(x => x.grandtotal).ToString("N0", new CultureInfo("id-ID")));
            strukPembelianReport1.SetParameterValue("dibayar", transaksi.dibayar.ToString("N0", new CultureInfo("id-ID")));
            strukPembelianReport1.SetParameterValue("kembalian", transaksi.kembalian.ToString("N0", new CultureInfo("id-ID")));

            crystalReportViewer1.ReportSource = strukPembelianReport1;
        }
    }
}
