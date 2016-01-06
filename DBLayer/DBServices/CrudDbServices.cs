using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer.Models;
using NHibernate;

namespace DBLayer.DBServices
{
    public class CrudDbServices //: BaseDbService<>
    {
        private readonly ISessionFactory _sessionFactory;
        public CrudDbServices(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Employee FindEmployeeById(Guid recordId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        return session.QueryOver<Employee>().Where(t => t.Id == recordId).List().FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public bool DeleteEmployee(Employee record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(record);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {

                        return session.QueryOver<Employee>().List().ToList();
                        //IQuery query = session.CreateQuery("FROM Customers WHERE customer_id = " + customer_id);

                        //Customers customer = query.List<Customers>()[0];

                        //txtCustomerId.Text = customer.customer_id.ToString();
                        //txtName.Text = customer.name;
                        //txtEmail.Text = customer.email;
                        //txtContactPerson.Text = customer.contact_person;
                        //txtContactNumber.Text = customer.contact_number;
                        //txtPostalAddress.Text = customer.postal_address;
                        //txtPhysicalAddress.Text = customer.physical_address;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        //MessageBox.Show(ex.Message, "Exception Msg");
                    }
                }
            }
            return null;
        } 
    }
}
