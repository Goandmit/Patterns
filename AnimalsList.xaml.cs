using System.Collections.Generic;
using System.Windows;

namespace Patterns
{
    /// <summary>
    /// Логика взаимодействия для AnimalsList.xaml
    /// </summary>
    public partial class AnimalsList : Window, IView<IAnimal>
    {
        private Presenter _presenter;

        public List<IAnimal> Data { get; set; } = new List<IAnimal>();
        
        public string SaveStatus { get { return saveStatus.Text; } set { saveStatus.Text = value; } }

        public AnimalsList()
        {
            InitializeComponent();
            _presenter = new Presenter(this);

            Name = $"{nameof(AnimalsList)}";
        }   

        private void AnimalsList_Loaded(object sender, RoutedEventArgs e)
        {
            _presenter.GetAll();
            FillAnimalsList();
        }

        private void Create_Click(object sender, RoutedEventArgs e) => WindowsManager.ShowCreateAnimalForm(Name);
       

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty($"{Animals.SelectedItem as IAnimal}"))
            {
                int id = (Animals.SelectedItem as IAnimal).Id;

                _presenter.Delete(id);

                UpdateAnimalsList();
            }            
        }

        private void OpenAnimalForm_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty($"{Animals.SelectedItem as IAnimal}"))
            {
                int id = (Animals.SelectedItem as IAnimal).Id;

                WindowsManager.ShowAnimalForm(id, Name);
            }
        }

        private void SaveTxt_Click(object sender, RoutedEventArgs e) => SaveStatus = FileWriterManager.WriteToTxt();
        
        private void SavePdf_Click(object sender, RoutedEventArgs e) => SaveStatus = FileWriterManager.WriteToPdf();
       
        private void SaveWord_Click(object sender, RoutedEventArgs e) => SaveStatus = FileWriterManager.WriteToWord();
        

        public void UpdateAnimalsList()
        {
            Animals.Items.Clear();
            _presenter.GetAll();
            FillAnimalsList();
            SaveStatus = "Сохранить в формате: ";
        }

        private void FillAnimalsList()
        {
            if (Data.Count > 0)
            {
                foreach (IAnimal animal in Data)
                {
                    Animals.Items.Add(animal);
                }
            }
        }        
    }
}
