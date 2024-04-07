using Emlakci.BLL.Abstract;
using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Concrete
{
    public class EmploymentManager : IEmploymentService
    {
        private readonly IEmploymentDal _employmentDal;

        public EmploymentManager(IEmploymentDal employmentDal)
        {
            _employmentDal = employmentDal;
        }
        public void Create(Employment entity)
        {
            _employmentDal.Create(entity);
        }

        public void Delete(Employment entity)
        {
            _employmentDal.Delete(entity);
        }

        public List<Employment> GetAll(Expression<Func<Employment, bool>> filter = null)
        {
            return _employmentDal.GetAll(filter);
        }

        public Employment GetById(int id)
        {
            return _employmentDal.GetById(id);
        }

        public void Update(Employment entity)
        {
            _employmentDal.Update(entity);
        }
    }
}
