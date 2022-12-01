﻿using System;
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

        static List<List<int>> getSuppliesFromData(string[] data){
            List<List<int>> supplies = new List<List<int>>();
            List<int> calories = new List<int>();
            foreach(string line in data){
                if (line.Length > 0){
                    calories.Add(line.ToInt32());
                }
                else{
                    List<int> copyCalories = new List<int>(calories);
                    supplies.Add(copyCalories);
                    calories.Clear();
                }
            }
            return supplies;
        }

        static int getMostCaloriesFromSupplies(List<List<int>> supplies){
            int maxCalories = 0;
            foreach(List<int> supply in supplies){
                int sumCalories = 0;
                foreach(int calories in supply){
                    sumCalories += calories;
                }
                if (sumCalories > maxCalories) maxCalories = sumCalories;
            }
            return maxCalories;
        }

        static int descending(int x, int y){
            // Passing this as a delegate to a Sort method requires that it take
            // two parameters of the type in the list and return an int whose
            // value determines the sort order:
            // 1 = Swap x for y.
            // 0 = Do not swap them.
            // -1 = Do not swap them.
            if (y>x) return 1;
            if (x>y) return -1;
            return 0;
        }

        static int getTop3CaloriesFromSupplies(List<List<int>> supplies){
            List<int> totalCalories = new List<int>();
            int maxCalories = 0;
            foreach(List<int> supply in supplies){
                int sumCalories = 0;
                foreach(int calories in supply){
                    sumCalories += calories;
                }
                totalCalories.Add(sumCalories);
            }
            totalCalories.Sort(descending);
            int count = 0;
            foreach(int calories in totalCalories){
                maxCalories += calories;
                count++;
                if (count >= 3) break;
            }
            
            return maxCalories;
        }

        static void Main(string[] args)
        {
            string[] data = getDataFromFile("input.dat");
            List<List<int>> supplies = getSuppliesFromData(data);
            int maxCalories = getTop3CaloriesFromSupplies(supplies);
            Console.WriteLine("Most calories is {0}", maxCalories);
        }
    }
}



// Read data into string array.

// Parse data into elves.

