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

namespace HashCrypt
{
    public partial class Form1 : Form
    {
        public static String PUBLIC_KEY_PATH = Directory.GetCurrentDirectory() + "publicKey.txt";
        public static String PRIVATE_KEY_PATH = Directory.GetCurrentDirectory() + "privateKey.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private String getFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;

            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String directory = Directory.GetCurrentDirectory();
            String path = getFile();
            byte[] hash = HashUtils.getMD5Hash(path);
            byte[] encryptedHash = RSAUtils.Encrypt(PUBLIC_KEY_PATH, hash);

            SignUtils.sign();
            writeByteArrayToFile(path + "_hash.txt", hash);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = getFile();
            writeByteArrayToFile(path + "_hash.txt", readByteArrayFromFile(path));
        }

        public static byte[] readByteArrayFromFile(String pPath)
        {
            try
            {
                return File.ReadAllBytes(pPath);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + "\n Cannot open file.");
                return null;
            }
        }

        public static void writeByteArrayToFile(string pFileName, byte[] pByteArray)
        {
            BinaryWriter bw;

            try
            {
                bw = new BinaryWriter(new FileStream(pFileName, FileMode.Create));
                bw.Write(pByteArray);
                bw.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + "\n Cannot create file.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSAUtils.Keys(PUBLIC_KEY_PATH, PRIVATE_KEY_PATH);
        }
    }
}
