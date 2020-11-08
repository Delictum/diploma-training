using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserAndFinderFileTSVLibrary;

namespace JournalEditableLibrary
{
    public class HistoryLogEditable
    {
        //Добавление в журнал
        static public void FileWritingHistoryLog(string fileName, string str1, string str2, string str3)
        {
            //Запись текстовой информации в список данных файла           
            string[] str = { str1, str2, str3 };
            ParserAndFinderFileTSV.FileParsedWriting(fileName, str);
        }
    }
}
