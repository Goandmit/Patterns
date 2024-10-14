using System;
using System.Windows;

namespace Patterns
{
    /// <summary>
    /// Логика взаимодействия для CreateAnimalForm.xaml
    /// </summary>
    public partial class CreateAnimalForm : Window
    {
        public bool MS { get { return (bool)mammals.IsChecked; } }
        public bool BS { get { return (bool)birds.IsChecked; } }
        public bool AS { get { return (bool)amphibians.IsChecked; } }
        public bool AR { get { return (bool)another.IsChecked; } }

        public CreateAnimalForm()
        {
            InitializeComponent();

            Name = $"{nameof(CreateAnimalForm)}";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string className = GetClassName();
            string animalType = GetAnimalType();

            if (className.Length > 0)
            {
                WindowsManager.ShowNewAnimalForm(className, animalType, Owner.Name);

                Close();
            }            
        }

        private string GetClassName()
        {
            string className = String.Empty;

            if (MS == true)
            {
                className = $"{nameof(Mammals)}";
            }
            else if (BS == true)
            {
                className = $"{nameof(Birds)}";
            }
            else if (AS == true)
            {
                className = $"{nameof(Amphibians)}";
            }
            else if (AR == true)
            {
                className = $"{nameof(Animal)}";
            }

            return className;
        }

        private string GetAnimalType()
        {
            string animalType = String.Empty;

            if (MS == true)
            {
                animalType = $"{mammals.Content}";
            }
            else if (BS == true)
            {
                animalType = $"{birds.Content}";
            }
            else if (AS == true)
            {
                animalType = $"{amphibians.Content}";
            }            

            return animalType;
        }
    }
}
