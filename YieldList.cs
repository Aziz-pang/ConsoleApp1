using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp
{
    internal class YieldList
    {
        public static void MainRun()
        {
            foreach(string s in Test())
            {
                Console.WriteLine(s);
            }
        }
        public static async void MainRunForIAsyncEnumerable()
        {
            await foreach(string s in SaySomething())
            {
                Console.WriteLine(s);
            }
        }

        static IEnumerable<string> Test()
        {
            yield return "hello";
            yield return "world";
        }

        static async IAsyncEnumerable<string> SaySomething()
        {
            yield return "hello";
            yield return "world";
        }
    }
}
