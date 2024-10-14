using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Patterns
{
    public class Presenter
    {
        IView<IAnimal> _view;
        IModel<IAnimal> _model;

        public Presenter(IView<IAnimal> view)
        {
            _view = view;
            _model = new AnimalModel();
        }

        public void GetAll()
        {
            List<IAnimal> animals = _model.GetAll();
            _view.Data = animals;
        }

        public void Get(int id)
        {
            IAnimal animal = _model.Get(id);
            _view.Data.Add(animal);
        }

        public void Add()
        {
            if (_view.Data.Count > 0)
            {
                IAnimal animal = _view.Data.First();
                _model.Add(animal);
            }                       
        }

        public void Delete(int id)
        {
            _model.Delete(id);
        }

        public void Edit()
        {
            if (_view.Data.Count > 0)
            {
                IAnimal animal = _view.Data.First();
                _model.Edit(animal);
            }           
        }
    }
}
