using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace AOJDIASJDSAIFJAISOFJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Criptografar()
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Padding = PaddingMode.Zeros;
            byte[] key = ASCIIEncoding.ASCII.GetBytes("swqa23ue");
            byte[] iv = ASCIIEncoding.ASCII.GetBytes("1wasqw12");
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, DES.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(textBox1.Text);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        private string Descripto()
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Padding = PaddingMode.Zeros;
            byte[] key = ASCIIEncoding.ASCII.GetBytes("swqa23ue");
            byte[] iv = ASCIIEncoding.ASCII.GetBytes("1wasqw12");
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(textBox2.Text));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, DES.CreateDecryptor(key, iv), CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            textBox2.Text = Criptografar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Descripto(); 
        }
    }
     
}
