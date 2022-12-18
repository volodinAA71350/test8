using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            bool end = true;
            do
            {
                name = Console.ReadLine();

                switch (name)
                {
                    case "Help":
                        Console.WriteLine("Info -Выводит список файлов в каталоге\nCD-Переход в каталог\nDel-Удаление файла по имени\nDelM-Удаление файла по маске\nCrea-Создание файла\nCopy-Копирование файла");
                        break;
                    case "Info":
                        List<string> q = new List<string>();
                        Console.WriteLine("Введите путь каталога");
                        string p = Console.ReadLine();
                        int s = 0;
                        DirectoryInfo dir = new DirectoryInfo(p);
                        foreach (var item in dir.GetFiles())
                        {
                            q.Add(item.Name);
                            s++;
                        }
                        bool flag = true;
                        while (flag)
                        {
                            flag = false;
                            for (int k = 0; k < s - 1; ++k)
                                if (q[k].CompareTo(q[k + 1]) > 0)
                                {
                                    string buf = q[k];
                                    q[k] = q[k + 1];
                                    q[k + 1] = buf;
                                    flag = true;
                                }
                        }
                        for (int k = 0; k < s; ++k)
                            Console.WriteLine("{0} ", q[k]);
                        break;


                    case "CD":
                        string filePath = "E:\\Новая папка\\Новая папка\\Новая папка";
                        string directoryName;
                        int i = 0;

                        while (filePath != null)
                        {
                            directoryName = Path.GetDirectoryName(filePath);
                            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
                                filePath, directoryName);
                            filePath = directoryName;
                            if (i == 1)
                            {
                                filePath = directoryName + @"\";
                            }
                            i++;
                        }
                        break;

                    case "Del":
                        string DeleteThis;
                        string pyt;
                        Console.WriteLine("Введите имя");
                        DeleteThis = Console.ReadLine();
                        Console.WriteLine("Введите путь");
                        pyt = Console.ReadLine();
                        string[] Files = Directory.GetFiles(pyt);

                        foreach (string file in Files)
                        {
                            if (file.ToUpper().Contains(DeleteThis.ToUpper()))
                            {
                                File.Delete(file);
                            }
                        }
                        break;

                    case "DelM":
                        string DeleteThis1;
                        string pyt1;
                        Console.WriteLine("Введите маску");
                        DeleteThis1 = Console.ReadLine();
                        Console.WriteLine("Введите путь");
                        pyt1 = Console.ReadLine();
                        string[] files = Directory.GetFiles(pyt1, DeleteThis1);
                        Console.WriteLine("Всего файлов {0}.", files.Length);
                        foreach (string f in files)
                        {
                            Console.WriteLine(f);
                            File.Delete(f);
                        }

                        break;

                    case "Crea":
                        string pyt2;
                        Console.WriteLine("Введите путь куда создать и имя файла");
                        pyt2 = Console.ReadLine();
                        File.Create(pyt2);
                        break;

                    case "Copy":
                        Console.WriteLine("Введите путь копируемого файла");
                        string pathToFile = Console.ReadLine();
                        Console.WriteLine("Введите путь куда копировать");
                        string pathToFile1 = Console.ReadLine();
                        File.Copy(pathToFile, pathToFile1, true);
                        break;
                    case "Exit":
                        end = false;
                        break;

                 default:
                        Console.WriteLine("Введена не правильная команда");
                        break;
                }
            } while (end != false);
        }
    }
}

