using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public interface IRepository
    {
        Task<bool> Add(ToDo toDo);
        Task<bool> Update(ToDo toDo);
        Task<bool> Delete(int id);
        Task<List<ToDo>> GetAll();
        Task<ToDo> Get(int id);
        Task<List<ToDo>> GetByUser(string userId);

    }
}
