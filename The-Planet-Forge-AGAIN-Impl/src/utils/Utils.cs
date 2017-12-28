using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.src.utils
{
    public class Utils
    {
        public static string ReadResource(string path)
        {
            string filePath = @"/" + path;
            string result = "";
            try
            {
                result = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            return result;
        }
    }
}
