using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashCrypt
{
    class SignUtils
    {
        public static void sign(String pathInFile)
        {
            RSACryptoServiceProvider csp = null;

            foreach (X509Certificate2 cert in my.Certificates)

            {

                if (cert.Subject.Contains(certSubject))

                {

                    // We found it.

                    // Get its associated CSP and private key

                    csp = (RSACryptoServiceProvider)cert.PrivateKey;

                }

            }

            if (csp == null)

            {

                throw new Exception("No valid cert was found");

            }
            
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        public static Boolean verify()
        {
            return true;
        }
    }
}
