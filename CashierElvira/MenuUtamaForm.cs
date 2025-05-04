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

namespace CashierElvira
{
    public partial class MenuUtamaForm : Form
    {
        public MenuUtamaForm()
        {
            InitializeComponent();
            lblNama.Text = $"Nama: {Util.user?.namauser ?? ""}";
            lblTanggal.Text = $"Tanggal: {DateTime.Now.ToString("dddd, dd/MM/yyyy", new CultureInfo("id-ID"))}";
        }

        void openForms(UserControl control)
        {
            panelUtama.Controls.Add(control);
            control.BringToFront();
            control.Dock = DockStyle.Fill;
            panelUtama.Controls.SetChildIndex(control, 0);
            lblTitle.Text = control.Tag.ToString();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }
        private void label2_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser());
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            openForms(new MasterPelanggan());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openForms(new MasterPelanggan());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            openForms(new MasterPelanggan());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(panelKiri.Width == 289)
            {
                panelKiri.Width = 83;
            } else
            {
                panelKiri.Width = 289;
            }
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            Util.user = null;
            this.Hide();
            new LoginForm().Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Util.user = null;
            this.Hide();
            new LoginForm().Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Util.user = null;
            this.Hide();
            new LoginForm().Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }
    }
}
