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

namespace enc_dec
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algo = TripleDES.Create();
        private HashAlgorithm hashAlgo = new SHA1CryptoServiceProvider();
        private ConversionHandler myConverter = new ConversionHandler();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if(textBoxPlain.Text != "")
            {
                algo.GenerateIV();
                algo.GenerateKey();

                byte[] enc_txt = Encrypt(myConverter.StringToByteArray(textBoxPlain.Text));
                textBoxEncText.Text = myConverter.ByteArrayToHexString(enc_txt);
                textBoxHash.Text = myConverter.ByteArrayToHexString(hashAlgo.ComputeHash(myConverter.StringToByteArray(textBoxPlain.Text)));

                textBoxDecTxt.Text = myConverter.ByteArrayToString(Decrypt(enc_txt));
            }
        }

        public byte[] Encrypt(byte[] mess)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, algo.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(mess, 0, mess.Length);
            cs.Close();
            return ms.ToArray();
        }

        public byte[] Decrypt(byte[] mess)
        {
            byte[] plaintext = new byte[mess.Length];
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms, algo.CreateDecryptor(), CryptoStreamMode.Read);
            long start_time = DateTime.Now.Ticks;
            int count = 1000000;
            for (int i = 0; i < count; i++)
            {
                cs.Read(plaintext, 0, mess.Length);
            }
            
            cs.Close();
            double op_time = (DateTime.Now.Ticks - start_time);
            op_time = op_time / (10 * count);

            labelTime.Text = op_time.ToString() + " microseconds";
            return plaintext;
        }
    }
}
