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
    public class WhoWeAreManager : IWhoWeAreService
    {
        private readonly IWhoWeAreDal _whoWeAreDal;

        public WhoWeAreManager(IWhoWeAreDal whoWeAreDal)
        {
            _whoWeAreDal = whoWeAreDal;
        }

        public void Create(WhoWeAre entity)
        {
            _whoWeAreDal.Create(entity);
        }

        public void Delete(WhoWeAre entity)
        {
            _whoWeAreDal.Delete(entity);
        }

        public List<WhoWeAre> GetAll(Expression<Func<WhoWeAre, bool>> filter = null)
        {
            return _whoWeAreDal.GetAll(filter);
        }

        public WhoWeAre GetById(int id)
        {
            return _whoWeAreDal.GetById(id);
        }

        public void Update(WhoWeAre entity)
        {
            _whoWeAreDal.Update(entity);
        }
    }
}
