using System.IO;
using System.Security.Cryptography;


public static class MD5Helper
{
    public static string FileMD5(string filePath)
    {
      
        if (!File.Exists(filePath))
        {
            return "";
        }
        else
        {
            byte[] retVal;
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                retVal = md5.ComputeHash(file);
            }
            //x2:转化为小写的16进制 X2:大写的16进制
            return retVal.ToHex("x2");
        }
     
    }
}
