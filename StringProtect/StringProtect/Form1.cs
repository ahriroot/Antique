using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringProtect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string in_text = this.richTextBoxIn.Text;
            string key_text = this.txtKey.Text;
            StrPro st = new StrPro();
            string ss = st.Encrypt(in_text, key_text);
            this.richTextBoxOut.Text = ss;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string in_text = this.richTextBoxIn.Text;
            string key_text = this.txtKey.Text;
            StrPro st = new StrPro();
            string ss = st.Decrypt(in_text, key_text);
            this.richTextBoxOut.Text = ss;
        }
    }
}
