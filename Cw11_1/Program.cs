using System.Collections.Specialized;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Cw11_1
{
    internal class Program
    {
        static int searchWorld(string text, int index, string word, int Wordindex = 0)
        {
            int ind = index;
            int Wordind = Wordindex;
            if (text[index] == word[Wordindex])
            {
                if (Wordindex == word.Length - 1)//012345
                {                                //q wefg
                    return index;
                }
                else
                {
                    ind++;
                    Wordind++;
                    return searchWorld(text, ind, word, Wordind);
                }
            }
            return 0;
        }
        static void rechange(string pathToFile,string pathToWords) {
            string text = "";
            using (StreamReader swe = new StreamReader(pathToFile))
            {
                if (File.Exists(pathToFile)) {
                    text = swe.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            text += " ";
            string[] words;
            List<int> indexs = new List<int>();
            using (StreamReader swe = new StreamReader(pathToWords))
            {
                if (File.Exists(pathToWords))
                {
                    string texx = swe.ReadToEnd();
                    words = texx.Split(new char[] { ' ','\n','\r'},StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        Console.WriteLine(word);
                        if (word != "")
                        {
                            for (int i = 0; i < text.Length; i++)
                            {
                                int ind = searchWorld(text, i, word);
                                Console.WriteLine(ind);
                                if (ind > 0)
                                {
                                    for (int j = ind - word.Length+1; j <= ind; j++)
                                    {
                                        indexs.Add(j);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int n = 0;
            int c = 0;

            Console.WriteLine(indexs.Count);
            Console.WriteLine(text.Length);

            c = 0;
            File.Delete("1984.txt");
            using (StreamWriter swaga = new StreamWriter("1984.txt"))
            {
                if (File.Exists("1984.txt"))
                {
                    foreach (char simv in text)
                    {
                        Console.WriteLine($"I:{n}  |  C:{c}");
                        
                        if (n != 15)
                        {
                            if (c == indexs[n])
                            {
                                swaga.Write('*');
                                n++;
                                c++;
                            }
                            else
                            {
                                swaga.Write(simv);
                                c++;
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string pathToFile = "q.txt";
            string pathToWords = "w.txt";
            rechange(pathToFile, pathToWords);
            //const string d = "qwerty";
            //string x = d.Substring(2, 2);
            //Console.WriteLine(x);
            //File.Delete("test.txt");
            //File.Create("test.txt").Close();
            //if (File.Exists("test.txt"))
            //{
            //    File.WriteAllText("test.txt", "qwerty");
            //}
            //string text = File.ReadAllText("test.txt");
            //Console.WriteLine(text);


            //Directory.CreateDirectory("Fold");
            //File.Move("test.txt", "Fold/test.txt");
            //Directory.Delete("Fold", true);

            //Directory.CreateDirectory("MyFiles");
            //File.Create("MyFiles/f.txt").Close();
            //File.WriteAllText("MyFiles/f.txt", "ytrewq");
            //string[] files = Directory.GetFiles("MyFiles");
            //foreach (string file in files)
            //{
            //    Console.WriteLine(file);
            //}
            //string[] words;
            //string tex;
            //using (StreamReader swe = new StreamReader("w.txt"))
            //{
            //    tex = swe.ReadToEnd();
            //    Console.WriteLine(tex);
            //}
            //words = texx.Split(new char[] { ' ', '\n', '\r' });
            //foreach (string word in words) {
            //    if (word != "") {
            //        Console.WriteLine($"<{word}>");
            //    }
            //}
            //using (StreamWriter sw = new StreamWriter("Omega.txt"))
            //{
            //    sw.WriteLine("WW ss");
            //    sw.WriteLine("aa");
            //}
            //string xsr;
            //using (StreamReader swe = new StreamReader("Omega.txt"))
            //{
            //    string texx = swe.ReadToEnd();
            //    xsr = texx;
            //}
            //Console.Write(xsr);

            //char[] delimiters = new char[] { ' ', '\n','\r','\t'};
            //string[] pppp = xsr.Split(xsr.Where(char.IsWhiteSpace).ToArray(), StringSplitOptions.RemoveEmptyEntries);
            //string path = Console.ReadLine();
            //if (File.Exists(path))
            //{
            //    using (StreamReader swe = new StreamReader(path))
            //    {
            //        string texx = swe.ReadToEnd();
            //        Console.WriteLine(texx);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No bro");
            //}

            //while (true)
            //{
            //    Console.WriteLine("|||||||||||||||||||||||||||||||||");
            //    Console.WriteLine("| 1-create flile/dir            |");
            //    Console.WriteLine("| 2-read   flile/dir            |");
            //    Console.WriteLine("| 3-del    flile/dir            |");
            //    Console.WriteLine("| 4-move   flile/dir            |");
            //    Console.WriteLine("| 5-copy   flile/dir            |");
            //    Console.WriteLine("|||||||||||||||||||||||||||||||||");
            //    int answ;
            //    string path;
            //    string name;
            //    try
            //    {
            //        answ = int.Parse(Console.ReadLine());
            //    }
            //    catch
            //    {
            //        continue;
            //    }
            //    switch (answ)
            //    {
            //        case 1:
            //            Console.WriteLine("| path:                         |");
            //            path = Console.ReadLine();
            //            Console.WriteLine("| neme(.txt to file):           |");
            //            name = Console.ReadLine();
            //            try
            //            {
            //                using (StreamWriter sw = new StreamWriter(path + name))
            //                {
            //                }
            //            }
            //            catch
            //            {
            //                Console.WriteLine("ERROR");
            //                continue;
            //            }
            //            break;
            //        case 2:
            //            Console.WriteLine("| path:                         |");
            //            path = Console.ReadLine();
            //            if (true)
            //            {

            //            }
            //            break;
            //        case 3:
            //            break;
            //        case 4:
            //            break;
            //        case 5:
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    }
}
