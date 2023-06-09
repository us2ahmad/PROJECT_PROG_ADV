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
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
    public partial class Department
    {
        Database1Entities context; 
        public Department()
        {
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public void InsertDepartment()
        {
            try
            {
                Console.WriteLine("You are now entering data into a table Department");
                var newDepartment = new Department
                {
                    Name = Console.ReadLine().ToUpper()
                };

                context = new Database1Entities();
                
                    context.Departments.Add(newDepartment);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("The record has been added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("An error occurred while adding the record.");
                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteDepartment()
        {
            try
            {
                Console.WriteLine("Please enter the Department number you want to delete:");
                int DepartmentId = Convert.ToInt32(Console.ReadLine());

                var context = new Database1Entities();
                
                    var departmentToDelete = context.Departments.Find(DepartmentId);
                    if (departmentToDelete != null)
                    {
                        context.Departments.Remove(departmentToDelete);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("The record has been deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("An error occurred while deleting the record.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records were found matching the specified criteria.");
                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void FullDeleteDepartment()
        {
            try
            {
               var context = new Database1Entities();
                
                   context.Departments.RemoveRange(context.Departments);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("All records have been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("An error occurred while deleting the records.");
                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateDepartment()
           {
          try
              {
        Console.WriteLine("Please enter the Department number you want to modify:");
        int DepartmentId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the new value:");
        string value = Console.ReadLine();

        var context = new Database1Entities();
        
            var departmentToUpdate = context.Departments.Find(DepartmentId);
            if (departmentToUpdate != null)
            {
                departmentToUpdate.Name = value.ToUpper();
                int rowsAffected = context.SaveChanges();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("The data has been updated successfully.");
                }
                else
                {
                    Console.WriteLine("An error occurred while updating the data.");
                }
            }
            else
            {
                Console.WriteLine("No records were found matching the specified criteria.");
            }
        
    }
   
        catch (Exception e)
          {
               Console.WriteLine(e.Message);
          }
    }
        public void ShowDataDepartment()
{
    try
    {
        using (var context = new Database1Entities())
        {
            var departments = context.Departments.ToList();
            if (departments.Count > 0)
            {
                foreach (var department in departments)
                {

                    Console.WriteLine("ID: {0}, Name: {1}", department.Id, department.Name);
                    Console.WriteLine("=====================================================================================");
                }
            }
            else
            {
                Console.WriteLine("No matching record found.");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
        public void ShowDataDepartmentWithId()
{
    try
    {
        context = new Database1Entities();
        
            Console.WriteLine("Please enter the Department number you want to view:");
            int departmentId = Convert.ToInt32(Console.ReadLine());
            var department = context.Departments.FirstOrDefault(d => d.Id == departmentId);
            if (department != null)
            {
                Console.WriteLine("ID: {0} , Name: {1}", department.Id, department.Name);
                Console.WriteLine("=====================================================================================");
            }
            else
            {
                Console.WriteLine("No matching record found.");
            }
        
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
        public void start_department()
        {

            int choice;
            do
            {
                Console.WriteLine("What do you want to do in the Department table");
                Console.WriteLine("1. InsertDepartment\n==============================");
                Console.WriteLine("2. DeleteDepartment\n==============================");
                Console.WriteLine("3. FullDeleteDepartment\n==============================");
                Console.WriteLine("4. UpdateDepartment\n==============================");
                Console.WriteLine("5. ShowDataDepartment\n==============================");
                Console.WriteLine("6. ShowDataDepartmentWithId\n==============================");
                Console.WriteLine("0. To Close");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertDepartment();
                        break;
                    case 2:
                        DeleteDepartment();
                        break;
                    case 3:
                        FullDeleteDepartment();
                        break;
                    case 4:
                        UpdateDepartment();
                        break;
                    case 5:
                        ShowDataDepartment();
                        break;
                    case 6:
                        ShowDataDepartmentWithId();
                        break;
                }
            } while (choice != 0);
        }
    }
}
