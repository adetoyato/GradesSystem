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


        Console.Write("Enter total students: ");
        totalStudents = int.Parse(Console.ReadLine());

        studentNames = new string[totalStudents];
        gradesScience = new int[totalStudents];
        gradesMath = new int[totalStudents];
        gradesEnglish = new int[totalStudents];

        while (true)
        {
            Console.WriteLine("\nWelcome to the Student Grades System!");
            Console.WriteLine("[1] Enroll Students");
            Console.WriteLine("[2] Enter Student Grades");
            Console.WriteLine("[3] Show Student Grades");
            Console.WriteLine("[4] Show Top Student");
            Console.WriteLine("[5] Exit");
            Console.Write("Enter Choice: ");
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
            Console.Write("Enter student name: ");
            studentNames[i] = Console.ReadLine();
            containsDigit = false;

            foreach (char c in studentNames[i])
            {
                if (char.IsDigit(c))
                {
                    containsDigit = true;
                    EnrollStudents();
                }
            }
            if (String.IsNullOrEmpty(studentNames[i]))
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
                Console.WriteLine($"{studentNames[i]} is enrolled.");
            }

            if (i < totalStudents - 1)
            {
                Console.WriteLine("Would you like to enroll another student? Y/N");
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
                Console.WriteLine("You have exceeded the number of students you are allowed to enroll. Return to Main Menu instead? Y/N");
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
            Console.WriteLine($"Student: {studentNames[i]}");
            Console.Write("Enter grade for Science: ");
            gradesScience[i] = int.Parse(Console.ReadLine());
            Console.Write("Enter grade for Math: ");
            gradesMath[i] = int.Parse(Console.ReadLine());
            Console.Write("Enter grade for English: ");
            gradesEnglish[i] = int.Parse(Console.ReadLine());

            if (i < totalStudents - 1)
            {
                Console.WriteLine("Would you like to add grades for another student? Y/N");
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
                Console.WriteLine("No students left. Return to Main Menu? [Y/N]");
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
        Console.WriteLine("\nStudent Grades");
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

        for (int i = 0; i < totalStudents; i++)
        {
            double average = (gradesScience[i] + gradesMath[i] + gradesEnglish[i]) / 3.0;
            if (average > maxAverage)
            {
                maxAverage = average;
                topStudent = studentNames[i];
            }
        }

        Console.WriteLine($"\nTop Student: {topStudent}");
    }
}

