using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FastSearchLibrary;

namespace ParserAndFinderFileTSVLibrary
{
    public class ParserAndFinderFileTSV
    {
        //Обработка списка
        static public List<List<string>> FileParsedValueAdd(string[] tempParsedValue, List<List<string>> F3, int F4)
        {
            F3.Add(new List<string>()); //Новая строка
            for (int i = 0; i < 3; i++)
                F3[F4].Add(tempParsedValue[i]); //Запись столбцов
            return F3;
        }

        //Парсер для считывания tsv 
        static public Tuple<List<List<string>>, int> FileParsedReading(string fileName, List<List<string>> F1, int F2)
        {
            StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding(1251)); //Подключение
            string[] tempParsedValue = null;
            string readLine;
            while ((readLine = sr.ReadLine()) != null) //Пока не пустой
            {
                tempParsedValue = readLine.Split('\t'); //Разбиение на столбцы
                F1 = FileParsedValueAdd(tempParsedValue, F1, F2);
                F2++;
            }
            return Tuple.Create(F1, F2);
        }        

        //Парсер для записи tsv с проверкой на доступность файла
        static public async Task<Stream> FileParsedWriting(string fileName, string[] str)
        {
            //Запись текстовой информации в файл
            try
            {
                File.AppendAllText(fileName, Environment.NewLine, Encoding.GetEncoding(1251));
                for (int i = 0; i < 3; i++)
                    File.AppendAllText(fileName, str[i] + '\t', Encoding.GetEncoding(1251));
                return new FileStream(fileName, FileMode.Open, FileAccess.Write);
            }
            catch (IOException) //При ошибке - рекурсия с исходными данными
            {
                await Task.Delay(TimeSpan.FromSeconds(5)); //Время ожидания
                return await FileParsedWriting(fileName, str); //Рекурсия
            }
        }

        //Парсер для перезаписи tsv с проверкой на доступность файла на добавление строки
        static public async Task<Stream> FileParsedAllWriting(string fileName, string[] str)
        {
            //Запись текстовой информации в файл
            try
            {
                File.WriteAllLines(fileName, str, Encoding.GetEncoding(1251));
                return new FileStream(fileName, FileMode.Open, FileAccess.Write);
            }
            catch (IOException) //При ошибке - рекурсия с исходными данными
            {
                await Task.Delay(TimeSpan.FromSeconds(7)); //Время ожидания
                return await FileParsedAllWriting(fileName, str); //Рекурсия
            }
        }        

        //Чтение tsv с проверкой на доступность файла с вызовом для перезаписи файла на добавление строки
        static public async Task<Stream> FileParsedAllReading(string fileName, string value)
        {
            //Запись текстовой информации в файл
            try
            {
                string[] str = File.ReadAllLines(fileName, Encoding.GetEncoding(1251)).Where(s => !s.Contains(value)).ToArray();
                return await FileParsedAllWriting(fileName, str);
            }
            catch (IOException) //При ошибке - рекурсия с исходными данными
            {
                await Task.Delay(TimeSpan.FromSeconds(10)); //Время ожидания
                return await FileParsedAllReading(fileName, value); //Рекурсия
            }
        }

        //Чтение tsv с проверкой на доступность файла для перезаписи команды
        static public async Task<Stream> FileParsedReplaceAllReading(string fileName, int numLine, string temp)
        {
            //Запись текстовой информации в файл
            try
            {
                string[] str;
                using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding(1251)))
                {
                    var list = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        list.Add(line);
                        Console.WriteLine(list[list.Count - 1]);
                    }
                    str = list.ToArray();
                }
                str[numLine] = temp; //Перезапись строки
                File.WriteAllLines(fileName, str, Encoding.GetEncoding(1251));
                return new FileStream(fileName, FileMode.Open, FileAccess.Write);
            }
            catch (IOException) //При ошибке - рекурсия с исходными данными
            {
                await Task.Delay(TimeSpan.FromSeconds(10)); //Время ожидания
                return await FileParsedReplaceAllReading(fileName, numLine, temp); //Рекурсия
            }
        }
    }

    public class ParserData
    {
        //Парсер для извлечения исполняющего файла (музыкальных файлов)
        static public string ExeParsed(string exe)
        {
            int i = exe.Length - 1;
            int j = 0;
            while (exe[i] != '\\') //Нахождение начала вхождения имени файла
            {
                j++;
                i--;
            }
            char[] temp = new char[j];
            for (i++; i < exe.Length; i++) //Запись вхождения
                temp[--j] = exe[i];
            Array.Reverse(temp);
            string buf = new string(temp);
            return buf.Remove(buf.Length - 4, 4);
        }

        //Парсер для извлечения названия сайта
        static public string SiteParsed(string site)
        {
            string host = new Uri(site).Host;
            if (host.StartsWith("www."))
                host = host.Substring(4);
            return host;
        }
    }
}
