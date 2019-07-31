using Repository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.TestDB
{
    public class HumanResources
    {


        public static List<Department> GetDepartments()
        {

            var db = new AdventureWorks2012Entities();

            var departments = (from dept in db.Departments
                               select dept).ToList<Department>();

            return departments;

        }

        public static Department GetDepartment(int departmentID)
        {

            var db = new AdventureWorks2012Entities();

            var department = (from dept in db.Departments
                              where dept.DepartmentID == departmentID
                              select dept).FirstOrDefault();

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


        public static void InsertDepartment(Department department)
        {
            var db = new AdventureWorks2012Entities();

            db.Departments.Add(department);

        }



    }
}
