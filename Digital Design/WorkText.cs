using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Digital_Design
{
    class WorkText
    {
        public void HandlingText(string path)
        { 
            try
            { 
                var text = ReadText(path);
                var dictionaryFrequency = GetFrequencyDictionaryWord(text);
                var resault = SortDictionary(dictionaryFrequency);
                MessageBox.Show("Обработка текста завершина.\nНажмите \"Ok\" и выбирете место для сохраниение");
                SaveResaultWork(resault);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(ex.Message);
               
            }
        }
        public string ReadText(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();
           
                using (StreamReader reader = new StreamReader(path))
                {
                    stringBuilder.Append( reader.ReadToEnd());  
                    
                }

            return stringBuilder.ToString();
        }

        public List<string> SplitText(string text)
        {
            List<string> listWord = new List<string>();
            string temp = String.Empty;
            char[] separation = new[]
            {
                '/', '‘', '…', '“', '”', '.',
                '!', '?', ';', ':', '(', ')',
                '—', '-','\'', '\"', ' ','\r', '\n',
                ',', '\\', '\t','@', '#', '$',
                '%', '^', '&', '*', '+', '=', '_',
                '1', '2', '3', '4', '5','[', ']',
                '6', '7', '8', '9', '0'  
            };
            var lines = text.Split('.', '!', '?');
            foreach (var line in lines)
            {
                var words = line.Split(separation);
                foreach (var word in words)
                {
                    if (word != "")
                        listWord.Add(word.ToLower());
                }
            }
            return listWord;
        }
           
        public Dictionary<string, int> GetFrequencyDictionaryWord(string text)
        {
            List<string> words = new List<string>();
            Dictionary<string,int> frequencyDictionaty = new Dictionary<string,int>();
            words = SplitText(text);
            foreach (var word in words)
            {
                if(frequencyDictionaty.ContainsKey(word)) frequencyDictionaty[word]++;
                else frequencyDictionaty[word] = 1;
            }
            return frequencyDictionaty;
        }

        public Dictionary<string, int> SortDictionary(Dictionary<string, int> dictionary)
        {
            Dictionary<string, int> sortDictionary= new Dictionary<string, int>();
            
            dictionary = dictionary.OrderByDescending(x=>x.Value).ThenBy(y=>y.Key).ToDictionary(x=>x.Key,x=>x.Value);
                          
            return dictionary;
        }
        public void SaveResaultWork(Dictionary<string, int> dictionary)
        {
            LoadText loadText = new LoadText();
            loadText.PathText = loadText.GetPathFile();
            using (StreamWriter streamWriter = new StreamWriter(loadText.))
            {   
                string format = "{0,-12} : {1}";
                streamWriter.WriteLine(format,"Ключ" ,"Значение");
                foreach (var item in dictionary) 
                {   
                    streamWriter.WriteLine(format, item.Key,item.Value);
                }
            }
        }
    }
}
