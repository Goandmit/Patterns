namespace Patterns
{
    public static class AnimalFactory
    {
        public static IAnimal GetAnimal(string className, string animalType, string name, string foodType,
            string livingEnvironment)                                        
        {
            switch (className)
            {
                case $"{nameof(Mammals)}": return new Mammals(className, animalType, name, foodType, livingEnvironment);
                case $"{nameof(Amphibians)}": return new Amphibians(className, animalType, name, foodType, livingEnvironment);
                case $"{nameof(Birds)}": return new Birds(className, animalType, name, foodType, livingEnvironment);
                case $"{nameof(Animal)}": return new Animal(className, animalType, name, foodType, livingEnvironment);                
                default: return new Animal();
            }
        }
    }
}
