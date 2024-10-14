namespace Patterns
{
    public interface IAnimal
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }        
        public string FoodType { get; set; }
        public string LivingEnvironment { get; set; }
    }
}
