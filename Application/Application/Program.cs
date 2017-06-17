using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Methods
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("message.txt");
            int count = 0;
            string temp;
            do
            {
                temp = sr.ReadLine();
                count++;
            } while (temp != "#");
            sr.Close();


            StreamReader sr2 = new StreamReader("message.txt");
            int i = 0;
            string[] lines = new string[count];
            while (!sr2.EndOfStream)
            {
                lines[i] = sr2.ReadLine();
                i++;
            }
            sr2.Close();
        }

        static string[] UploadNames(string[] lines, int linenum)
        {
            string[] names = new string[linenum];
            int index;

            for (int i = 0; i < linenum - 1; i++)
            {
                index = lines[i].IndexOf('(');
                if (index != -1)
                    names[i] = lines[i].Substring(0, index);
                else
                    names[i] = lines[i];
            }

            return names;
        }
    }
}
