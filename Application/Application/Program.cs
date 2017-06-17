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
    }
}
