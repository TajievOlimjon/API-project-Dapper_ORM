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
    public  class ManagerService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Exams;User Id=postgres;password=0711;";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public List<DepartmentManager> GetDepartmentManager()
        {
            using (var connection = GetConnection())
            {
                var sql = " select Employee.FirsName as ManagerName, Employee.LastName as ManagerLastName, Department.Name as  DepartmentName "+
                   " from DepartmentManager " +
                   " join Department on Department.Id = DepartmentManager.DepartmentId " +
                    " join Employee  on Employee.Id = DepartmentManager.EmployeeId ";

                var result = connection.Query<DepartmentManager>(sql);
                return result.ToList();
            }
        }

        public int ManagerInsert(DepartmentManager manager)
        {
            using (var con =GetConnection())
            {
                var sql = $" Insert into DepartmentManager(EmployeeId,DepartmentId,FromDate,ToDate)" +
                    $" Values( {manager.EmployeeId}," +
                    $" {manager.DepartmentId}," +
                    $" '{manager.FromDate}'," +
                    $" '{manager.ToDate}' ) ";
                var insert = con.Execute(sql);
                return  insert;
                      
             }
        }

       

    }
}
