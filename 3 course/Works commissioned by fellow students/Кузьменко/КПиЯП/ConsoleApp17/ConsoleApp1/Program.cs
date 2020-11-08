using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://www.1c.easyprog.ru");
            StreamReader sr = new StreamReader(stream, Encoding.Default);
            string newLine;
            while ((newLine = sr.ReadLine()) != null)
                Console.WriteLine(newLine);
            stream.Close();
            string hostname = "www.google.com", message = "IP адреса для домена " + hostname + "\n";
            IPHostEntry entry = Dns.GetHostEntry(hostname);
            foreach (IPAddress a in entry.AddressList)
                message += " --> " + a.ToString() + "\n";
            message += "\nАльтернативное имя домена: ";
            foreach (string aliasName in entry.Aliases)
                message += aliasName + "\n";
            message += "\nРеальное название хоста: " + entry.HostName;
            Console.WriteLine(message);
        }
    }
}
