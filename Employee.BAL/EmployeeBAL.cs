using Employee.DAL;
using Employee.Domain;
using System.Collections.Generic;

namespace Employee.BAL
{
    public class EmployeeBAL
    {
        private EmployeeDAL objDAL;
        public EmployeeBAL()
        {
            objDAL = new EmployeeDAL();
        }
        public List<EmployeeModel> GetEmployees()
        {
            return objDAL.GetEmployees();
        }
        public string InsertEmployee(EmployeeModel employee)
        {
            string res = objDAL.InsertEmployee(employee);
            return res;
        }
    }
}
