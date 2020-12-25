using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandoLogic.Core.Repositories;
using PandoLogic.Infrastructure.EntityFramework;

namespace PandoLogic.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Entities;

        public BaseRepository(DbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> ToListAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicatExpression)
        {
            return await Entities.FirstOrDefaultAsync(predicatExpression);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicatExpression)
        {
            return await Entities.Where(predicatExpression).ToListAsync();
        }
    }
}