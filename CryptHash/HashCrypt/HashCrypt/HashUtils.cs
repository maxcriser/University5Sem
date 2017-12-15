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
    class HashUtils
    {
        public static byte[] getMD5Hash(String pPath)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] data = File.ReadAllBytes(pPath);
            byte[] hash = md5.ComputeHash(data);

            return hash;
        }
    }
}
