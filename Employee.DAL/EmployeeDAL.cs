using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using Employee.Domain;
using System;

namespace Employee.DAL
{
    public class EmployeeDAL
    {
        public SqlConnection _connection { set; get; }
        private SqlCommand _command;
        public List<EmployeeModel> Employees { get; set; }
        public EmployeeDAL()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCon"].ConnectionString);
            Employees = new List<EmployeeModel>();
        }
        public List<EmployeeModel> GetEmployees()
        {
            _command = new SqlCommand("select * from Employee", _connection);
            _connection.Open();
            SqlDataReader dr =  _command.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    EmployeeModel emp = new EmployeeModel()
                    {
                        Eno = Convert.ToInt32(dr["Eno"]),
                        Ename = Convert.ToString(dr["Ename"]),
                        Job = Convert.ToString(dr["Job"]),
                        Salary = Convert.ToDouble(dr["Salary"]),
                        Dname = Convert.ToString(dr["Dname"])
                    };
                    Employees.Add(emp);
                }
                _connection.Close();
                return Employees;
            }
            return new List<EmployeeModel>();
        }
        public string InsertEmployee(EmployeeModel employee)
        {
            string query = $"insert into Employee values({employee.Eno},'{employee.Ename}','{employee.Job}',{employee.Salary},'{employee.Dname}')";
            _command = new SqlCommand(query, _connection);
            _connection.Open();
            SqlDataReader dr = _command.ExecuteReader();
            string msg = dr.RecordsAffected+" Record(s) Affected";
            _connection.Close();
            return msg;
        }
    }
}
