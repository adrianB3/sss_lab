using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace iden_hash
{
    public partial class Form1 : Form
    {
        private ConversionHandler conversionHandler = new ConversionHandler();
        private HashAlgorithm hsh;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBoxF1Path.Text != "" && textBoxF2Path.Text != "" && comboBoxHash.Text != "")
            {
                FileStream f1 = new FileStream(textBoxF1Path.Text, FileMode.Open);
                FileStream f2 = new FileStream(textBoxF2Path.Text, FileMode.Open);

                if (comboBoxHash.Text.Equals("SHA1"))
                {
                    hsh = new SHA1CryptoServiceProvider();
                }

                if (comboBoxHash.Text.Equals("SHA256"))
                {
                    hsh = new SHA256CryptoServiceProvider();
                }

                if (comboBoxHash.Text.Equals("SHA512"))
                {
                    hsh = new SHA512CryptoServiceProvider();
                }

                var hsh1 = hsh.ComputeHash(f1);
                var hsh2 = hsh.ComputeHash(f2);

                textBoxF1Hash.Text = conversionHandler.ByteArrayToHexString(hsh1);
                textBoxF2Hash.Text = conversionHandler.ByteArrayToHexString(hsh2);

                if (textBoxF1Hash.Text.Equals(textBoxF2Hash.Text))
                {
                    MessageBox.Show("Files are identical");
                }
                else
                {
                    MessageBox.Show("Files are different");
                }

                f1.Close();
                f2.Close();

            }
        }
    }
}
