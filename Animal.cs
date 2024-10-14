namespace Patterns
{
    public class Animal : IAnimal
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string LivingEnvironment { get; set; }        

        public Animal(string className, string animalType, string name, string foodType, string livingEnvironment)
        {
            ClassName = className;
            AnimalType = animalType;
            Name = name;
            FoodType = foodType;
            LivingEnvironment = livingEnvironment;
        }

        public Animal()
        {
            ClassName = $"{nameof(Animal)}";
            AnimalType = "Not Determined";
            Name = "Not Determined";
            FoodType = "Not Determined";
            LivingEnvironment = "Not Determined";
        }
    }
}
