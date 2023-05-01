using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to my program");
            try
            {
                int choice;
                do
                {
                    Console.WriteLine("Choose the table you want to work on");
                    Console.WriteLine("1. STUDENT\n==============================");
                    Console.WriteLine("2. SUBJECT\n==============================");
                    Console.WriteLine("3. DEPARTMENT\n==============================");
                    Console.WriteLine("4. Exam\n==============================");
                    Console.WriteLine("5. StudentMark\n==============================");
                    Console.WriteLine("6. SubjectLecture\n==============================");
                    Console.WriteLine("0. To Close");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Student std = new Student();
                            std.start_student();
                            break;
                        case 2:
                            Subject sub = new Subject();
                            sub.start_subject();
                            break;
                        case 3:
                            Department dep = new Department();
                            dep.start_department();
                            break;
                        case 4:
                            Exam ex = new Exam();
                            ex.start_exam();
                            break;
                        case 5:
                            StudentMark stdmark = new StudentMark();
                            stdmark.Start_studentmark();
                            break;
                        case 6:
                            SubjectLecture sublec = new SubjectLecture();
                            sublec.start_SubjectLecture();
                            break;
                    }
                } while (choice != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message.ToString());
            }
            finally
            {
                Console.WriteLine("Thank You To Using My Program");
            }
        }
    }
}
