using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Digital_Design
{
    public class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        { 
            WorkText workText = new WorkText();
            LoadText loadText = new LoadText();
            loadText.ShowInfo();
           
            Console.WriteLine("Читаем информацию из фаила...");
            workText.HandlingText(loadText.PathText);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Работа завершина, файл сохранен - {0}",loadText.PathText);
            
            Console.ReadLine();
        }

       
    }
    
}
