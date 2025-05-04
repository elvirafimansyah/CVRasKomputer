using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CashierElvira
{
    public partial class LoginForm : Form
    {
        CashierElviraEntities db = new CashierElviraEntities();
        public LoginForm()
        {
            InitializeComponent();
            textBox1.Text = "AA12";
            textBox2.Text = "admin123";
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
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                Util.Error("Harap isi semua input");
                return;
            }

            var checkUser = db.tbl_user.FirstOrDefault(x => x.kodeuser == textBox1.Text && x.passworduser == textBox2.Text);
            if(checkUser == null)
            {
                Util.Error("Kode user atau password anda salah");
                return;
            }

            this.Hide();
            Util.user = checkUser;
            new MenuUtamaForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
