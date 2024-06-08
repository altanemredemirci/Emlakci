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
    public class TodoListManager : ITodoListService
    {
        private readonly ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public void Create(TodoList entity)
        {
            _todoListDal.Create(entity);
        }

        public void Delete(TodoList entity)
        {
            _todoListDal.Delete(entity);
        }

        public List<TodoList> GetAll(Expression<Func<TodoList, bool>> filter = null)
        {
            return _todoListDal.GetAll(filter);
        }

        public TodoList GetById(int id)
        {
            return _todoListDal.GetById(id);
        }

        public void Update(TodoList entity)
        {
            _todoListDal.Update(entity);
        }
    }
}
