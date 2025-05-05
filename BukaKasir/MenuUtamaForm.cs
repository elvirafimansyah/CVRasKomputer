using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BukaKasir
{
    public partial class MenuUtamaForm : Form
    {
        CashierElviraEntities db = new CashierElviraEntities();
        string startupPath = @"D:\Desktop Projects\BukaKasir\BukaKasir\Resources";
        public MenuUtamaForm()
        {
            InitializeComponent();
            loadInfo();
            openForms(new DashboardForm());
        }

        public void loadInfo()
        {
            lblnama.Text = $"Nama: {Util.user?.namauser ?? "-"}";
            timer1.Start();
            timer1.Interval += 100;
           
            picLogin.ImageLocation = Util.user != null ?  $@"{startupPath}\logout.png" : $@"{startupPath}\login.png";
            lblLogin.Text = Util.user != null ?  "Logout" : "Login";
            lblLogin.ForeColor = Util.user != null ? Color.Red : Color.FromArgb(35, 2, 183);

            panel2.Visible = Util.user != null ? true : false;
            panel3.Visible = Util.user != null ? true : false;
            panel4.Visible = Util.user != null ? true : false;
            panel5.Visible = Util.user != null ? true : false;
        }

        void openForms(UserControl control)
        {
            control.BringToFront();
            control.Dock = DockStyle.Fill;
            panelUtama.Controls.Add(control);
            panelUtama.Controls.SetChildIndex(control, 0);
            lblTitle.Text = control.Tag != null ? control.Tag.ToString() : "";
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk());
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser());
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            openForms(new MasterPelanggan());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openForms(new MasterPelanggan());
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm());
        }
        void login()
        {
            if(Util.user == null)
            {
                new LoginForm(this).ShowDialog();
            } else
            {
                if(Util.Confirm("Yakin mau logout akun ini") == DialogResult.Yes)
                {
                    Util.user = null;
                    loadInfo();
                } 
            }
        }
        private void panel6_Click(object sender, EventArgs e)
        {
            login();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            login();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTanggal.Text = $"Tanggal: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
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
    }
}
