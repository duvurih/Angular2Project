using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface ICrypto
    {
        string Encrypt(string toEncrypt);
        string Decrypt(string encryptedData);
    }
}
