using System.IO;
using System.Text;
using System.Security.Cryptography;

public class AESHelper {

    public static byte[] Encrypt(byte[] toEncryptArray, string key, byte[] ivArray) {
        byte[] keyArray = Encoding.UTF8.GetBytes(key);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.IV = ivArray;
        rDel.Mode = CipherMode.CBC;
        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateEncryptor();
        return cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    }

    public static byte[] Decrypt(byte[] toDecryptArray, string key, byte[] ivArray) {
        byte[] keyArray = Encoding.UTF8.GetBytes(key);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.IV = ivArray;
        rDel.Mode = CipherMode.CBC;
        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateDecryptor();
        return cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
    }

}
