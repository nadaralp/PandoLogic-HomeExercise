using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PandoLogic.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> ToListAsync();

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicatExpression);

        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicatExpression);
    }
}