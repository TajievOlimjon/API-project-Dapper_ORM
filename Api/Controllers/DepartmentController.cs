using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{

    [ApiController]
    [Route( "api/[controller]")]
    public class DepartmentController : Controller
    {
        private DepartmentService departmentService;
       
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
       

        [HttpGet("GetDepartments")]
        public List<Department> GetDepartments()
        {
            return departmentService.GetDepartment();
        }

        [HttpPost("InsertDepartment")]
        public int InsertDepartment(Department department)
        {
            return departmentService.Insert(department);

        }

        [HttpPut("DepartmentUpdate")]
        public int DepartmentUpdate(Department department,int Id)
        {
            return departmentService.Update(department,Id);

        }







    }
}
