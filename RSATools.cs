using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

class RSACryption
{
    #region RSA 加密解密
    #region RSA 的密钥产生
    /// <summary>
    /// RSA产生密钥，自己程序使用，要产生两个密钥对
    /// 一个密钥自己加密用，该私钥千万不可泄露
    /// 另外一个，用于在公开发布的程序内用
    /// </summary>
    /// <param name="xmlKeys">私钥</param>
    /// <param name="xmlPublicKey">公钥</param>
    public static void RSAKey(out string xmlKeys, out string xmlPublicKey)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            xmlKeys = rsa.ToXmlString(true);
            xmlPublicKey = rsa.ToXmlString(false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region RSA加密函数
    //############################################################################## 
    //RSA 方式加密 
    //KEY必须是XML的形式,返回的是字符串 
    //该加密方式有长度限制的！
    //############################################################################## 

    /// <summary>
    /// RSA的加密函数，加密的公钥，必须是别人的公钥！
    /// 千万不要用自己的公钥加密！
    /// </summary>
    /// <param name="xmlPublicKey">公钥</param>
    /// <param name="encryptString">待加密的字符串</param>
    /// <returns></returns>
    public static string RSAEncrypt(string xmlPrivateKey, string xmlPublicKey, string encryptString)
    {
        return RSAEncrypt(xmlPrivateKey, xmlPublicKey, Encoding.UTF8.GetBytes(encryptString));
    }

    /// <summary>
    /// RSA的加密函数，加密的公钥，必须是别人的公钥！
    /// 千万不要用自己的公钥加密！
    /// </summary>
    /// <param name="xmlPublicKey">公钥</param>
    /// <param name="EncryptString">待加密的字节数组</param>
    /// <returns></returns>
    public static string RSAEncrypt(string xmlPrivateKey, string xmlPublicKey, byte[] EncryptString)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            rsa.FromXmlString(xmlPublicKey);
            int bufferSize = (rsa.KeySize / 8) - 11;//单块最大长度
            var buffer = new byte[bufferSize];
            using (MemoryStream inputStream = new MemoryStream(EncryptString),
                    outputStream = new MemoryStream())
            {
                while (true)
                {
                    int readSize = inputStream.Read(buffer, 0, bufferSize);
                    if (readSize <= 0) break;
                    var temp = new byte[readSize];
                    Array.Copy(buffer, 0, temp, 0, readSize);
                    var encryptedBytes = rsa.Encrypt(temp, false);
                    outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                }
                return Convert.ToBase64String(outputStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// RSA的加密函数，加密的公钥，必须是别人的公钥！
    /// 千万不要用自己的公钥加密！
    /// </summary>
    /// <param name="xmlPublicKey">公钥</param>
    /// <param name="EncryptString">待加密的字节数组</param>
    /// <returns></returns>
    public static bool RSAEncrypt(string xmlPrivateKey, string xmlPublicKey, string inputFile, string outputFile)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            rsa.FromXmlString(xmlPublicKey);
            int bufferSize = (rsa.KeySize / 8) - 11;//单块最大长度
            var buffer = new byte[bufferSize];
            using (FileStream inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read),
                    outputStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write))
            {
                while (true)
                {
                    int readSize = inputStream.Read(buffer, 0, bufferSize);
                    if (readSize <= 0) break;
                    var temp = new byte[readSize];
                    Array.Copy(buffer, 0, temp, 0, readSize);
                    var encryptedBytes = rsa.Encrypt(temp, false);
                    outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    Application.DoEvents();
                }
                return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region RSA的解密函数        
    /// <summary>
    /// RSA的解密函数，解密的密钥，一定是自己的私钥
    /// </summary>
    /// <param name="xmlPrivateKey">私钥</param>
    /// <param name="decryptString">待解密的字符串</param>
    /// <returns></returns>
    public static string RSADecrypt(string xmlPrivateKey, string xmlPublicKey, string decryptString)
    {
        return RSADecrypt(xmlPrivateKey, xmlPublicKey, Convert.FromBase64String(decryptString));
    }

    /// <summary>
    /// RSA的解密函数，解密的密钥，一定是自己的私钥
    /// </summary>
    /// <param name="xmlPrivateKey">私钥</param>
    /// <param name="DecryptString">待解密的字节数组</param>
    /// <returns></returns>
    public static string RSADecrypt(string xmlPrivateKey, string xmlPublicKey, byte[] DecryptString)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            rsa.FromXmlString(xmlPrivateKey);

            int bufferSize = rsa.KeySize / 8;
            var buffer = new byte[bufferSize];

            using (MemoryStream inputStream = new MemoryStream(DecryptString),
                     outputStream = new MemoryStream())
            {
                while (true)
                {
                    int readSize = inputStream.Read(buffer, 0, bufferSize);
                    if (readSize <= 0)
                    {
                        break;
                    }

                    var temp = new byte[readSize];
                    Array.Copy(buffer, 0, temp, 0, readSize);
                    var rawBytes = rsa.Decrypt(temp, false);
                    outputStream.Write(rawBytes, 0, rawBytes.Length);
                }
                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// RSA的解密函数，解密的密钥，一定是自己的私钥
    /// </summary>
    /// <param name="xmlPrivateKey">私钥</param>
    /// <param name="DecryptString">待解密的字节数组</param>
    /// <param name="inputFile">输入文件名</param>
    /// <param name="outputFile">输出的文件名</param>
    /// <returns></returns>
    public static bool RSADecrypt(string xmlPrivateKey, string xmlPublicKey, string inputFile, string outputFile)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            rsa.FromXmlString(xmlPrivateKey);

            int bufferSize = rsa.KeySize / 8;
            var buffer = new byte[bufferSize];

            using (FileStream inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read),
                     outputStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write))
            {
                while (true)
                {
                    int readSize = inputStream.Read(buffer, 0, bufferSize);
                    if (readSize <= 0)
                    {
                        break;
                    }

                    var temp = new byte[readSize];
                    Array.Copy(buffer, 0, temp, 0, readSize);
                    var rawBytes = rsa.Decrypt(temp, false);
                    outputStream.Write(rawBytes, 0, rawBytes.Length);
                    Application.DoEvents();
                }
                return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #endregion

    #region RSA数字签名
    #region 获取Hash描述表        
    /// <summary>
    /// 获取Hash描述表
    /// </summary>
    /// <param name="strSource">待签名的字符串</param>
    /// <param name="HashData">Hash描述</param>
    /// <returns></returns>
    public static bool GetHash(string strSource, ref byte[] HashData)
    {
        try
        {
            byte[] Buffer;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(strSource);
            HashData = MD5.ComputeHash(Buffer);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 获取Hash描述表
    /// </summary>
    /// <param name="strSource">待签名的字符串</param>
    /// <param name="strHashData">Hash描述</param>
    /// <returns></returns>
    public static bool GetHash(string strSource, ref string strHashData)
    {
        try
        {
            //从字符串中取得Hash描述 
            byte[] Buffer;
            byte[] HashData;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(strSource);
            HashData = MD5.ComputeHash(Buffer);
            strHashData = Convert.ToBase64String(HashData);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 获取Hash描述表
    /// </summary>
    /// <param name="objFile">待签名的文件</param>
    /// <param name="HashData">Hash描述</param>
    /// <returns></returns>
    public static bool GetHash(System.IO.FileStream objFile, ref byte[] HashData)
    {
        try
        {
            //从文件中取得Hash描述 
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            HashData = MD5.ComputeHash(objFile);
            objFile.Close();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 获取Hash描述表
    /// </summary>
    /// <param name="objFile">待签名的文件</param>
    /// <param name="strHashData">Hash描述</param>
    /// <returns></returns>
    public static bool GetHash(System.IO.FileStream objFile, ref string strHashData)
    {
        try
        {
            //从文件中取得Hash描述 
            byte[] HashData;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            HashData = MD5.ComputeHash(objFile);
            objFile.Close();
            strHashData = Convert.ToBase64String(HashData);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region RSA签名
    /// <summary>
    /// RSA签名
    /// </summary>
    /// <param name="strKeyPrivate">私钥</param>
    /// <param name="HashbyteSignature">待签名Hash描述</param>
    /// <param name="EncryptedSignatureData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureFormatter(string strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

            RSA.FromXmlString(strKeyPrivate);
            System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter

(RSA);
            //设置签名的算法为MD5 
            RSAFormatter.SetHashAlgorithm("MD5");
            //执行签名 
            EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// RSA签名
    /// </summary>
    /// <param name="strKeyPrivate">私钥</param>
    /// <param name="HashbyteSignature">待签名Hash描述</param>
    /// <param name="m_strEncryptedSignatureData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureFormatter(string strKeyPrivate, byte[] HashbyteSignature, ref string strEncryptedSignatureData)
    {
        try
        {
            byte[] EncryptedSignatureData;
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPrivate);
            System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter

(RSA);
            //设置签名的算法为MD5 
            RSAFormatter.SetHashAlgorithm("MD5");
            //执行签名 
            EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
            strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// RSA签名
    /// </summary>
    /// <param name="strKeyPrivate">私钥</param>
    /// <param name="strHashbyteSignature">待签名Hash描述</param>
    /// <param name="EncryptedSignatureData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureFormatter(string strKeyPrivate, string strHashbyteSignature, ref byte[] EncryptedSignatureData)
    {
        try
        {
            byte[] HashbyteSignature;

            HashbyteSignature = Convert.FromBase64String(strHashbyteSignature);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

            RSA.FromXmlString(strKeyPrivate);
            System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
            //设置签名的算法为MD5 
            RSAFormatter.SetHashAlgorithm("MD5");
            //执行签名 
            EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// RSA签名
    /// </summary>
    /// <param name="strKeyPrivate">私钥</param>
    /// <param name="strHashbyteSignature">待签名Hash描述</param>
    /// <param name="strEncryptedSignatureData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureFormatter(string strKeyPrivate, string strHashbyteSignature, ref string strEncryptedSignatureData)
    {
        try
        {
            byte[] HashbyteSignature;
            byte[] EncryptedSignatureData;
            HashbyteSignature = Convert.FromBase64String(strHashbyteSignature);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPrivate);
            System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
            //设置签名的算法为MD5 
            RSAFormatter.SetHashAlgorithm("MD5");
            //执行签名 
            EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);
            strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region RSA 签名验证
    /// <summary>
    /// RSA签名验证
    /// </summary>
    /// <param name="strKeyPublic">公钥</param>
    /// <param name="HashbyteDeformatter">Hash描述</param>
    /// <param name="DeformatterData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureDeformatter(string strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData)
    {
        try
        {
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPublic);
            System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
            //指定解密的时候HASH算法为MD5 
            RSADeformatter.SetHashAlgorithm("MD5");
            if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// RSA签名验证
    /// </summary>
    /// <param name="strKeyPublic">公钥</param>
    /// <param name="strHashbyteDeformatter">Hash描述</param>
    /// <param name="DeformatterData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureDeformatter(string strKeyPublic, string strHashbyteDeformatter, byte[] DeformatterData)
    {
        try
        {
            byte[] HashbyteDeformatter;
            HashbyteDeformatter = Convert.FromBase64String(strHashbyteDeformatter);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPublic);
            System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
            //指定解密的时候HASH算法为MD5 
            RSADeformatter.SetHashAlgorithm("MD5");
            if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// RSA签名验证
    /// </summary>
    /// <param name="strKeyPublic">公钥</param>
    /// <param name="HashbyteDeformatter">Hash描述</param>
    /// <param name="strDeformatterData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureDeformatter(string strKeyPublic, byte[] HashbyteDeformatter, string strDeformatterData)
    {
        try
        {
            byte[] DeformatterData;
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPublic);
            System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
            //指定解密的时候HASH算法为MD5 
            RSADeformatter.SetHashAlgorithm("MD5");
            DeformatterData = Convert.FromBase64String(strDeformatterData);
            if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// RSA签名验证
    /// </summary>
    /// <param name="strKeyPublic">公钥</param>
    /// <param name="strHashbyteDeformatter">Hash描述</param>
    /// <param name="strDeformatterData">签名后的结果</param>
    /// <returns></returns>
    public static bool SignatureDeformatter(string strKeyPublic, string strHashbyteDeformatter, string strDeformatterData)
    {
        try
        {
            byte[] DeformatterData;
            byte[] HashbyteDeformatter;
            HashbyteDeformatter = Convert.FromBase64String(strHashbyteDeformatter);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(strKeyPublic);
            System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
            //指定解密的时候HASH算法为MD5 
            RSADeformatter.SetHashAlgorithm("MD5");
            DeformatterData = Convert.FromBase64String(strDeformatterData);
            if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #endregion
}