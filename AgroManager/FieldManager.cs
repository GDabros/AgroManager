using System;

namespace AgroManager
{
    public class FieldManager
    {
        private readonly FieldService _fieldService;

        public FieldManager(FieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public void AddField(Farm farm)
        {
            Console.WriteLine("Dodaj nowe pole:");
            Console.Write("Numer pola: ");
            string? fieldNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fieldNumber))
            {
                Console.WriteLine("Numer pola nie może być pusty. Spróbuj ponownie.");
                return;
            }

            Console.Write("Powierzchnia pola w hektarach (ha): ");
            if (double.TryParse(Console.ReadLine(), out double areaInHectares))
            {
                if (_fieldService.AddField(farm, fieldNumber, areaInHectares))
                {
                    Console.WriteLine("Nowe pole zostało dodane pomyślnie.");
                }
                else
                {
                    Console.WriteLine("Pole o podanym numerze już istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawna wartość powierzchni pola.");
            }
        }

        public void EditField(Farm farm)
        {
            Console.WriteLine("Edytuj pole:");
            Console.Write("Numer pola do edycji: ");
            string? fieldNumber = Console.ReadLine();

            Console.Write("Nowy numer pola (pozostaw puste, aby nie zmieniać): ");
            string? newFieldNumber = Console.ReadLine();

            Console.Write("Nowa powierzchnia pola w hektarach (pozostaw puste, aby nie zmieniać): ");
            if (double.TryParse(Console.ReadLine(), out double newAreaInHectares))
            {
                if (_fieldService.EditField(farm, fieldNumber, newFieldNumber, newAreaInHectares))
                {
                    Console.WriteLine("Pole zostało zaktualizowane pomyślnie.");
                }
                else
                {
                    Console.WriteLine("Pole o podanym numerze nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawna wartość powierzchni pola.");
            }
        }

        public void RemoveField(Farm farm)
        {
            Console.WriteLine("Usuń pole:");
            Console.Write("Numer pola do usunięcia: ");
            string? fieldNumber = Console.ReadLine();

            if (_fieldService.RemoveField(farm, fieldNumber))
            {
                Console.WriteLine("Pole zostało usunięte pomyślnie.");
            }
            else
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
            }
        }

        public void DisplayFieldsMenu(Farm farm)
        {
            int fieldChoice;
            do
            {
                Console.WriteLine("1. Wyświetl informacje o uprawach na polach");
                Console.WriteLine("2. Wyświetl informacje o zbiorach z pól");
                Console.WriteLine("3. Wyświetl informacje o przeprowadzonych zabiegach na polach");
                Console.WriteLine("4. Edytuj pole");
                Console.WriteLine("5. Usuń pole");
                Console.WriteLine("6. Powrót do menu głównego");
                Console.Write("Wybierz opcję: ");

                if (int.TryParse(Console.ReadLine(), out fieldChoice))
                {
                    switch (fieldChoice)
                    {
                        case 1:
                            new CropService().DisplayCropsInfo(farm);
                            break;
                        case 2:
                            new HarvestService().DisplayHarvestsInfo(farm);
                            break;
                        case 3:
                            new TreatmentService().DisplayTreatmentsInfo(farm);
                            break;
                        case 4:
                            EditField(farm);
                            break;
                        case 5:
                            RemoveField(farm);
                            break;
                        case 6:
                            Console.WriteLine("Powrót do menu głównego.");
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                }
            } while (fieldChoice != 6);
        }
    }
}