using Employee.BAL;
using Employee.Domain;
using System;
using System.Collections.Generic;

namespace Employee.UI
{
    internal class Program
    {
        static EmployeeBAL objBAL;
        static Program()
        {
            objBAL = new EmployeeBAL();
        }
        static EmployeeModel GetInputEmp()
        {
            Console.WriteLine("Enter Employee Details: ");
            return new EmployeeModel()
            {
                Eno = Convert.ToInt32(Console.ReadLine()),
                Ename = Console.ReadLine(),
                Job = Console.ReadLine(),
                Salary = Convert.ToDouble(Console.ReadLine()),
                Dname = Console.ReadLine()
            };
        }
        static string InsertEmployee()
        {
            EmployeeModel emp = GetInputEmp();
            string res = objBAL.InsertEmployee(emp);
            return res;
        }
        static void Main(string[] args)
        {            
            List<EmployeeModel> emps = objBAL.GetEmployees();
            foreach(EmployeeModel e in emps)
            {
                Console.WriteLine($"{e.Eno} -   {e.Ename}   -   {e.Job}     -   {e.Salary}      -   {e.Dname}");
            }
            Console.WriteLine("Select operation: ");
            Console.WriteLine("1.Insert\n2.Update\n3.Delete");
            int dbChoice = Convert.ToInt32(Console.ReadLine());
            switch (dbChoice)
            {
                case 1:
                    InsertEmployee();
                    break;
                default:
                    break;
            }

            Console.Read();
        }
    }
}
