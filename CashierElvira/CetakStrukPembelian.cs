using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierElvira
{
    public partial class CetakStrukPembelian : Form
    {
        CashierElviraEntities db = new CashierElviraEntities();
        public tbl_transaksi transaksi;
        public CetakStrukPembelian()
        {
            InitializeComponent();
        }

        private void CetakStrukPembelian_Load(object sender, EventArgs e)
        {
            var transaksiDetail = transaksi.tbl_detailtransaksi;
            StrukPembelianReport11.SetDataSource(transaksiDetail);
            StrukPembelianReport11.SetParameterValue("kodetransaksi", transaksi.kodetransaksi);
            StrukPembelianReport11.SetParameterValue("namaadmin", Util.user.namauser);
            StrukPembelianReport11.SetParameterValue("total", transaksi.total);
            StrukPembelianReport11.SetParameterValue("kembalian", transaksi.kembalian);
            StrukPembelianReport11.SetParameterValue("dibayar", transaksi.dibayar);
            crystalReportViewer1.ReportSource = StrukPembelianReport11;
        }
    }
}
