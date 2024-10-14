using System.Collections.Generic;

namespace Patterns
{
    public interface IView<T>
    {
        public List <T> Data { get; set; }        
    }
}
