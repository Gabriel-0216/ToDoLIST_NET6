using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;
        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ToDo toDo)
        {
            _context.Add(toDo);
            await _context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> Delete(int id)
        {
           var entity = _context.ToDos.First(prop=> prop.Id == id);
            if(entity != null)
            {
                _context.Remove(entity);
                return true;
            }
            return false;

        }

        public async Task<ToDo> Get(int id)
        {
            var entity = _context.ToDos.First(p => p.Id == id);
            return entity;
        }

        public async Task<List<ToDo>> GetAll()
        {
            var entity = await _context.ToDos.AsNoTracking().ToListAsync();
            return entity;
        }

        public async Task<List<ToDo>> GetByUser(string userId)
        {
            var list = await _context.ToDos.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
            return list;
        }

        public async Task<bool> Update(ToDo toDo)
        {
            _context.Update(toDo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
