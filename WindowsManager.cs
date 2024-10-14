using System;
using System.Windows;

namespace Patterns
{
    public static class WindowsManager
    {
        public static void ShowCreateAnimalForm(string ownerWindowName)
        {
            bool alreadyOpen = AlreadyOpenCheck($"{nameof(CreateAnimalForm)}");

            if (!alreadyOpen)
            {
                CreateAnimalForm window = new CreateAnimalForm();

                SetOwner(window, ownerWindowName);

                window.Show();
            }            
        }

        public static void ShowAnimalForm(int id, string ownerWindowName)
        {
            bool alreadyOpen = AlreadyOpenCheck($"{nameof(AnimalForm)}{id}");

            if (!alreadyOpen)
            {
                AnimalForm window = new AnimalForm(id);

                SetOwner(window, ownerWindowName);

                window.Show();

                window.Closed += AnimalForm_Closed;
            }            
        }

        public static void ShowNewAnimalForm(string animalClass, string animalType, string ownerWindowName)
        {
            bool alreadyOpen = AlreadyOpenCheck($"{nameof(AnimalForm)}");

            if (!alreadyOpen)
            {
                AnimalForm window;

                if (animalType.Length == 0)
                {
                    window = new AnimalForm(animalClass);
                }
                else
                {
                    window = new AnimalForm(animalClass, animalType);
                }

                SetOwner(window, ownerWindowName);

                window.Show();               

                window.Closed += AnimalForm_Closed;
            }
        }

        public static bool AlreadyOpenCheck(string windowName)
        {
            bool alreadyOpen = false;

            foreach (Window window in App.Current.Windows)
            {
                if (window.Name == windowName)
                {
                    alreadyOpen = true;
                    break;
                }
            }

            return alreadyOpen;
        }

        public static void SetOwner(Window window, string ownerWindowName)
        {
            foreach (Window ownerWindow in App.Current.Windows)
            {
                if (ownerWindow.Name == ownerWindowName)
                {
                    window.Owner = ownerWindow;
                    break;
                }
            }
        }

        private static void AnimalForm_Closed(object sender, EventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is AnimalsList)
                {
                    (window as AnimalsList).UpdateAnimalsList();
                    break;
                }
            }
        }

        public static void ShowErrorMessageBox(string text)
        {
            MessageBox.Show(text,
                        "Операция не выполнена",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error,
                        MessageBoxResult.OK,
                        MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
