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
    public class MailManager : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Create(Mail entity)
        {
            _mailDal.Create(entity);
        }

        public void Delete(Mail entity)
        {
            _mailDal.Delete(entity);
        }

        public List<Mail> GetAll(Expression<Func<Mail, bool>> filter = null)
        {
            return _mailDal.GetAll(filter);
        }

        public Mail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public void Update(Mail entity)
        {
            _mailDal.Update(entity);
        }
    }
}
