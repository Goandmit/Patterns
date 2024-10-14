using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public class AnimalModel : IModel<IAnimal>
    {
        public AnimalModel() { }

        public List<IAnimal> GetAll()
        {
            List<IAnimal> animals = new List<IAnimal>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var animalsDB = db.Animals.ToList();

                foreach (var animal in animalsDB)
                {
                    animals.Add(animal);
                }
            }

            return animals;
        }

        public IAnimal Get(int id)
        {
            IAnimal animal = new Animal();

            using (ApplicationContext db = new ApplicationContext())
            {
                var animalsDB = db.Animals.Where(p => p.Id == id).ToList();

                if(animalsDB.Count > 0)
                {
                    animal = animalsDB.First();
                }                
            }

            return animal;
        }

        public void Add(IAnimal animal)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Animals.Add((Animal)animal);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var animalsDB = db.Animals.Where(p => p.Id == id).ToList();

                db.Animals.Remove(animalsDB.First());
                db.SaveChanges();
            }
        }

        public void Edit(IAnimal animal)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var animalsDB = db.Animals.Where(p => p.Id == animal.Id).ToList();                

                bool propertyChanged = false;

                if (animalsDB[0].AnimalType != animal.AnimalType)
                {
                    animalsDB[0].AnimalType = animal.AnimalType;
                    propertyChanged = true;
                }

                if (animalsDB[0].Name != animal.Name)
                {
                    animalsDB[0].Name = animal.Name;
                    propertyChanged = true;
                }

                if (animalsDB[0].FoodType != animal.FoodType)
                {
                    animalsDB[0].FoodType = animal.FoodType;
                    propertyChanged = true;
                }

                if (animalsDB[0].LivingEnvironment != animal.LivingEnvironment)
                {
                    animalsDB[0].LivingEnvironment = animal.LivingEnvironment;
                    propertyChanged = true;
                }

                if (propertyChanged == true)
                {
                    db.Animals.Update(animalsDB[0]);
                    db.SaveChanges();
                }
            }
        }

        public List<string> ConvertToText(IAnimal animal)
        {
            List<string> text = new List<string>()
            {
                $"Идентификатор: {animal.Id}",
                $"Наименование животного: {animal.Name}",
                $"Относится к классу: {animal.AnimalType}",
                $"Тип питания: {animal.FoodType}",
                $"Среда обитания: {animal.LivingEnvironment}",
                $""
            };            

            return text;
        }

        public List<string> ConvertAllToText(List<IAnimal> animals)
        {
            List<string> text = new List<string>();
            
            foreach (IAnimal animal in animals)
            {
                List<string> animalText = ConvertToText(animal);

                foreach (string line in animalText)
                {
                    text.Add(line);
                }
            }

            return text;
        }

        public List<string> GetAllInTextFormat()
        {
            List<IAnimal> animals = GetAll();

            List<string> text = ConvertAllToText(animals);

            return text;
        }
    }
}
