
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Digital_Design
{
    public class TestSplitText
    {
        [TestCase(" ",0)]
        [TestCase("", 0)]
        [TestCase("a b x",3)]
        [TestCase("a bx", 2)]
        [TestCase("a-b x", 3)]
        [TestCase("a[b] x", 3)]
        public void TestForSplittingTextNumberWords(string text,int count)
        {
            WorkText workText = new WorkText();
            var resault = workText.SplitText(text);
            Assert.AreEqual(resault.Count, count);
        }

        [TestCase("a b c", new[] {"a", "b", "c"})]
        [TestCase("ab c", new[] { "ab","c" })]
        [TestCase("", new string[0])]
        [TestCase(" a v", new[] { "a","v" })]
        public void NameTest(string text,string[] listWord)
        {
            WorkText workText = new WorkText();
            var resault = workText.SplitText(text);
            Assert.AreEqual(resault, listWord.ToList());
        }
    }
    public class TestGetFrequencyDictionaryWord
    {
        [Test]
        [Order(01)]
        public void ReternDictionaryOneWord()
        {
            WorkText workText = new WorkText();
            var text = "abc";
            var resault = workText.GetFrequencyDictionaryWord(text);
            var expected = new Dictionary<string, int>
            {
                { "abc",1 }
            };
            Assert.AreEqual(expected, resault,text);
        }
        [Test]
        [Order(02)]
        public void ReternDictionaryWithEmptyString ()
        {
            WorkText workText = new WorkText();
            var text = " ";
            var resault = workText.GetFrequencyDictionaryWord(text);
            var expected = new Dictionary<string, int>();
            Assert.AreEqual(expected, resault, text);
        }
        [Test]
        [Order(03)]
        public void ReternDictionaryWithNumberRepition()
        {
            WorkText workText = new WorkText();
            var text = "a a b b c c ";
            var resault = workText.GetFrequencyDictionaryWord(text);
            var expected = new Dictionary<string, int>()
            {
                {"a",2 },
                {"b",2}, 
                {"c",2},
            };
            Assert.AreEqual(expected, resault, text);
        }
        [Test]
        [Order(04)]
        public void ReternDictionaryWith_UseSeporation()
        {
            WorkText workText = new WorkText();
            var text = "a \'a\' (b). [b c- c; ";
            var resault = workText.GetFrequencyDictionaryWord(text);
            var expected = new Dictionary<string, int>()
            {
                {"a",2 },
                {"b",2},
                {"c",2},
            };
            Assert.AreEqual(expected, resault, text);
        }
    }

    public class TestSortDictionary
    {
        [Test]
        [Order(01)]
        public void TestSortEmptyDiction()
        {
            WorkText workText = new WorkText();
            var dictionary = new Dictionary<string,int>();
            var resault = workText.SortDictionary(dictionary);
            var expected = new Dictionary<string, int>();
            Assert.AreEqual(expected, resault);
        }
        [Test]
        [Order(02)]
        public void TestSortDictionar()
        {
            WorkText workText = new WorkText();
            var dictionary = new Dictionary<string, int>()
            {
                {"c",2},
                {"a",4},
                {"b",3},
            };
            var resault = workText.SortDictionary(dictionary);
            var expected = new Dictionary<string, int>()
            {
                {"a",4},
                {"b",3},
                {"c",2},
            };
            Assert.AreEqual(expected, resault);
        }
        [Test]
        [Order(03)]
        public void TestSortLexicographicallyMin()
        {
            WorkText workText = new WorkText();
            var dictionary = new Dictionary<string, int>()
            { 
                {"aaa",2},
                {"a",2},
               
                
            };
            var resault = workText.SortDictionary(dictionary);
            var expected = new Dictionary<string, int>()
            {
                {"a",2},
                {"aaa",2},
            };
            Assert.AreEqual(expected, resault);
        }
        [Test]
        [Order(04)]
        public void TestSortDictionarB()
        {
            WorkText workText = new WorkText();
            var dictionary = new Dictionary<string, int>()
            {
                {"c",12},
                {"a",34},
                {"bbb",1},
                {"bb",1},
                {"d",23},
            };
            var resault = workText.SortDictionary(dictionary);
            var expected = new Dictionary<string, int>()
            {
                {"a",34},
                {"d",23},
                {"c",12},
                {"bb",1},
                {"bbb",1},
            };
            Assert.AreEqual(expected, resault);
        }
    }
}
