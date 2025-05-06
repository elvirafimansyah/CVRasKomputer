using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Ras_Komputer
{
    public partial class MenuUtama : Form
    {
        public MenuUtama()
        {
            InitializeComponent();

            lblNama.Text =$"Nama: {Util.user?.namauser ?? ""}" ;
            timer1.Start();
            openForms(new DashboardForm());
            
        }
        public void openForms(UserControl control)
        {
            panelUtama.Controls.Add(control);
            control.BringToFront();
            control.Dock = DockStyle.Fill;
            panelUtama.Controls.SetChildIndex(control, 0);
            lblTitle.Text = control.Tag != null ? control.Tag.ToString() : "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTanggal.Text = $"Tanggal: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}" ;
        }

        void logout()
        {
            Util.user = null;
            new LoginForm().Show();
            this.Close();
        }
        private void panel8_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser(this));
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            openForms(new MasterCustomer(this));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser(this));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            openForms(new MasterUser(this));
        }

        private void label4_Click(object sender, EventArgs e)
        {
            openForms(new MasterCustomer(this));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            openForms(new MasterCustomer(this));
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk(this));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk(this));
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openForms(new MasterProduk(this));
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm(this));
        }

        private void label6_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm(this));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            openForms(new TransaksiForm(this));
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openForms(new DashboardForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(panelKiri.Width == 289)
            {
                panelKiri.Width = 71;
            } else
            {
                panelKiri.Width = 289;
            }
        }
    }
}
