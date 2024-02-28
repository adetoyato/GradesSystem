using System;

class Program
{

    static string[] studentNames;
    static int[] gradesScience;
    static int[] gradesMath;
    static int[] gradesEnglish;
    static int totalStudents;

    public static void Main(string[] args)
    {
        Console.Write("Enter total students: "); //Enter how many students to enroll.
        totalStudents = int.Parse(Console.ReadLine());

        studentNames = new string[totalStudents];
        gradesScience = new int[totalStudents];
        gradesMath = new int[totalStudents];
        gradesEnglish = new int[totalStudents];

        while (true)
        {
            Console.WriteLine("\nWelcome to the Student Grades System!");
            Console.WriteLine("[1] Enroll Students"); //Adds students by name
            Console.WriteLine("[2] Enter Student Grades"); //Adds a student's grade
            Console.WriteLine("[3] Show Student Grades"); //Shows all of the registered student's grades
            Console.WriteLine("[4] Show Top Student"); //Shows which student is the highest
            Console.WriteLine("[5] Exit"); //Exits the program
            Console.Write("Enter Choice: "); //Asks the user to choose what it is that they want to do
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    EnrollStudents();
                    break;
                case ConsoleKey.D2:
                    EnterStudentGrades();
                    break;
                case ConsoleKey.D3:
                    ShowStudentGrades();
                    break;
                case ConsoleKey.D4:
                    ShowTopStudent();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("See you next time.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void EnrollStudents()
    {
        bool containsDigit;
        Console.WriteLine("\nEnroll Student");
        for (int i = 0; i < totalStudents; i++)
        {
            Console.Write("Enter student name: "); //Add student name
            studentNames[i] = Console.ReadLine();
            containsDigit = false;

            foreach (char c in studentNames[i])
            {
                if (char.IsDigit(c)) //Checks if the name has a number or any digits
                {
                    containsDigit = true;
                    EnrollStudents();
                }
            }
            if (String.IsNullOrEmpty(studentNames[i])) //Checks if the string is blank or if there is no input
            {
                Console.WriteLine("There is no input. Enter again?");
                EnrollStudents();
            }
            else if (containsDigit)
            {
                Console.WriteLine("Name must not contain a number.");
                EnrollStudents();
            }
            else
            {
                Console.WriteLine($"{studentNames[i]} is enrolled."); //Confirmation message that the student has been enrolled.
            }

            if (i < totalStudents - 1)
            {
                Console.WriteLine("Would you like to enroll another student? Y/N"); //Asks the user if they would like to enroll another student based on the number of students they input
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("You have exceeded the number of students you are allowed to enroll. Return to Main Menu instead? Y/N"); //If the number of students allowed to be enrolled has been achieved, this message is prompted
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("See you next time.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
        }
    }

    static void EnterStudentGrades()
    {
        Console.WriteLine("\nEnter Student Grades");
        for (int i = 0; i < totalStudents; i++)
        {
            Console.WriteLine($"Student: {studentNames[i]}"); //Shows which student's grades will be inputted
            Console.Write("Enter grade for Science: "); //Adds Science grade
            gradesScience[i] = int.Parse(Console.ReadLine());
            Console.Write("Enter grade for Math: "); //Adds Math grade
            gradesMath[i] = int.Parse(Console.ReadLine());
            Console.Write("Enter grade for English: "); //Adds English grade
            gradesEnglish[i] = int.Parse(Console.ReadLine());

            if (i < totalStudents - 1)
            {
                Console.WriteLine("Would you like to add grades for another student? Y/N"); //Asks user if they would like to add grades for another student
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("No students left. Return to Main Menu? [Y/N]"); //Prompts if there are no students left for grades to be added to
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("See you next time.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
        }
    }

    static void ShowStudentGrades()
    {
        Console.WriteLine("\nStudent Grades"); //Shows the grades of all of the students enrolled
        Console.WriteLine("Name\t\tScience\t\tMath\t\tEnglish\t\tAve.");
        for (int i = 0; i < totalStudents; i++)
        {
            double average = (gradesScience[i] + gradesMath[i] + gradesEnglish[i]) / 3.0;
            Console.WriteLine($"{studentNames[i]}\t\t{gradesScience[i]}\t\t{gradesMath[i]}\t\t{gradesEnglish[i]}\t\t{average}");
        }
    }

    static void ShowTopStudent()
    {
        double maxAverage = 0;
        string topStudent = "";

        for (int i = 0; i < totalStudents; i++) //Calculates which student has the highest average grade
        {
            double average = (gradesScience[i] + gradesMath[i] + gradesEnglish[i]) / 3.0;
            if (average > maxAverage)
            {
                maxAverage = average;
                topStudent = studentNames[i];
            }
        }

        Console.WriteLine($"\nTop Student: {topStudent}"); //Displays which student is the top student based on their average grade
    }
}

