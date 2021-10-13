using System;
using System.Collections.Generic;

namespace GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {

            /*-------------------------------Lab Summary-------------------------------------------
             * Prompt: What is the main difference between a list and an array?
             * 
             * Answer: A list can have a variable size (can shrink or grow) and an array is a set size. If you want to change an array's size
             *         You need to make a whole new array.
             * 
             */

            // Initialize variables needed:
            string infoChoice = "";
            int studentIndex = 0;


            // List for: studentNumber, studentName, studentHometown, studentFood
            List<int> studentNumber = new List<int>();
            List<string> studentName = new List<string>();
            List<string> studentHometown = new List<string>();
            List<string> studentFood = new List<string>();

            //Add each student's number
            for(int i = 1; i < 11; i++)
            {
                studentNumber.Add(i);
            }

            //Add Each student's name
            studentName.Add("Erin Walter");
            studentName.Add("Richard Moss");
            studentName.Add("James Michell");
            studentName.Add("Cullin Flynn");
            studentName.Add("Corrdero Ebberhart");
            studentName.Add("Calyn Green");
            studentName.Add("Huy Phan");
            studentName.Add("Tommy Waalkes");
            studentName.Add("Cassly Sullen");
            studentName.Add("Phillip Conrad");

            //Add each student's Hometown
            studentHometown.Add("Troy, MI");
            studentHometown.Add("Canton");
            studentHometown.Add("Yap, FSM");
            studentHometown.Add("Fowlerville, MI");
            studentHometown.Add("Berkley, MI");
            studentHometown.Add("Portage, MI");
            studentHometown.Add("Lansing, MI");
            studentHometown.Add("Raleigh, NC");
            studentHometown.Add("Detroit, MI");
            studentHometown.Add("Canton, MI");

            //Add each student's food
            studentFood.Add("Tacos");
            studentFood.Add("Sushi");
            studentFood.Add("Katsu");
            studentFood.Add("Pad Thai");
            studentFood.Add("BBQ");
            studentFood.Add("Mac and Cheese");
            studentFood.Add("Korean BBQ");
            studentFood.Add("Chicken Curry");
            studentFood.Add("Steak");
            studentFood.Add("Fried Chicken");

            Console.WriteLine("Welcome to our C# class!");

            //Create a while loop to handle the continuous running of the program
            bool keepGoing = true;

            while (keepGoing)
            {
                string userAnswer = GetUserInput("Which student would you like to learn more about?" +
                " (enter a name or number 1 - 10): ");
                bool invalidateStudent = true;

                do
                {
                    //See if their answer is a number or a word
                    if (int.TryParse(userAnswer, out int userNum) && userNum > 0 && userNum <= studentNumber.Count)
                    {
                        //Call Check Student passing the studentNum List and the user integer guess
                        studentIndex = CheckStudent(studentNumber, userNum);
                        break;
                    }

                    //Call Check Student passing name List and the user string
                    studentIndex = CheckStudent(studentName, userAnswer);

                    if(studentIndex != 0)
                    { 
                        invalidateStudent = false;
                    }

                    if (invalidateStudent) { 
                        userAnswer = GetUserInput("That student does not exist. Please try again." +
                            " (enter a name or number 1 - 10): ");
                    }

                } while (invalidateStudent);

                infoChoice = GetUserInput($"Student {studentNumber[studentIndex]} is {studentName[studentIndex]}." +
                    $" What would you like to know about {studentName[studentIndex]}? (enter “hometown” or “favorite food”): ");
                bool invalidAnswer = true;

                do //This validates that hte user is entering "hometown" or "favorite food"
                {
                    

                    switch (infoChoice.ToLower().Trim())
                    {
                        case "hometown":
                            Console.WriteLine($"{studentName[studentIndex]} is from {studentHometown[studentIndex]}");
                            invalidAnswer = false;
                            break;
                        case "favorite food":
                            Console.WriteLine($"{studentName[studentIndex]}'s favorite food is {studentFood[studentIndex]}");
                            invalidAnswer = false;
                            break;
                        default:
                            
                            break;
                    }

                    if (invalidAnswer)
                    {
                        infoChoice = GetUserInput("That data does not exist. Please try again." +
                                " (enter \"hometown\" or \"favorite food\"):  ");
                    }

                } while (invalidAnswer);


                keepGoing = Continue();
            }



        }

        // Create a method to

        public static int CheckStudent(List<string> names, string studentName)
        {
            //See if there are any name matches in the list
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i] == studentName)
                {
                    return i;
                }
            }

            return 0;
        }

        public static int CheckStudent(List<int> numbers, int studentNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == studentNumber)
                {
                    return i;
                }
            }

            return 0;
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();


            return output;
        }

        public static bool Continue()
        {
            string answer = GetUserInput("Would you like to know more? (enter “yes” or “no”): ");

            if (answer.ToLower().Trim() == "yes")
            {
                return true;
            }
            else if (answer.ToLower().Trim() == "no")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("Please enter either Y or N to continue.");
                return Continue();
            }

        }
    }
}
