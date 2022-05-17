using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;

namespace Service
{
    public class DepartmentService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Exams;User Id=postgres;password=0711;";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }


        public List<Department> GetDepartment()
        {
            using (var connection = GetConnection())
            {
             var sql = " select Department.Id,Department.Name,Employee.FirsName,Employee.LastName,Employee.Gender " +
               " from DepartmentEmployee " +
               " join Department on   Department.Id = DepartmentEmployee.DepartmentId " +
                " join Employee  on Employee.Id = DepartmentEmployee.EmployeeId ";
              
                var result = connection.Query<Department>(sql);
                return result.ToList();
            }
        }

        public Department GetDepartmentById(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select * from Department where Id={Id} ";

                var getByid = con.ExecuteScalar<Department>(sql);
                return getByid;
            }

        }

        public int Insert(Department department)
        {
            using (var con=GetConnection())
            {
                var sql = $"Insert into Department(Name)" +
                    $" values('{department.Name}')";
                
             var insert = con.Execute(sql);
                return insert;
            }
        }

        public int Update(Department department ,int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" Update Department set Name='{department.Name}' Where Id={Id} ";
                var update = con.Execute(sql);
                return update;
            }
        }

       





    }
}
