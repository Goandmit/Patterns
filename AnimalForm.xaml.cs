using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Patterns
{
    /// <summary>
    /// Логика взаимодействия для AnimalForm.xaml
    /// </summary>
    public partial class AnimalForm : Window, IView<IAnimal>
    {
        private Presenter _presenter;
        private int _id = -1;
        private string _className;

        public List<IAnimal> Data { get; set; } = new List<IAnimal>();

        public string Id { get { return id.Text; } set { id.Text = value; } }
        public string AnimalType { get { return animalType.Text; } set { animalType.Text = value; } }
        public string AnimalName { get { return animalName.Text; } set { animalName.Text = value; } }

        #region FoodType

        public bool Herbivores { get { return (bool)herbivores.IsChecked; } set { herbivores.IsChecked = value; } }
        public bool Carnivores { get { return (bool)carnivores.IsChecked; } set { carnivores.IsChecked = value; } }
        public bool Omnivores { get { return (bool)omnivores.IsChecked; } set { omnivores.IsChecked = value; } }
        public bool Insectivores { get { return (bool)insectivores.IsChecked; } set { insectivores.IsChecked = value; } }
        public bool Scavengers { get { return (bool)scavengers.IsChecked; } set { scavengers.IsChecked = value; } }

        #endregion        

        #region LivingEnvironment

        public bool GroundToAir { get { return (bool)groundToAir.IsChecked; } set { groundToAir.IsChecked = value; } }
        public bool Water { get { return (bool)water.IsChecked; } set { water.IsChecked = value; } }
        public bool Soil { get { return (bool)soil.IsChecked; } set { soil.IsChecked = value; } }

        #endregion

        public AnimalForm(int id)
        {
            InitializeComponent();

            _presenter = new Presenter(this);

            _id = id;

            Name = $"{nameof(AnimalForm)}{id}";
        }

        public AnimalForm(string className)
        {
            InitializeComponent();

            _presenter = new Presenter(this);
            _className = className;
            
            animalType.IsEnabled = true;

            Name = $"{nameof(AnimalForm)}";
        }

        public AnimalForm(string className, string animalType)
        {
            InitializeComponent();

            _presenter = new Presenter(this);
            _className = className;

            AnimalType = animalType;

            Name = $"{nameof(AnimalForm)}";
        }

        private void AnimalForm_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id != -1)
            {
                _presenter.Get(_id);
                FillForm();
            }            
        }        

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            IAnimal animal = GetFromForm();

            if (animal.AnimalType != "Not Determined")
            {
                EditOrAdd(animal);
                Close();
            }           
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            IAnimal animal = GetFromForm();

            if (animal.AnimalType != "Not Determined")
            {
                EditOrAdd(animal);                
            }
        }

        private void EditOrAdd(IAnimal animal)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                animal.Id = Convert.ToInt32(Id);
                Data.Add(animal);
                _presenter.Edit();
            }
            else
            {
                _presenter.Add();
                Id = animal.Id.ToString();
            }
        }

        private IAnimal GetFromForm()
        {
            IAnimal animal = new Animal();

            string foodType = GetFoodType();
            string environment = GetLivingEnvironment();
            bool fieldsAreFilled = CheckFields(foodType, environment);

            if (fieldsAreFilled)
            {
                animal = AnimalFactory.GetAnimal(_className, AnimalType, AnimalName, foodType, environment);
                Data = new List<IAnimal>() { animal };                
            }
            
            return animal;
        }

        private string EliminateNull(string userInput)
        {
            userInput = (userInput == null) ? String.Empty : userInput.Trim();

            return userInput;
        }

        private void PrepareFields()
        {
            AnimalType = EliminateNull(AnimalType);
            AnimalName = EliminateNull(AnimalName);            
        }

        private bool CheckFields(string foodType, string environment)
        {
            bool fieldsAreFilled = true;

            PrepareFields();

            if (AnimalType.Length == 0 || AnimalName.Length == 0 || foodType.Length == 0 || environment.Length == 0)
            {
                fieldsAreFilled = false;
                WindowsManager.ShowErrorMessageBox("Перед записью должны быть введены все данные");
            }

            return fieldsAreFilled;
        }

        private void FillForm()
        {
            IAnimal animal = Data.First();

            if (animal != null)
            {
                _className = animal.ClassName;
                Id = animal.Id.ToString();                
                AnimalType = animal.AnimalType;
                AnimalName = animal.Name;
                SetFoodType(animal.FoodType);
                SetLivingEnvironment(animal.LivingEnvironment);
            }
        }

        private string GetFoodType()
        {
            string foodType = String.Empty;

            if (Herbivores == true)
            {
                foodType = herbivores.Content.ToString();
            }
            else if (Carnivores == true)
            {
                foodType = carnivores.Content.ToString();
            }
            else if (Omnivores == true)
            {
                foodType = omnivores.Content.ToString();
            }
            else if (Insectivores == true)
            {
                foodType = insectivores.Content.ToString();
            }
            else if (Scavengers == true)
            {
                foodType = scavengers.Content.ToString(); ;
            }

            return foodType;
        }

        private void SetFoodType(string foodType)
        {
            if (foodType == herbivores.Content.ToString())
            {
                Herbivores = true;
            }
            else if (foodType == carnivores.Content.ToString())
            {
                Carnivores = true;
            }
            else if (foodType == omnivores.Content.ToString())
            {
                Omnivores = true;
            }
            else if (foodType == insectivores.Content.ToString())
            {
                Insectivores = true;
            }
            else if (foodType == scavengers.Content.ToString())
            {
                Scavengers = true;
            }
        }

        private string GetLivingEnvironment()
        {
            string environment = String.Empty;

            if (GroundToAir == true)
            {
                environment = groundToAir.Content.ToString();
            }
            else if (Water == true)
            {
                environment = water.Content.ToString();
            }
            else if (Soil == true)
            {
                environment = soil.Content.ToString();
            }

            return environment;
        }

        private void SetLivingEnvironment(string environment)
        {
            if (environment == groundToAir.Content.ToString())
            {
                GroundToAir = true;
            }
            else if (environment == water.Content.ToString())
            {
                Water = true;
            }
            else if (environment == soil.Content.ToString())
            {
                Soil = true;
            }
        }        
    }
}
