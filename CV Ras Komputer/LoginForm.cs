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
    public partial class LoginForm : Form
    {
        db_raskomputerEntities db = new db_raskomputerEntities();
        public LoginForm()
        {
            InitializeComponent();
            textBox1.Text = "AA12";
            textBox2.Text = "admin";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

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
            var checkKode = db.tbl_user.FirstOrDefault(x => x.kodeuser == textBox1.Text);
            if(checkKode == null)
            {
                Util.Error("Kode user anda salah");
                return;
            }

            var checkPassword = db.tbl_user.FirstOrDefault(x => x.passworduser == textBox2.Text);
            if (checkPassword == null)
            {
                Util.Error("Password anda salah");
                return;
            }

            var check = db.tbl_user.FirstOrDefault(x => x.kodeuser == textBox1.Text && x.passworduser == textBox2.Text);
            if (check == null)
            {
                Util.Error("Kode user atau password salah");
                return;
            }

            Util.user = check;  
            this.Hide();
            new MenuUtama().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
