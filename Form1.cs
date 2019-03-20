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

namespace SI_Lab3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ConversionHandler myConverter = new ConversionHandler();        

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            MACHandler mh = new MACHandler (comboBoxMAC.Text);
            byte [] mac = mh.ComputeMAC(myConverter.StringToByteArray(textBoxPlain1.Text), myConverter.StringToByteArray(textBoxKey.Text));
            textBoxHEX1.Text = myConverter.ByteArrayToHexString(mac);
            mac = mh.ComputeMAC(myConverter.StringToByteArray(textBoxPlain2.Text), myConverter.StringToByteArray(textBoxKey.Text));
            textBoxHEX2.Text = myConverter.ByteArrayToHexString(mac);
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (String.Compare(textBoxHEX1.Text, textBoxHEX2.Text)==0)
            {
                labelMatch.Text = "They match!    :)";
            }
            else
            {
                labelMatch.Text = "They do not match...  :(";
            }
        }

        private void buttonTime_Click(object sender, EventArgs e)
        {
            RandomNumberGenerator rnd = RandomNumberGenerator.Create();
            byte[] key = new byte[16];
            rnd.GetBytes(key);
            byte[] input = new byte[20];
            rnd.GetBytes(input);

            HMACSHA256 hmac = new HMACSHA256(key);
            SHA256Managed hash = new SHA256Managed();

            CryptoStream cs_hmac = new CryptoStream(Stream.Null, hmac, CryptoStreamMode.Write);
            CryptoStream cs_hash = new CryptoStream(Stream.Null, hash, CryptoStreamMode.Write);

            cs_hmac.Write(input, 0, input.Length);
            cs_hmac.Close();

           

            long start_time = DateTime.Now.Ticks;
            int count = 10000000;
            for (int i = 0; i < count; i++)
            {
                cs_hash.Write(input, 0, input.Length);

            }
            cs_hash.Close();
            double operation_time = (DateTime.Now.Ticks - start_time);
            operation_time = operation_time / (10 * count); // 1 tick is 100 ns, i.e., 1/10 of 1 us 
            labelTime.Text = "Time: " + operation_time.ToString() + " us"; 
        }
    }
}
