using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDecodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Encoding
            string myString = "abc123";
            byte[] encodedArray = Encoding.UTF8.GetBytes(myString);

            // Decoding
            string decodedMyString = Encoding.UTF8.GetString(encodedArray);
        }
    }
}
