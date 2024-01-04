using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace EmpolyeeWebapiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CompanydbContext _dbcontext;
        public EmployeeController(IConfiguration configuration, CompanydbContext dbcontext)
        {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("Employee")]
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            employees =_dbcontext.tblEmployee.ToList();
            return employees;
        }
        [HttpGet]
        [Route("getdataById/{id}")]
        public List<Employee> getdatabtId(int id)
        {
            var employees = new List<Employee>();
            employees = _dbcontext.tblEmployee.Where(x=>x.Emp_Id==id).ToList();
            return employees;
        }

        [HttpPost]
        [Route("addemployee")]
        public void addEmployee([FromBody] EmployeeData Obj)
        {
            if (Obj.Id == "")
            {
                Employee ObjModel = new Employee();
                ObjModel.FirstName = Obj.firstName;
                ObjModel.LastName = Obj.lastName;
                ObjModel.Contact = Convert.ToInt64(Obj.contact);
                ObjModel.Address = Obj.address;
                ObjModel.Department = Obj.department;
                ObjModel.DOJ = Convert.ToDateTime(Obj.doj);
                _dbcontext.tblEmployee.Add(ObjModel);
                _dbcontext.SaveChanges();
            }
            else {
                var result = _dbcontext.tblEmployee.FirstOrDefault(e => e.Emp_Id == Convert.ToInt16(Obj.Id));
                if (result != null)
                {
                    result.FirstName=Obj.firstName;
                    result.LastName=Obj.lastName;
                    result.Contact = Convert.ToInt64(Obj.contact); 
                    result.Address=Obj.address;
                    result.Department = Obj.department;
                    _dbcontext.SaveChanges();
                }

            }
        }
        [HttpDelete]
        [Route("deleteemployee/{Id}")]        
        public bool deleteEmployee(int Id)
        {
            var result = _dbcontext.tblEmployee.FirstOrDefault(e => e.Emp_Id == Id);
            if (result != null)
            {
                _dbcontext.tblEmployee.Remove(result);
                _dbcontext.SaveChanges();
            }
            return true;            
        }
        [HttpPut]
        [Route("updateemployee")]
        public void updateeEmployee()
        {
            var result = _dbcontext.tblEmployee.FirstOrDefault(e => e.Emp_Id == 5);
            if (result != null)
            {
                result.Address = "Mumbai";                
                result.Contact = 9096348097;
                _dbcontext.SaveChanges();
            }
        }


    }
}
