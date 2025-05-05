using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BukaKasir
{
    public partial class LoginForm : Form
    {
        CashierElviraEntities db = new CashierElviraEntities();
        MenuUtamaForm form;
        public LoginForm(MenuUtamaForm form)
        {
            InitializeComponent();
            this.form = form;
            textBox1.Text = "OV59";
            textBox2.Text = "elvira";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            } else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                Util.Error("Harap isi kode user");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Util.Error("Harap isi password");
                return;
            }

            var check = db.tbl_user.FirstOrDefault(x => x.kodeuser == textBox1.Text && x.passworduser == textBox2.Text);
            if (check == null) 
            {
                Util.Error("Kode user atau password salah");
                return;
            }

            Util.user = check;
            this.Close();
            form.loadInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
