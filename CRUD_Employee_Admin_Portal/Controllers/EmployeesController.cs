using CRUD_Employee_Admin_Portal.Data;
using CRUD_Employee_Admin_Portal.Models;
using CRUD_Employee_Admin_Portal.Models.Enitities;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Employee_Admin_Portal.Controllers
{

    //localhost:XXXX/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDBContext DbContext;
        public EmployeesController(ApplicationDBContext DbContext)
        {
            this.DbContext = DbContext;
        }



        // View DB values
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //return Ok(DbContext.Employees.ToList());
            var allEmployee = DbContext.Employees.ToList();
            return Ok(allEmployee);
        }


        //Retrive Operation
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllEmployeeById(Guid id)
        {
            var employee = DbContext.Employees.Find(id);
            return (employee is null)? NotFound() : Ok(employee);
        }

        // Update values

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeId = DbContext.Employees.Find(id);
                if (employeeId is null) {
                NotFound();
            }
            employeeId.Name = updateEmployeeDto.Name;
            employeeId.Email = updateEmployeeDto.Email;
            employeeId.Salary = updateEmployeeDto.Salary;
            employeeId.Phone = updateEmployeeDto.Phone;

            DbContext.SaveChanges();
            return Ok(employeeId);
        }



        //Delete Employee
        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = DbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound(); 
            }
            DbContext.Employees.Remove(employee);
            DbContext.SaveChanges();

            return Ok();
        }
        //AddEmployeeDTO  ====>> Data Transfer Object
        // Here the These Data transfer Object contains all the details for request or for response 
        // Then it is like frontEnd PostMan and for backend as API 



        [HttpPost]
        public IActionResult AddEmployee([FromBody]  AddEmployeeDTO addEmployeeDTO)
        {


            //AddEmployeeDTO is just a container for input data. It doesn’t know about how the database works (like setting the Id, which is auto-generated).
            //You create a new Employee object and assign values from the AddEmployeeDTO — this is called mapping.
            //Employee is the EF core entity that connect directly with the DB 

            var employeeEntity = new Employee()
            {
                // ID is not access here were it is maintained by the entity action core 
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary
            };

            DbContext.Employees.Add(employeeEntity);
            DbContext.SaveChanges(); // this is the process were all our actions will work
            return Ok(employeeEntity);


        }
      
    }
}
