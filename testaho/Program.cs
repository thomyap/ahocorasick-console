using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
using ManagedCuda;


namespace AhoCorasickTree
{
    class Program
    {
        static CudaKernel addWithCuda;


        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            //untuk true / false

            string[] text = "ini laptop thomas".Split(' ');

            AhoCorasick.Trie<string, bool> trie = new AhoCorasick.Trie<string, bool>();
            trie.Add(new[] { "thomasa" }, true);
            trie.Build();

            /*
            string[] masuk = "one two three four".Split(' ');

            AhoCorasick.Trie<string, bool> trie = new AhoCorasick.Trie<string, bool>();

            string text = System.IO.File.ReadAllText(@"C:\Users\Thomas Yap\Documents\CUDA Examples\testaho\lorem 1000words.txt");
            
            trie.Build();
            */
            Console.WriteLine(trie.Find(text).Any());
            

            sw.Stop();

            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.ReadKey();


        }
    }
}
