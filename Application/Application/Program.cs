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
        public int directHandOver(int linenum, string[] lines, string firstPerson, string[] names)
        {
            int db = 1;
            int startingBracket = 0;
            int closingBracket = 0;
            string temp = "";

            // Looking for the line starting with the name of the firstPerson
            for (int i = 0; i < linenum - 1; i++)                   
                if (firstPerson == names[i])
                    temp = lines[i];
            



            return db;
        }
    }

    class Program
    {
        // We are counting that how many steps does it take to send a message from a person to another, the relationships can be found in the message.txt file

        static void Main(string[] args)
        {
            Methods methods;
            StreamReader sr = new StreamReader("message.txt");
            StreamReader sr2 = new StreamReader("message.txt");
            int count = 0;
            int i = 0;
            string[] lines;
            string[] names;
            string firstPerson;
            string secondPerson;
            string temp;

            do
            {
                temp = sr.ReadLine();
                count++;
            } while (temp != "#");
            sr.Close();

            lines = new string[count];
            while (!sr2.EndOfStream)
            {
                lines[i] = sr2.ReadLine();
                i++;
            }
            sr2.Close();

            names = new string[count];
            names = UploadNames(names, count);

            Console.WriteLine("Please provide the name of the person you wish to examine: ");
            firstPerson = Console.ReadLine();
            Console.WriteLine("Please provide the name of the second person: ");
            Console.WriteLine("(If the two person does not receive the message, the outcome will be zero)");
            secondPerson = Console.ReadLine();

            methods = new Methods();


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
