using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBLayer;
using DBLayer.DBServices;
using DBLayer.Models;
using NHibernate;

namespace RESTApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private ISessionFactory sessionFactory;
        private CrudDbServices crudDbServices;

        public EmployeeController()
        {
            sessionFactory = Plumbing.CreateSessionFactory();
            crudDbServices = new CrudDbServices(sessionFactory);
        }
        
        /// <summary>
        /// List all employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return crudDbServices.GetAllEmployees().AsEnumerable();
        }


        /// <summary>
        /// Get employee by employee Id
        /// </summary>
        /// <param name="id">Id of the employee to be searched: Guid/UUID</param>
        /// <returns></returns>
        public IHttpActionResult GetEmployee(Guid id)
        {
            var employee = crudDbServices.FindEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Method to insert/save employee record
        /// </summary>
        /// <param name="employee">Employee records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage PostEmployee(Employee employee)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                crudDbServices.Save(employee);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to update employee
        /// </summary>
        /// <param name="employee">Employee record to be updated</param>
        /// <returns></returns>
        public IHttpActionResult PutEmployee(Employee employee)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedEmployee = crudDbServices.FindEmployeeById(employee.Id);
                if (employee == null)
                {
                    return BadRequest("Cannot update employee not found");
                }
                crudDbServices.Update(searchedEmployee);
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = searchedEmployee.Id }));
                //return response;
                return Ok();
            }
            else
            {
                return BadRequest();
                //return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to remove/delete employee
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns></returns>
        public IHttpActionResult DeleteEmployee(Guid id)
        {
            try
            {
                var employee = crudDbServices.FindEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                crudDbServices.DeleteEmployee(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
