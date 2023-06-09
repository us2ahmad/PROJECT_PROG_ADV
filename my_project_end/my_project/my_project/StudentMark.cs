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
    public partial class StudentMark
    {
        Database1Entities context;
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Mark { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        public void AddData()
        {
            Console.WriteLine("Enter the Mark Of StudentMark");
            Mark = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the StudentId Of StudentMark");
            StudentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ExamId Of StudentMark");
            ExamId = int.Parse(Console.ReadLine());


        }
        public void InsertStudentmark()
        {
            context = new Database1Entities();

            try
            {
                AddData();
                var studentMark = new StudentMark
                {
                    Mark = Mark,
                    ExamId = ExamId,
                    StudentId = StudentId
                };
                context.StudentMarks.Add(studentMark);
                context.SaveChanges();
                Console.WriteLine("The record has been added successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }
        public void DeleteStudentmark()
        {
            context = new Database1Entities();
            try
            {
                Console.WriteLine("Please enter the StudentMark number you want to delete:");
                int studentmarkId = Convert.ToInt32(Console.ReadLine());
                var studentMark = context.StudentMarks.FirstOrDefault(sm => sm.Id == studentmarkId);
                if (studentMark == null)
                {
                    Console.WriteLine("No records were found matching the specified criteria.");
                }
                else
                {
                    context.StudentMarks.Remove(studentMark);
                    context.SaveChanges();
                    Console.WriteLine("The record has been deleted successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        public void FullDeleteStudentMark()
        {
            context = new Database1Entities();
            {
                try
                {
                    context.StudentMarks.RemoveRange(context.StudentMarks);
                    context.SaveChanges();

                    context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('StudentMarks', RESEED, 0)");

                    Console.WriteLine("All records have been deleted successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }
        public void FullUpdateStudentmark()
        {
            context = new Database1Entities();

            try
            {
                Console.WriteLine("Please enter the StudentMark number you want to modify:");
                int studentmarkId = Convert.ToInt32(Console.ReadLine());
                var studentMark = context.StudentMarks.FirstOrDefault(sm => sm.Id == studentmarkId);
                if (studentMark == null)
                {
                    Console.WriteLine("No records were found matching the specified criteria.");
                    return;
                }
                studentMark.Mark = Mark;
                studentMark.ExamId = ExamId;
                studentMark.StudentId = StudentId;
                context.SaveChanges();
                Console.WriteLine("The record has been updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        public void UpdateStudentmark()
        {
            context = new Database1Entities();
            
                try
                {
                    Console.WriteLine("Please enter the studentmarks number you want to modify:");
                    int studentmarkId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("What do you want to modify?");
                    Console.WriteLine("1. Mark");
                    Console.WriteLine("2. ExamId");
                    Console.WriteLine("3. StudentId");
                    Console.WriteLine("0. To Close");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the new value:");
                    string value = Console.ReadLine();

                    // Get the student mark object to update
                    var studentMark = context.StudentMarks.FirstOrDefault(sm => sm.Id == studentmarkId);

                    // If the student mark object is not found, inform the user and return
                    if (studentMark == null)
                    {
                        Console.WriteLine("No records were found matching the specified criteria.");
                        return;
                    }

                    // Update the appropriate property with new data
                    switch (choice)
                    {
                        case 1:
                            studentMark.Mark = int.Parse(value);
                            break;
                        case 2:
                            studentMark.ExamId = int.Parse(value);
                            break;
                        case 3:
                            studentMark.StudentId = int.Parse(value);
                            break;
                        default:
                            return;
                    }

                    // Save changes to the database
                    context.SaveChanges();

                    Console.WriteLine("The data has been updated successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        public void ShowDataStudentmark()
{
     context = new Database1Entities();
    
        try
        {
            var studentMarks = context.StudentMarks.ToList();

            if (studentMarks.Count == 0)
            {
                Console.WriteLine("No matching record found.");
                return;
            }

            foreach (var studentMark in studentMarks)
            {
                Console.WriteLine("ID: {0} , Mark: {1} , ExamId: {2} , StudentId: {3}",studentMark.Id,studentMark.Mark,studentMark.ExamId,studentMark.StudentId);
                Console.WriteLine("=====================================================================================");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: {0}",ex.Message.ToString());
        }
    
}
        public void ShowDataStudentMarkWithId()
{
    try
    {
              context = new Database1Entities();
        Console.WriteLine("Please enter the studentmark number you want to view:");
        int studentmarkId = Convert.ToInt32(Console.ReadLine());
        
        
            var studentMark = context.StudentMarks.FirstOrDefault(sm => sm.Id == studentmarkId);
            
            if (studentMark != null)
            {
                Console.WriteLine("ID: {0} , Mark: {1} , ExamId: {2} , StudentId: {3}", studentMark.Id, studentMark.Mark, studentMark.ExamId, studentMark.StudentId);
                Console.WriteLine("=====================================================================================");
            }
            else
            {
                Console.WriteLine("No matching record found.");
            }
        }
    
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: {0}",ex.Message);
    }

}
        public void Start_studentmark()
        {
            int choice;
            do
            {
                Console.WriteLine("What do you want to do in the students table");
                Console.WriteLine("1. InsertStudentmark\n==============================");
                Console.WriteLine("2. DeleteStudentmark\n==============================");
                Console.WriteLine("3. FullDeleteStudentMark\n==============================");
                Console.WriteLine("4. FullUpdateStudentmark\n==============================");
                Console.WriteLine("5. UpdateStudentmark\n==============================");
                Console.WriteLine("6. ShowDataStudentmark\n==============================");
                Console.WriteLine("7. ShowDataStudentMarkWithId\n==============================");
                Console.WriteLine("0. To Close");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertStudentmark();
                        break;
                    case 2:
                        DeleteStudentmark();
                        break;
                    case 3:
                        FullDeleteStudentMark();
                        break;
                    case 4:
                        FullUpdateStudentmark();
                        break;
                    case 5:
                        UpdateStudentmark();
                        break;
                    case 6:
                        ShowDataStudentmark();
                        break;
                    case 7:
                        ShowDataStudentMarkWithId();
                        break;
                }
            } while (choice != 0);
        }












    }
}
