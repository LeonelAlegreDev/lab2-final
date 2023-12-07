using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IDAO<T>
    {
        public Task<T> PostNew(T entity);
        public T GetById(int id);
        public List<T> GetAll();
        public bool UpdateById(int id, T entity);
        public bool DeleteById(int id);
    }
}