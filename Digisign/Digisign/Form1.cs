using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Digisign
{
    public partial class Form1 : Form
    {
        public static String TXT_FILTER = "Text file(*.txt)|*.*";
        public static String XML_FILTER = "Xml file (*.xml)|*.*";
        public static String SIGNATURE_FILTER = "Signature file (*.signature)|*.*";

        RSACryptoServiceProvider mRsaProvider;

        public Form1()
        {
            InitializeComponent();
        }

        private void showKeysToastError()
        {
            Toast.show("Firstly you need to genrate private and public keys or just import");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // sign

            if (mRsaProvider != null)
            {
                OpenFileDialog openFileDialog = getDialog();
                openFileDialog.Title = "Open file for sign";
                openFileDialog.Filter = TXT_FILTER;
                
                openFileDialog.ShowDialog();

                if (openFileDialog.FileName != "")
                {
                    signFile(openFileDialog);
                }
            }
            else
            {
                showKeysToastError();
            }
        }

        private void signFile(OpenFileDialog openFileDialog)
        {
            byte[] allBytes = File.ReadAllBytes(openFileDialog.FileName);
            byte[] signData = mRsaProvider.SignData(allBytes, new SHA256CryptoServiceProvider());

            File.WriteAllBytes(openFileDialog.FileName + ".signature", signData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // verify

            if (mRsaProvider != null)
            {
                OpenFileDialog openFileDialog = getDialog();
                openFileDialog.Title = "Open file for verify";
                openFileDialog.Filter = TXT_FILTER;

                openFileDialog.ShowDialog();

                if (openFileDialog.FileName != "")
                {
                    byte[] allBytes = File.ReadAllBytes(openFileDialog.FileName);

                    openFileDialog = getDialog();
                    openFileDialog.Filter = SIGNATURE_FILTER;
                    openFileDialog.Title = "Open signature file";
                    openFileDialog.ShowDialog();

                    if (openFileDialog.FileName != "")
                    {
                        verifyFile(openFileDialog, allBytes);
                    }
                }
            }
            else
            {
                showKeysToastError();
            }
        }

        private void verifyFile(OpenFileDialog openFileDialog, byte[] allBytes)
        {
            byte[] signature = File.ReadAllBytes(openFileDialog.FileName);
            bool isEqual = mRsaProvider.VerifyData(allBytes, new SHA256CryptoServiceProvider(), signature);

            showResult(isEqual);
        }

        private void showResult(Boolean isEqual)
        {
            if (isEqual)
            {
                Toast.show("Success!!! Equal!");
            }
            else
            {
                Toast.show("Error!!! NOT equal!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // generate

            mRsaProvider = new RSACryptoServiceProvider();

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = XML_FILTER;
            saveFileDialog.Title = "Save private and public key";

            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                generatePrivateKey(saveFileDialog);
            }

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml file (*.xml)|*.*";
            saveFileDialog.Title = "Save public key";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                generatePublicKey(saveFileDialog);
            }
        }

        private void generatePublicKey(SaveFileDialog saveFileDialog)
        {
            StreamWriter o = new StreamWriter(saveFileDialog.FileName + ".xml");
            o.Write(mRsaProvider.ToXmlString(false));
            o.Close();
        }

        private void generatePrivateKey(SaveFileDialog saveFileDialog)
        {
            StreamWriter o = new StreamWriter(saveFileDialog.FileName + ".xml");
            o.Write(mRsaProvider.ToXmlString(false));
            o.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // import

            mRsaProvider = new RSACryptoServiceProvider();
            OpenFileDialog openFileDialog = getDialog();
            openFileDialog.Filter = XML_FILTER;
            openFileDialog.Title = "Open private and public key";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                importKey(openFileDialog);
            }
        }

        private void importKey(OpenFileDialog openFileDialog)
        {
            StreamReader i = new StreamReader(openFileDialog.FileName);
            mRsaProvider.FromXmlString(i.ReadToEnd());
            i.Close();
        }

        private OpenFileDialog getDialog()
        {
            return new OpenFileDialog();
        }
    }
}
