using Dapper;
using Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Exams;User Id=postgres;password=0711;";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }


        public List<Employee> GetEmployee()
        {
            using (var connection = GetConnection())
            {
                var sql = " select Employee.FirsName, Employee.LastName, Employee.Gender,Employee.BirthDate,Employee.HireDate, Department.Name " +
                  " from DepartmentEmployee " +
                  " join Department on   Department.Id = DepartmentEmployee.DepartmentId " +
                  " join Employee  on Employee.Id = DepartmentEmployee.EmployeeId ";

                var result = connection.Query<Employee>(sql);
                return result.ToList();
            }
        }


        public int Insert(Employee employee)
        {
            using (var con = GetConnection())
            {
                var sql = $" Insert into Employee( BirthDate,FirsName, LastName, Gender, HireDate) " +
                    $" values ('{employee.BirthDate}','{employee.FirsName}', " +
                    $" '{employee.LastName}','{employee.Gender}', " +
                    $" '{employee.HireDate}')";
                    

                var insert = con.Execute(sql);
                return insert;
            }
        }


        public int Update(Employee employee, int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $"Update Employee" +
                    $" set" +
                    $" BirthDate='{employee.BirthDate}'," +
                    $" FirsName='{employee.FirsName}', " +
                    $" LastName='{employee.LastName}'," +
                    $" Gender='{employee.Gender}', " +
                    $" HireDate='{employee.HireDate}'" +
                    $"Where  Id={Id}";

                var insert = con.Execute(sql);
                return insert;
            }
        }
    }
}
