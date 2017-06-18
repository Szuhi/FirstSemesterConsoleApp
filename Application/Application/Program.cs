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
        public int DirectHandOver(int linenum, string[] lines, string firstPerson, string[] names)
        {
            int db = 1;
            int startingBracket = 0;
            int closingBracket = 0;
            char[] charBlock;
            char charTemp;
            string stringTemp = "";

            // Looking for the line starting with the name of the firstPerson
            for (int i = 0; i < linenum - 1; i++)                   
                if (firstPerson == names[i])
                    stringTemp = lines[i];

            charBlock = new char[stringTemp.Length];

            for (int j = 0; j < stringTemp.Length; j++)
                charBlock[j] = stringTemp[j];

            for (int z = 0; z < charBlock.Length; z++)
            {
                charTemp = charBlock[z];
                if (charTemp == '(')
                    startingBracket++;
                if (charTemp == ')')
                    closingBracket++;
                if ((closingBracket + 1) == startingBracket)
                    if (charTemp == ',')
                        db++;
            }

            return db;
        }

        public int ThroughHowManyPeople(int linenum, string[] lines, string firstPerson, string secondPerson, string[] names)
        {
            int db = 0;
            int index;
            string temp = "";

            for (int i = 0; i < linenum - 1; i++)
                if (firstPerson == names[i])
                    temp = lines[i];

            index = temp.IndexOf(secondPerson);

            for (int j = 0; j < index; j++)
            {
                switch (temp[j])
                {
                    case '(':
                        db++;
                        break;
                    case ')':
                        db--;
                        break;
                    default:
                        break;
                }
            }

            return db;
        }

        public int NotSending(int linenum, string[] names, string[] lines, string firstPerson)
        {
            int db;
            int l;
            char[] characters = { '(', ')', ',' };
            string temp = "";
            string[] temp2;

            for (int i = 0; i < linenum - 1; i++)
                if (firstPerson == names[i])
                    temp = lines[i];

            temp2 = temp.Split(characters);
            l = 0;

            for (int j = 0; j < temp2.Length; j++)
            {
                switch (temp2[j])
                {
                    case "":
                        break;
                    default:
                        l++;
                        break;
                }
            }

            db = ((linenum - 1) - l);

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
            int linenum = 0;
            int i = 0;
            string[] lines;
            string[] names;
            string firstPerson;
            string secondPerson;
            string temp;

            do
            {
                temp = sr.ReadLine();
                linenum++;
            } while (temp != "#");
            sr.Close();

            lines = new string[linenum];
            while (!sr2.EndOfStream)
            {
                lines[i] = sr2.ReadLine();
                i++;
            }
            sr2.Close();

            names = new string[linenum];
            names = UploadNames(names, linenum);

            Console.WriteLine("Please provide the name of the person you wish to examine: ");
            firstPerson = Console.ReadLine();
            Console.WriteLine("Please provide the name of the second person: ");
            Console.WriteLine("(If the two person does not receive the message, the outcome will be zero)");
            secondPerson = Console.ReadLine();

            methods = new Methods();

            Console.WriteLine("The provided person directly sending the message to " + methods.DirectHandOver(linenum, lines, firstPerson, names) + " other(s).");
            Console.WriteLine("The provided second person receives the message through " + methods.ThroughHowManyPeople(linenum, lines, firstPerson, secondPerson, names) + " other(s).");
            Console.WriteLine("The amount of persons not receiving the message: " + methods.NotSending(linenum, names, lines, firstPerson));
            Console.WriteLine("Push any button to export the report into a text file.");
            Console.ReadLine();



            Console.ReadLine();
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
