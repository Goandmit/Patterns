using System.Collections.Generic;

namespace Patterns
{
    public interface IModel<T>
    {
        public List<T> GetAll();

        public T Get(int id);

        public void Add(T entity);

        public void Delete(int id);

        public void Edit(T entity);

        public List<string> GetAllInTextFormat();
    }
}
