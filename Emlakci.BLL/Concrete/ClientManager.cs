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
    public class ClientManager : IClientService
    {
        private readonly IClientDal _clientDal;
        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }

        public void Create(Client entity)
        {
            _clientDal.Create(entity);
        }

        public void Delete(Client entity)
        {
            _clientDal.Delete(entity);
        }

        public List<Client> GetAll(Expression<Func<Client, bool>> filter = null)
        {
            return _clientDal.GetAll(filter);
        }

        public Client GetById(int id)
        {
            return _clientDal.GetById(id);
        }

        public void Update(Client entity)
        {
            _clientDal.Update(entity);
        }
    }
}
