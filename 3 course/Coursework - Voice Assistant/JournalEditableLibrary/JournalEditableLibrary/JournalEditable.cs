using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ParserAndFinderFileTSVLibrary;

namespace JournalEditableLibrary
{
    public class JournalEditable
    {
        //Добавление команды
        static public Tuple<List<List<string>>, int> FileParsedWritingList(string fileName, string str1, string str2, string str3, List<List<string>> F1, int F2)
        {
            //Запись текстовой информации в список данных файла
            switch (str1)
            {
                case "1":
                    str3 = "https://" + str3;
                    break;
                case "2":
                    break;
                case "3":
                    break;
            }
            string[] str = { str1, str2, str3 };
            
            F1 = ParserAndFinderFileTSV.FileParsedValueAdd(str, F1, F2);
            F2++;
            ParserAndFinderFileTSV.FileParsedWriting(fileName, str);
            return Tuple.Create(F1, F2);
        }

        //Замена команды
        static public List<List<string>> FileReplaceLineTSV(List<List<string>> F1, int F2, int numLine, string fileName, string[] tsvLine)
        {
            for (int i = 0; i < 3; i++)
                F1[numLine][i] = tsvLine[i]; //Изменение всей строки в списке команд                
            string temp = "";
            for (int i = 0; i < 3; i++)
                temp += F1[numLine][i] + '\t'; //Сохранение новых данных строки в tsv формат

            ParserAndFinderFileTSV.FileParsedReplaceAllReading(fileName, numLine, temp);  

            //ParserAndFinderFileTSV.FileParsedAllWriting(fileName, F1, F2);
            return F1;
        }
        

        //Удаление команды
        static public Tuple<List<List<string>>, int> FileDelLineTSV(List<List<string>> list, int tempCountList, int numLine, string fileName, string value)
        {
            try
            {
                list.Remove(list[numLine]); //Удаление в списке команд
                tempCountList--;
                ParserAndFinderFileTSV.FileParsedAllReading(fileName, value);
                return Tuple.Create(list, tempCountList);
            }
            catch(Exception)
            {
                tempCountList--;
                ParserAndFinderFileTSV.FileParsedAllReading(fileName, value);
                return Tuple.Create(list, tempCountList);
            }
        }
    }
}
