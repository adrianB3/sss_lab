using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Laboratorul2SI
{
    public partial class SymEnc : Form
    {
        ConversionHandler myConverter = new ConversionHandler();
        SymmetricAlgorithm mySymmetricAlg;
        public SymEnc()
        {
            InitializeComponent();
        }
        public void Generate(string cipher)
        {
            switch (cipher)
            {
                case "DES":
                    mySymmetricAlg = DES.Create();
                    break;
                case "3DES":
                    mySymmetricAlg = TripleDES.Create();
                    break;
                case "Rijndael":
                    mySymmetricAlg = Rijndael.Create();
                    break;
                case "AES":
                    mySymmetricAlg = Aes.Create();
                    mySymmetricAlg.Mode = CipherMode.CBC;
                    mySymmetricAlg.KeySize = 128;
                break;
            }
            mySymmetricAlg.GenerateIV();
            mySymmetricAlg.GenerateKey();
            
        }
        public byte[] Encrypt(byte[] mess, byte[] key, byte[] iv)
        {
            mySymmetricAlg.Key = key;
            mySymmetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(mess, 0, mess.Length);
            cs.Close();
            return ms.ToArray();
        }
        public byte[] Decrypt(byte[] mess, byte[] key, byte[] iv)
        {
            byte[] plaintext = new byte[mess.Length];
            mySymmetricAlg.Key = key;
            mySymmetricAlg.IV = iv;
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(plaintext, 0, mess.Length);
            cs.Close();
            return plaintext;
        }

        private void buttonEnc_Click(object sender, EventArgs e)
        {
            byte[] ciphertext = Encrypt(myConverter.StringToByteArray(textBoxPlain.Text), myConverter.HexStringToByteArray(textBoxKey.Text), myConverter.HexStringToByteArray(textBoxIV.Text));
            textBoxCipher.Text = myConverter.ByteArrayToString(ciphertext);
            textBoxCipherHex.Text = myConverter.ByteArrayToHexString(ciphertext);
            textBoxPlainHex.Text = myConverter.ByteArrayToHexString(myConverter.StringToByteArray(textBoxPlain.Text));
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            byte[] plaintext = Decrypt(myConverter.HexStringToByteArray(textBoxCipherHex.Text), myConverter.HexStringToByteArray(textBoxKey.Text), myConverter.HexStringToByteArray(textBoxIV.Text));
            textBoxPlain.Text = myConverter.ByteArrayToString(plaintext);
            textBoxPlainHex.Text = myConverter.ByteArrayToHexString(plaintext);
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            Generate(comboBoxCipher.Text);
            textBoxKey.Text = myConverter.ByteArrayToHexString(mySymmetricAlg.Key);
            textBoxIV.Text = myConverter.ByteArrayToHexString(mySymmetricAlg.IV);
        }

        private void buttonEncTime_Click(object sender, EventArgs e)
        {
            mySymmetricAlg.GenerateIV(); // generates a fresh IV
            mySymmetricAlg.GenerateKey(); // generates a fresh Key
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mySymmetricAlg.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] mes_block = new byte[8];
            long start_time = DateTime.Now.Ticks;
            int count = 10000000;
            for (int i = 0; i < count; i++)
            {
                cs.Write(mes_block, 0, mes_block.Length);
            }
            cs.Close();
            double operation_time = (DateTime.Now.Ticks - start_time);
            operation_time = operation_time / (10 * count); // 1 tick is 100 ns, i.e., 1/10 of 1 us 
            textBox1.Text = "Time for encryption of a message block: " + operation_time.ToString() + " us";
        }

        private void comboBoxCipher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEncTime_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     

    
    }
    class ConversionHandler
    {
        public byte[] StringToByteArray(string s)
        {
            return CharArrayToByteArray(s.ToCharArray());
        }
        public byte[] CharArrayToByteArray(char[] array)
        {
            return Encoding.ASCII.GetBytes(array, 0, array.Length);
        }
        public string ByteArrayToString(byte[] array)
        {
            return Encoding.ASCII.GetString(array);
        }
        public string ByteArrayToHexString(byte[] array)
        {
            string s = "";
            int i;
            for (i = 0; i < array.Length; i++)
            {
                s = s + NibbleToHexString((byte)((array[i] >> 4) &
                0x0F)) + NibbleToHexString((byte)(array[i] & 0x0F));
            }
            return s;
        }
        public byte[] HexStringToByteArray(string s)
        {
            byte[] array = new byte[s.Length / 2];
            char[] chararray = s.ToCharArray();
            int i;
            for (i = 0; i < s.Length / 2; i++)
            {
                array[i] = (byte)(((HexCharToNibble(chararray[2 * i]) << 4) & 0xF0) | ((HexCharToNibble(chararray[2* i + 1]) & 0x0F)));
            }
            return array;
        }
        public string NibbleToHexString(byte nib)
        {
            string s;
            if (nib < 10)
            {
                s = nib.ToString();
            }
            else
            {
                char c = (char)(nib + 55);
                s = c.ToString();
            }
            return s;
        }
        public byte HexCharToNibble(char c)
        {
            byte value = (byte)c;
            if (value < 65)
            {
                value = (byte)(value - 48);
            }
            else
            {
                value = (byte)(value - 55);
            }
            return value;
        }
    }
}