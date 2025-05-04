using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierElvira
{
    public class Util
    {
        public static tbl_user user { get; set; }
        public static DialogResult Success(string message)
        {
            return MessageBox.Show(message, "Success - CashierElvira", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Error - CashierElvira", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Confirm(string message)
        {
            return MessageBox.Show(message, "Confirm - CashierElvira", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
