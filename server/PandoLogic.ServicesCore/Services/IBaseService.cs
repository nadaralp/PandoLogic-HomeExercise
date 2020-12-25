using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoLogic.ServicesCore.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync();
    }
}