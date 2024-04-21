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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Create(Contact entity)
        {
            _contactDal.Create(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);

        }

        public List<Contact> GetAll(Expression<Func<Contact, bool>> filter = null)
        {
            return _contactDal.GetAll(filter);
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
