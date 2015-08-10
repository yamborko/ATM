using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Security
{
    public static class CryptoHelper
    {
        private static Byte[] RSAEncrypt(String publicKey, Byte[] dataToEncrypt)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;

            Byte[] encryptedBytes = null;

            try
            {
                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Import public key
                rsaProvider.FromXmlString(publicKey);

                encryptedBytes = rsaProvider.Encrypt(dataToEncrypt, false);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                rsaProvider.Dispose();
            }

            return encryptedBytes;

        }

        // Decrypt a file
        private static Byte[] RSADecrypt(String privateKey, Byte[] dataToEncrypt)
        {
            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;

            byte[] decryptedBytes = null;

            try
            {
                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL 

                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Import private/public key pair
                rsaProvider.FromXmlString(privateKey);

                // Decrypt text
                decryptedBytes = rsaProvider.Decrypt(dataToEncrypt, false);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                rsaProvider.Dispose();
            }

            return decryptedBytes;
        }

        public static ApiObject Encrypt(String publicKey, String salt, String dataToEncrypt)
        {
            var aes = new AesManaged();
            aes.IV = Encoding.Unicode.GetBytes(salt);

            Byte[] key = aes.Key;
            Byte[] encrypted = null;

            try
            {
                var encryptor = aes.CreateEncryptor();

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(dataToEncrypt);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            } catch(Exception ex)
            {

            }
            finally
            {
                aes.Dispose();
            }

            return new ApiObject { Data = encrypted, Key =  RSAEncrypt(publicKey, key) };
        }



        public static String Decrypt(String privateKey, String salt, ApiObject request)
        {
            var aes = new AesManaged();
            aes.IV = Encoding.Unicode.GetBytes(salt);
            aes.Key = RSADecrypt(privateKey, request.Key);

            String decrypted = null;

            try
            {
                var decryptor = aes.CreateDecryptor();
                
                using (MemoryStream msDecrypt = new MemoryStream(request.Data))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                aes.Dispose();
            }

            return decrypted;
        }
    }
}
