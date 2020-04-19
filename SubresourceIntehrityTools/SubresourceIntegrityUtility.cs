using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SubresourceIntehrityTools
{
    public static class SubresourceIntegrityUtility
    {
        public static string GenerateHashSha256(string text)
        {
            using var sha256 = SHA256.Create();
            var byteArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            return "sha256-" + Convert.ToBase64String(byteArray);
        }

        public static string GenerateHashSha384(string text)
        {
            using var sha384 = SHA384.Create();
            var byteArray = sha384.ComputeHash(Encoding.UTF8.GetBytes(text));

            return "sha384-" + Convert.ToBase64String(byteArray);
        }

        public static string GenerateHashSha512(string text)
        {
            using var sha512 = SHA512.Create();
            var byteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));

            return "sha512-" + Convert.ToBase64String(byteArray);
        }

        public static string GetExternalScriptText(string url, out bool isCorsHeaderPresented)
        {
            isCorsHeaderPresented = true;
            using var response = ((HttpWebRequest)WebRequest.Create(url)).GetResponse();

            if (response.Headers["Access-Control-Allow-Origin"] == null)
            {
                isCorsHeaderPresented = false;
            }

            using var streamReader = new StreamReader(response.GetResponseStream());

            return streamReader.ReadToEnd();
        }
    }
}
