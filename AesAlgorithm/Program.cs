
using System;
using System.Net.Security;
using System.Security.Cryptography;
//using System.Runtime.Intrinsics.Arm;
using System.Text;
namespace AesAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Please enter a username: ");
        string username = Console.ReadLine();
        System.Console.WriteLine("Please enter a password : ");
        string password = Console.ReadLine();

        byte[] key = new byte[16];
        byte[] iv = new byte[16];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create()){
            random.GetBytes(key);
            random.GetBytes(iv);
        }

        byte[] en_password = AES_Algorithm.Encrypt(password, key,iv);
        string converted = Convert.ToBase64String(en_password);
        System.Console.WriteLine("encrypted password : " +converted);

        string dp_password = AES_Algorithm.Decrypt(en_password,key,iv);
        System.Console.WriteLine("Decripted password : " + dp_password );
        
    }
}
public static class AES_Algorithm{
    public static byte[] Encrypt(string text, byte[] key, byte[]iv){
        byte [] encodetext;
        using (Aes aes = Aes.Create()){
            ICryptoTransform cryptoTransform = aes.CreateEncryptor(key,iv);
            using (MemoryStream memoryStream = new MemoryStream()){
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream,cryptoTransform,CryptoStreamMode.Write)){
                    using(StreamWriter streamWriter = new StreamWriter(cryptoStream)){
                        streamWriter.Write(text);
                    }
                    //byte[] bytes = Encoding.UTF8.GetBytes(text);
                    //memoryStream.Write(bytes,0,bytes.Length);
                }
                 encodetext = memoryStream.ToArray();
            }
        }
        return encodetext;

    }
    public static string Decrypt(byte[] sciphened, byte[]key, byte[]iv){
        string decodeText = String.Empty;
        using(Aes aes = Aes.Create()){
            ICryptoTransform transform = aes.CreateDecryptor(key,iv);
            using (MemoryStream memory = new MemoryStream(sciphened)){
                using(CryptoStream crypto = new CryptoStream(memory,transform,CryptoStreamMode.Read)){
                    using(StreamReader stream = new StreamReader(crypto)){
                        //crypto.CopyTo(memory);
                        decodeText = stream.ReadToEnd();
                    }
                }
                byte[] mm = memory.ToArray();
            }
        }
        //decodeText = UTF8.Get;
        
        return decodeText;
    }
}
