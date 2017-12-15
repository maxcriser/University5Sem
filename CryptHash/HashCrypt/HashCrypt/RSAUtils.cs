using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashCrypt
{
    class RSAUtils
    {

        public static void Keys(string publicKeyFileName, string privateKeyFileName)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamWriter publicKeyFile = null;
            StreamWriter privateKeyFile = null;

            string publicKey = "";
            string privateKey = "";

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                cspParams.Flags = CspProviderFlags.UseArchivableKey;
                cspParams.KeyNumber = (int)KeyNumber.Exchange;

                rsaProvider = new RSACryptoServiceProvider(cspParams);

                publicKey = rsaProvider.ToXmlString(false);
                publicKeyFile = File.CreateText(publicKeyFileName);
                publicKeyFile.Write(publicKey);

                privateKey = rsaProvider.ToXmlString(true);
                privateKeyFile = File.CreateText(privateKeyFileName);
                privateKeyFile.Write(privateKey);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception generating a new key pair! More info:");
            }

            finally
            {
                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }

                if (privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }
            }
        }

        public static byte[] Encrypt(string publicKeyFileName, byte[] plainBytes)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader publicKeyFile = null;
            StreamReader plainFile = null;
            FileStream encryptedFile = null;

            string publicKeyText = "";

            byte[] encryptedBytes = null;

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                publicKeyFile = File.OpenText(publicKeyFileName);
                publicKeyText = publicKeyFile.ReadToEnd();

                rsaProvider.FromXmlString(publicKeyText);

                encryptedBytes = rsaProvider.Encrypt(plainBytes, false);

                return encryptedBytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception encrypting file! More info:");
                return null;
            }
            finally
            {
                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }

                if (plainFile != null)
                {
                    plainFile.Close();
                }

                if (encryptedFile != null)
                {
                    encryptedFile.Close();
                }
            }
        }

        public static void Decrypt(string privateKeyFileName, string encryptedFileName, string plainFileName)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader privateKeyFile = null;
            FileStream encryptedFile = null;
            StreamWriter plainFile = null;

            string privateKeyText = "";
            string plainText = "";

            byte[] encryptedBytes = null;
            byte[] plainBytes = null;

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                
                rsaProvider = new RSACryptoServiceProvider(cspParams);
                
                privateKeyFile = File.OpenText(privateKeyFileName);
                privateKeyText = privateKeyFile.ReadToEnd();

                rsaProvider.FromXmlString(privateKeyText);

                encryptedFile = File.OpenRead(encryptedFileName);
                encryptedBytes = new byte[encryptedFile.Length];
                encryptedFile.Read(encryptedBytes, 0, (int)encryptedFile.Length);
                
                plainBytes = rsaProvider.Decrypt(encryptedBytes, false);
                plainFile = File.CreateText(plainFileName);
                plainText = Encoding.Unicode.GetString(plainBytes);
                plainFile.Write(plainText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception decrypting file! More info:");
            }
            finally
            {
                if (privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }

                if (encryptedFile != null)
                {
                    encryptedFile.Close();
                }

                if (plainFile != null)
                {
                    plainFile.Close();
                }

            }
        }
    }
}
