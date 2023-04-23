using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Design
{
    public class LoadText
    {
        public string PathText { get; set; }
        public string GetPathFile()
        {
           
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.DefaultExt = ".txt";
                    ofd.Filter = "(.txt)|*.txt";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        PathText = ofd.FileName;
                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return PathText;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"\t\tДобро пожаловать.\n Данная программа ищет и сортирует, по количеству повторений, уникальные слова в тексте.\n Для работы, выберете файл с расширением (.txt);");
            Thread.Sleep(1000);
            PathText = GetPathFile();
            if (PathText != null)
            {
                Console.WriteLine(" Фаил Успешно выбран.");
                Console.ForegroundColor = ConsoleColor.Green; Console.Write($"Путь к фаилу - {PathText}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
