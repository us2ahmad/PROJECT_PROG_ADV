//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace my_project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data.Entity;
    public partial class Student
    {
        public Student()
        {
            this.StudentMarks = new HashSet<StudentMark>();
        }
        Database1Entities context;
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public Nullable<int> DepartmentId { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<StudentMark> StudentMarks { get; set; }
        public void AddData()
        {
            Console.WriteLine("Enter the UserName Of Student");
            Username = Console.ReadLine();
            Console.WriteLine("Enter the FirstName Of Student");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter the LastName Of Student");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter the Email Of Student");
            Email = Console.ReadLine();
            Console.WriteLine("Enter the Phone Of Student");
            Phone = Console.ReadLine();
            Console.WriteLine("Please enter the registration date (format: MM/dd/yyyy):");
            string dateStr = Console.ReadLine();
            RegisterDate = DateTime.Parse(dateStr);
            Console.WriteLine("Enter the DepartmentId Of Student ");
            DepartmentId = int.Parse(Console.ReadLine());
        }
        public void InsertStudent()
        {
              AddData();
              context = new Database1Entities();
                var student = new Student
                {
                    Username = Username,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Phone = Phone,
                    RegisterDate = RegisterDate,
                    DepartmentId = DepartmentId
                };
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("The record has been added successfully.");
        }
        public void DeleteStudent()
        {
                    context = new Database1Entities();
                    Console.WriteLine("Please the student number you want to delete:");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    var student = context.Students.FirstOrDefault(s => s.Id == studentId);
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        Console.WriteLine("The record has been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No records were found matching the specified criteria.");
                    }
        }
        public void FullDeleteStudent()
        {
             context = new Database1Entities();
            
                var students = context.Students.ToList();

                if (students.Count > 0)
                {
                    context.Students.RemoveRange(students);
                    context.SaveChanges();
                    Console.WriteLine("The record has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No records were found matching the specified criteria.");
                }
       }
        public void FullUpdateStudents()
        {
            context = new Database1Entities();
                Console.WriteLine("Please enter the student number you want to modify:");
                int studentId = Convert.ToInt32(Console.ReadLine());
                var student = context.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    AddData();
                    student.Username = Username.ToUpper();
                    student.FirstName = FirstName.ToUpper();
                    student.LastName = LastName.ToUpper();
                    student.Email = Email.ToUpper();
                    student.Phone = Phone;
                    student.RegisterDate = RegisterDate;
                    student.DepartmentId = DepartmentId;
                    context.SaveChanges();
                    Console.WriteLine("The record has been Updated successfully.");
                }
                else
                {
                    Console.WriteLine("No records were found matching the specified criteria.");
                }
        }
            public void UpdateStudent()
{
    try
    {
        Console.WriteLine("Please enter the student number you want to modify:");
        int studentId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What do you want to modify?");
        Console.WriteLine("1. UserName");
        Console.WriteLine("2. FirstName ");
        Console.WriteLine("3. LastName");
        Console.WriteLine("4. Email ");
        Console.WriteLine("5. Phone");
        Console.WriteLine("6. RegisterDate ");
        Console.WriteLine("7. DepartmentId ");
        Console.WriteLine("0. To Close");
        int choice = Convert.ToInt32(Console.ReadLine());
        context = new Database1Entities();
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);
            if(student == null)
            {
                Console.WriteLine("No records were found matching the specified criteria.");
                return;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter the new UserName:");
                    student.Username = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Please enter the new FirstName:");
                    student.FirstName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Please enter the new LastName:");
                    student.LastName = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Please enter the new Email:");
                    student.Email = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Please enter the new Phone:");
                    student.Phone = Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Please enter the new RegisterDate:");
                    student.RegisterDate = Convert.ToDateTime(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("Please enter the new DepartmentId:");
                    student.DepartmentId = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    return;
            }
            context.SaveChanges();
            Console.WriteLine("The data has been updated successfully.");
        }
    
    catch(Exception e)
    {
        Console.WriteLine(e.Message.ToString());
    }
    }
        public void ShowDataStudents()
        {
         context = new Database1Entities();
            var students = context.Students.ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("No matching record found.");
            }
            else
            {
                foreach (var student in students)
                {
                Console.WriteLine("ID: {0} , UserName: {1} , FirstName: {2} , LastName: {3} , Email: {4} , Phone: {5} , RegisterDate: {6} , DepartmentId: {7}", student.Id, student.Username, student.FirstName, student.LastName, student.Email, student.Phone, student.RegisterDate.ToString("yyyy-MM-dd"),student.DepartmentId);
                Console.WriteLine("=====================================================================================");
                 }
        }
      }

        public void ShowDataStudentsWithId()
{
    var context = new Database1Entities();
    
        Console.WriteLine("Please enter the student number you want to view");
        int studentId = Convert.ToInt32(Console.ReadLine());
        var student = context.Students.FirstOrDefault(s => s.Id == studentId);

        if (student == null)
        {
            Console.WriteLine("No matching record found.");
        }
        else
        {
            Console.WriteLine("ID: {0} , UserName: {1} , FirstName: {2} , LastName: {3} , Email: {4} , Phone: {5} , RegisterDate: {6} , DepartmentId: {7}", student.Id, student.Username, student.FirstName, student.LastName, student.Email, student.Phone, student.RegisterDate.ToString("yyyy-MM-dd"), student.DepartmentId);
            Console.WriteLine("=====================================================================================");
        }
    
}

        public void ShowStudentforDepartment()
{
         context = new Database1Entities();
    
        Console.WriteLine("Enter the number of the Department you want to display the students in");
        int departmentId = int.Parse(Console.ReadLine());
        var students = context.Students.Where(s => s.DepartmentId == departmentId);

        if (!students.Any())
        {
            Console.WriteLine("No matching record found.");
        }
        else
        {
            foreach (var student in students)
            {
                
        
            Console.WriteLine("ID: {0} , UserName: {1} , FirstName: {2} , LastName: {3} , Email: {4} , Phone: {5} , RegisterDate: {6} , DepartmentId: {7}", student.Id, student.Username, student.FirstName, student.LastName, student.Email, student.Phone, student.RegisterDate.ToString("yyyy-MM-dd"), student.DepartmentId);
            Console.WriteLine("=====================================================================================");
        
            }
        }
    
}
    public void ShowStudentforTerm()
{
    try
    {
        Console.WriteLine("Enter the term number whose students you want to display");
        int term = int.Parse(Console.ReadLine());

       context = new Database1Entities();
       var students = from student in context.Students
                      join department in context.Departments on student.DepartmentId equals department.Id
                      join subject in context.Subjects on department.Id equals subject.DepartmentId
                      where subject.Term == term
                      orderby student.DepartmentId
                      select new { Student = student, Department = department, Subject = subject };
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine("ID: {0}, UserName: {1}, FirstName: {2}, LastName: {3}, Email: {4}, Phone: {5}, RegisterDate: {6}, DepartmentId: {7}, Subject Name: {8}, Term: {9}",
                        student.Student.Id, student.Student.Username, student.Student.FirstName, student.Student.LastName, student.Student.Email, student.Student.Phone, 
                        student.Student.RegisterDate.ToString("yyyy-MM-dd"), student.Student.DepartmentId, student.Subject.Name, student.Subject.Term);
                    Console.WriteLine("=====================================================================================");
                }
            }
            else
            {
                Console.WriteLine("No matching record found.");
            }
        
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: {0}", ex.Message);
    }
}

        public void ShowStudentForExam()
        {
            try
            {
                Console.WriteLine();
                int inchoose;
                do
                {
                    Console.WriteLine("You want to show students that took a specific exam or students that didn't take a specific exam");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("To view students who have applied to a subject of your choice, press 1");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("To view students who did not apply for a subject of your choice, press 2");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("To return to the previous menu, press 0 ");
                    inchoose = int.Parse(Console.ReadLine());

                    switch (inchoose)
                    {
                        case 1:
                            Console.WriteLine("Enter the subject number to see who applied for it");
                            int subid = int.Parse(Console.ReadLine());
                            context = new Database1Entities();

                            var students = context.Students
                                .Where(s => s.StudentMarks
                                    .Any(sm => sm.Exam.SubjectId == subid))
                                .Include(s => s.Department)
                                .ToList();

                            if (students.Count == 0)
                            {
                                Console.WriteLine("No records found.");
                            }
                            else
                            {
                                foreach (var student in students)
                                {
                                    Console.WriteLine($"Id:{student.Id} , UserName:{student.Username} , FirstName:{student.FirstName} , LastName:{student.LastName}, Email:{student.Email} , Phone:{student.Phone} , DepartmentId:{student.DepartmentId}\n========================================================");
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the subject number to see who did not apply for it");
                            subid = int.Parse(Console.ReadLine());
                            context = new Database1Entities();

                            var std = context.Students
                                .Where(s => !s.StudentMarks
                                    .Any(sm => sm.Exam.SubjectId == subid))
                                .Include(s => s.Department)
                                .ToList();

                            if (std.Count == 0)
                            {
                                Console.WriteLine("No records found.");
                            }
                            else
                            {
                                foreach (var student in std)
                                {
                                    Console.WriteLine($"Id:{student.Id} , UserName:{student.Username} , FirstName:{student.FirstName} , LastName:{student.LastName}, Email:{student.Email} , Phone:{student.Phone} , DepartmentId:{student.DepartmentId}\n========================================================");
                                }
                            }
                   
                
                            break;
                        case 0:
                            break;
                    }
                } while (inchoose != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void start_student()
    {
        int choice;
        do
        {
            Console.WriteLine("What do you want to do in the students table");
            Console.WriteLine("1. InserStudent\n==============================");
            Console.WriteLine("2. DeleteStudent\n==============================");
            Console.WriteLine("3. FullDeleteStudent\n==============================");
            Console.WriteLine("4. FullUpdateStudents\n==============================");
            Console.WriteLine("5. UpdateStudents\n==============================");
            Console.WriteLine("6. ShowDataStudents\n==============================");
            Console.WriteLine("7. ShowDataStudentsWithId\n==============================");
            Console.WriteLine("8. ShowStudentforDepartment\n==============================");
            Console.WriteLine("9. ShowStudentforTerm\n==============================");
            Console.WriteLine("10. ShowStudentForExam\n==============================");
            Console.WriteLine("0. To Close");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    FullDeleteStudent();
                    break;
                case 4:
                    FullUpdateStudents();
                    break;
                case 5:
                    UpdateStudent();
                    break;
                case 6:
                    ShowDataStudents();
                    break;
                case 7:
                    ShowDataStudentsWithId();
                    break;
                case 8:
                    ShowStudentforDepartment();
                    break;
                case 9:
                    ShowStudentforTerm();
                    break;
                case 10:
                    ShowStudentForExam();
                   break;
            }
        } while (choice != 0);
    }
    }
    }
