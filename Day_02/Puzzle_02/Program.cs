using System;
using System.IO;
using StringExtensionLibrary;

namespace AOC_2022
{
    class Program
    {
        //#region HELPER FUNCTIONS
        static string getFullPath(string path, string appPath)
        {
            string fullPath = path;
            if ((path.Left(1) != "/") && (path.Substring(1).Left(1) != ":")) // Check for full path in filename.
            {
                fullPath = appPath + "/" + path;
            }
            
            // Remove the trailing /.
            fullPath.TrimEnd('/');

            return fullPath;
        }
        //#endregion HELPER FUNCTIONS

        static string[] getDataFromFile(string fName)
        {
            string appPath = "";
            appPath = System.IO.Directory.GetCurrentDirectory().ToString();
            string fPath = getFullPath(fName, appPath);
            if (File.Exists(fPath))
            {
                string[] data = File.ReadAllLines(fPath);
                return data;
            }
            else{
                Console.WriteLine("File not found. {0}", fPath);
            }
            return null;
        }

        
        static int getScoreFromData(string[] scores, string prediction){
            int score = 1;
            while (prediction != scores[score-1]) score++;
            return score;
        }

        static int getTotalScoreFromData(string[] scores, string[] data){
            int score = 0;
            foreach(string prediction in data){
                score += getScoreFromData(scores, prediction);
            }
            return score;
        }

        static void Main(string[] args)
        {
            /*
            Transformed Score	
                1	B X	 =>	B X
                2	C Y	 =>	C X
                3	A Z	 =>	A X
                4	A X	 =>	A Y
                5	B Y	 =>	B Y
                6	C Z	 =>	C Y
                7	C X	 =>	C Z
                8	A Y	 =>	A Z
                9	B Z	 =>	B Z
            */
            //string[] scores = { "B X", "C Y", "A Z", "A X", "B Y", "C Z", "C X", "A Y", "B Z" };
            string[] scores = { "B X", "C X", "A X", "A Y", "B Y", "C Y", "C Z", "A Z", "B Z" };
            string[] data = getDataFromFile("input.dat");
            int totalScore = getTotalScoreFromData(scores, data);
            Console.WriteLine("Your total predicted score is {0}", totalScore);
        }
    }
}
