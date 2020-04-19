using System;

namespace SubresourceIntehrityTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileText = SubresourceIntegrityUtility.GetExternalScriptText("https://code.jquery.com/jquery-3.5.0.min.js", out var isCorsHeaderPresented);

            if(!isCorsHeaderPresented)
            {
                Console.WriteLine("Access-Control-Allow-Origin header does not exist in the external file. Subresource integrity cannot properly work with this script.");
            }

            Console.WriteLine(SubresourceIntegrityUtility.GenerateHashSha256(fileText));
            Console.WriteLine(SubresourceIntegrityUtility.GenerateHashSha384(fileText));
            Console.WriteLine(SubresourceIntegrityUtility.GenerateHashSha512(fileText));
        }
    }
}
