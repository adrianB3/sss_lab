using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace rsa
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] plaintext = System.Text.Encoding.ASCII.GetBytes("hello");
            var key_size = 2048;
            RSACryptoServiceProvider myrsa1 = new RSACryptoServiceProvider(key_size);
            var paramss = myrsa1.ExportParameters(true);
            RSACryptoServiceProvider myrsa2 = new RSACryptoServiceProvider();
            myrsa2.ImportParameters(paramss);

            byte[] cyphertext = myrsa1.Encrypt(plaintext, true);
            Console.WriteLine("Plain text: " + System.Text.Encoding.Default.GetString(plaintext));
            Console.WriteLine("Cypher text RSA: " + System.Text.Encoding.Default.GetString(cyphertext));

            byte[] dec_text = myrsa2.Decrypt(cyphertext, true);
            Console.WriteLine("Dec text: " + System.Text.Encoding.Default.GetString(dec_text));
            

        }
    }
}
