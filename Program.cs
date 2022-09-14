using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _8
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int
                numVal = 0,
                numVal1 = 0,
                totSuit = 0;

            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            string strPath = Environment.CurrentDirectory;
            string filenamer = Path.Combine(strPath, "xyz.txt");
            Console.WriteLine(filenamer);
            var dict = new Dictionary<string, int> { };
            using (var sr = new StreamReader(filenamer))
            {
                string line;
                List<string> scoreResults = new List<string>();
                List<string> nameResults = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        int charLocation =
                            line.IndexOf(':', StringComparison.Ordinal);
                        if (charLocation > 0)
                        {
                            string name = line.Substring(0, charLocation);
                            int intFirstCard = charLocation - 3;

                            string Card1 = line.Substring(charLocation + 1, 2);
                            List<char> Card1List = new List<char>();
                            Card1List.AddRange(Card1);

                            string Card2 = line.Substring(charLocation + 4, 2);
                            List<char> Card2List = new List<char>();
                            Card2List.AddRange(Card2);

                            string Card3 = line.Substring(charLocation + 7, 2);
                            List<char> Card3List = new List<char>();
                            Card3List.AddRange(Card3);

                            string Card4 = line.Substring(charLocation + 10, 2);
                            List<char> Card4List = new List<char>();
                            Card4List.AddRange(Card4);

                            string Card5 = line.Substring(charLocation + 13, 2);
                            List<char> Card5List = new List<char>();
                            Card5List.AddRange(Card5);


                            int tot = calc(Card1List[0].ToString()) + calc(Card2List[0].ToString()) + calc(Card3List[0].ToString()) + calc(Card4List[0].ToString()) + calc(Card5List[0].ToString());
                            totSuit = calcSuit(Card1List[1].ToString()) + calcSuit(Card2List[1].ToString()) + calcSuit(Card3List[1].ToString()) + calcSuit(Card4List[1].ToString()) + calcSuit(Card5List[1].ToString());
                            dict.Add(name + "#" + totSuit, tot);

                        }
                        else
                        {
                            //error
                        }
                    }
                }
            }
            StringBuilder winner = new StringBuilder();
            int a = 0;
            var suitDict = new Dictionary<string, int> { };
            foreach (KeyValuePair<string, int> kvp in suitDict)
            {
                if (suitDict.Values.Max() == kvp.Value)
                {
                    a++;
                    if (a == 1)
                    {
                        winner.Append(kvp.Key.Split("#")[0]);
                    }
                    else { winner.Append("," + kvp.Key.Split("#")[0]); }
                    int intWinners = winner.ToString().LastIndexOf(winner.ToString());
                    string stringWinner = winner.ToString().Substring(0, winner.ToString().Length - intWinners);
                    finctionWrite(stringWinner, dict.Values.Max());
                }
            }
            void finctionWrite(string name, int score)
            {
                try
                {
                    string filename = Path.Combine(path, "abc.txt");
                    File.Delete(filename);
                    StreamWriter sw = new StreamWriter(filename, true, Encoding.ASCII);
                    if ("Error".Equals(name))
                    {
                        sw.Write(name);
                    }
                    else
                    {
                        sw.Write(name = " : " + score);
                    }
                    sw.Close();




                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }







            }

            int calc(string CardNumber)
            {
                if (!(CardNumber.ToString().Equals("A")) && !(CardNumber.ToString().Equals("J")) && !(CardNumber.ToString().Equals("K")) && !(CardNumber.ToString().Equals("Q")))
                {
                    numVal = int.Parse(CardNumber.ToString());
                }
                else
                {


                    switch (CardNumber)
                    {
                        case "A":
                            numVal = 1;
                            break;
                        case "J":
                            numVal = 11;
                            break;
                        case "Q":
                            numVal = 12;
                            break;
                        case "K":
                            numVal = 13;
                            break;
                    }
                }


                return numVal;
            }
            int calcSuit(string CardGroup)
            {
                if (!(CardGroup.ToString().Equals("D")) && !(CardGroup.ToString().Equals("C")) && !(CardGroup.ToString().Equals("S")) && !(CardGroup.ToString().Equals("H")))
                {
                    numVal1 = 0;
                }
                else
                {


                    switch (CardGroup)
                    {
                        case "H":
                            numVal1 = 3;
                            break;
                        case "S":
                            numVal1 = 4;
                            break;
                        case "D":
                            numVal1 = 2;
                            break;
                        case "C":
                            numVal1 = 1;
                            break;
                    }
                }


                return numVal1;
            }


        }
    }
}

