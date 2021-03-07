using System;
using System.Collections.Generic;
using CalvinTest.TestHelpers;
using System.Linq;
namespace CalvinTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfExpenses = Question1ExpenseReports();
            var listOfExpeses2 = Question2ExpenseReport();
            var question1Answer =  listOfExpenses.Aggregate(1, (x, y) => x * y);
            var question2Answer = listOfExpeses2.Aggregate(1, (x, y) => x * y);
            var question3Answer = Question3PasswordsValid();
            var question4Answer = Question4PasswordsValid();
            var question5Answer = Question5SlopesAndTrees();
            var listOfTrees = Question6SlopesAndTrees();
            var question6 = listOfTrees.Aggregate(1, (x, y) => x * y);
   

            Console.WriteLine($"Question  1 answer is  {question1Answer}");
            Console.WriteLine($"Question  2 answer is  {question2Answer}");
            Console.WriteLine($"Question  3 answer is  {question3Answer}");
            Console.WriteLine($"Question  4 answer is  {question4Answer}");
            Console.WriteLine($"Question  5 answer is  {question5Answer}");
            Console.WriteLine($"Question  6 answer is  {question6}");
        }

        public static List<int> Question1ExpenseReports()
        {
            TestHelper testHelpers = new TestHelper();
            List<int> expenseData = testHelpers.Question1ExpenseList();
            var listOfNumbers = new List<int>();
            var firstAmount = 0;
            var index = 0;
            bool found = false;
            if (expenseData.Count == 0) return listOfNumbers;
            while (!found && index != expenseData.Count)
            {
                firstAmount = expenseData[index];
                for (var i = 0; i < expenseData.Count; i++)
                {
                    if (firstAmount + expenseData[i] == 2020)
                    {
                        listOfNumbers.Add(firstAmount);
                        listOfNumbers.Add(expenseData[i]);
                        found = true;
                    }
                }
                index++;
            }
            return listOfNumbers;
        }
        public static List<int> Question2ExpenseReport()
        {
            TestHelper testHelpers = new TestHelper();
            List<int> expenseData = testHelpers.Question1ExpenseList();
            var index = 0;
            var listOfNumbers = new List<int>();
            bool found = false;
            if (expenseData.Count == 0) return listOfNumbers;
            while (!found && index != expenseData.Count)
            {
                var firstAmount = expenseData[index];
                for (var i = 0; i < expenseData.Count; i++)
                {
                    for (var x = 0; x < expenseData.Count; x++)
                    {
                        if ((firstAmount + expenseData[i] + expenseData[x]) == 2020 && !found)
                        {
                            listOfNumbers.Add(firstAmount);
                            listOfNumbers.Add(expenseData[x]);
                            listOfNumbers.Add(expenseData[i]);
                            found = true;
                        }
                    }

                }
                index++;
            }
            return listOfNumbers;
        }

        public static int Question3PasswordsValid()
        {
            TestHelper testHelpers = new TestHelper();
            var listOfpasswords = testHelpers.Question2DataList();
            int validCount = 0;
            foreach (var pass in listOfpasswords)
            {
                var passSplit = pass.Split();
                var amountRule = passSplit[0].ToString().Split('-').Select(x => int.Parse(x)).ToList();
                var passchar = passSplit[1].ToString().ToLower().Replace(":", "")[0];
                var passwordToCheck = passSplit[2].ToString().ToLower();
                var amountFound = passwordToCheck.Count(x => x == passchar);
                if (amountFound >= amountRule[0] && amountFound <= amountRule[1]) validCount++;

            }
            return validCount;
        }

        public static int Question4PasswordsValid()
        {
            TestHelper testHelpers = new TestHelper();
            var listOfpasswords = testHelpers.Question2DataList();
            int validCount = 0;
            foreach (var pass in listOfpasswords)
            {
                var passSplit = pass.Split();
                var amountRule = passSplit[0].ToString().Split('-').Select(x => int.Parse(x)-1).ToList();
                var passchar = passSplit[1].ToString().Replace(":", "")[0];
                var passwordToCheck = passSplit[2].ToString();
                List<char> lettersAtEachPosition = new List<char> {
                     passwordToCheck[amountRule[0]],
                     passwordToCheck[amountRule[1]]
                };
                if (lettersAtEachPosition.Contains(passchar) && lettersAtEachPosition[0] != lettersAtEachPosition[1])
                {
                    validCount++;
                }

            }
            return validCount;
        }

        public static int Question5SlopesAndTrees()
        {
            TestHelper testHelpers = new TestHelper();
            var Map = testHelpers.Question3DataList();
            List<string> newMap = new List<string>();
            var trees = 0;
            var mapCoordinateRight = 3;
            var mapCoordinaterDown = 1;
            foreach (string location in Map)
            {
                if(Map.IndexOf(location) != 0)
                {
                    char itemfound = location[mapCoordinateRight % 31];
                    if(itemfound == '#')
                    {
                        trees++;
                    }
                    mapCoordinaterDown += 1;
                    mapCoordinateRight += 3;
                }
                
            }
            return trees;
        }
        public static List<int> Question6SlopesAndTrees()
        {
            TestHelper testHelpers = new TestHelper();
            var Map = testHelpers.Question3DataList();
            List<int> totalTrees = new List<int>();
            var treesTotal = 1;
            var mapCoordinateRight = 1;
            var mapCoordinaterDown = 1;
            foreach (string location in Map)
            {
                if (Map.IndexOf(location) != 0)
                {
                    char itemfound = location[mapCoordinateRight % 31];
                    totalTrees.Add(location.Count(s => s == '#'));
                    mapCoordinaterDown += 1;
                    mapCoordinateRight += 2;
                }

            }
            return totalTrees;
        }
    }

   

   

}
