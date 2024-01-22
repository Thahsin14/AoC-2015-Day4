using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;
//lets go bruteforce 
//to be optimalized 
namespace AoC_2015_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            string input = "ckczppom";
            bool good = true;
            int count = 0;
            while (good)
            {
                using (var md5Hash = MD5.Create())
                {
                    var sourceBytes = Encoding.UTF8.GetBytes(input + count.ToString());
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    Console.WriteLine("MD5 = " + hash + "        numbers - " + count);
                    if (hash[0] == '0' && hash[1] == '0' && hash[2] == '0' && hash[3] == '0' && hash[4] == '0' && hash[5] == '0')
                    {
                        Console.WriteLine("magic numbers are: " + count);
                        good = false;
                    }
                }
                count++;
            }
            watch.Stop();
            Console.WriteLine("Execution Time: " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
