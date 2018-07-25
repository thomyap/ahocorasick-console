using System.Linq;

using NUnit.Framework;

namespace AhoCorasick
{
    public class Tests
    {
        [Test]
        public void HelloWorld()
        {
            string text = "hello and welcome to this beautiful world!";

            AhoCorasick.Trie trie = new AhoCorasick.Trie();
            trie.Add("hello");
            trie.Add("world");
            trie.Build();

            string[] matches = trie.Find(text).ToArray();

            Assert.AreEqual(2, matches.Length);
            Assert.AreEqual("hello", matches[0]);
            Assert.AreEqual("world", matches[1]);
        }

        [Test]
        public void Contains()
        {
            string text = "hello and welcome to this beautiful world!";

            AhoCorasick.Trie trie = new AhoCorasick.Trie();
            trie.Add("hello");
            trie.Add("world");
            trie.Build();

            Assert.IsTrue(trie.Find(text).Any());
        }

        [Test]
        public void LineNumbers()
        {
            string text = "world, i hello you!";
            string[] words = new[] { "hello", "world" };

            AhoCorasick.Trie<int> trie = new AhoCorasick.Trie<int>();
            for (int i = 0; i < words.Length; i++)
                trie.Add(words[i], i);
            trie.Build();

            int[] lines = trie.Find(text).ToArray();

            Assert.AreEqual(2, lines.Length);
            Assert.AreEqual(1, lines[0]);
            Assert.AreEqual(0, lines[1]);
        }

        [Test]
        public void Words()
        {
            string[] text = "one two three four".Split(' ');
            
            AhoCorasick.Trie<string, bool> trie = new AhoCorasick.Trie<string, bool>();
            trie.Add(new[] { "three", "four" }, true);
            trie.Build();

            Assert.IsTrue(trie.Find(text).Any());
        }
    }
}
