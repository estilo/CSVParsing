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

        public bool DeleteEmployee(Employee record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(record);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<Employee>().List().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Save(Employee employee)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(employee);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public void Update(Employee employee)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(employee);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public void SaveOrUpdate(Employee employee)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(employee);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
