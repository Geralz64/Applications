using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL.Classes
{
    public static class Department
    {

        public static async Task<List<SQL.Department>> GetDepartments()
        {

            var db = new AdventureWorks2012Entities();

            var departments = (from dept in db.Departments
                               select dept).ToListAsync();

            return await departments;

        }

        public static async Task<SQL.Department> GetDepartment(int departmentID)
        {

            var db = new AdventureWorks2012Entities();
            SQL.Department department = new SQL.Department();

            await Task.Run(() =>

            department = (from dept in db.Departments
                          where dept.DepartmentID == departmentID
                          select dept).FirstOrDefault()

            );

            return department;

        }


        public static void UpdateDepartment(int departmentID, string newName)
        {
            var db = new AdventureWorks2012Entities();

            var department = db.Departments.Where(d => d.DepartmentID == departmentID).FirstOrDefault();

            department.Name = newName;

            db.SaveChanges();
        }

        public static void DeleteDepartment(int departmentID)
        {
            var db = new AdventureWorks2012Entities();

            var department = db.Departments.Where(d => d.DepartmentID == departmentID).FirstOrDefault();

            db.Departments.Remove(department);

        }


        public static void InsertDepartment(SQL.Department department)
        {
            var db = new AdventureWorks2012Entities();

            db.Departments.Add(department);

        }



    }
}
