using AgroManager.Models;
using AgroManager.Services;
using System;

namespace AgroManager.Managers
{
    public class FieldManager
    {
        private readonly FieldService _fieldService;

        public FieldManager(FieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public void DisplayFieldsWithCrops(Farm farm)
        {
            Console.WriteLine("Lista pól z powierzchnią i aktualną uprawą:");

            foreach (var field in farm.FieldsList)
            {
                Console.WriteLine($"Pole numer: {field.FieldNumber}, Powierzchnia: {field.AreaInHectares} ha");

                if (field.Crops.Count > 0)
                {
                    var latestCrop = field.Crops.Last();
                    Console.WriteLine($"Aktualna uprawa: {latestCrop.CropType}, Data siewu: {latestCrop.SowingDate.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("Brak aktualnej uprawy na tym polu.");
                }

                Console.WriteLine();
            }
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
                Console.WriteLine("1. Wyświetl listę pól z powierzchnią i aktualną uprawą");
                Console.WriteLine("2. Wyświetl informacje o uprawach na polach");
                Console.WriteLine("3. Wyświetl informacje o zbiorach z pól");
                Console.WriteLine("4. Wyświetl informacje o przeprowadzonych zabiegach na polach");
                Console.WriteLine("5. Edytuj pole");
                Console.WriteLine("6. Usuń pole");
                Console.WriteLine("7. Powrót do menu głównego");
                Console.Write("Wybierz opcję: ");

                if (int.TryParse(Console.ReadLine(), out fieldChoice))
                {
                    switch (fieldChoice)
                    {
                        case 1:
                            DisplayFieldsWithCrops(farm);
                            break;
                        case 2:
                            new CropService().DisplayCropsInfo(farm);
                            break;
                        case 3:
                            new HarvestService().DisplayHarvestsInfo(farm);
                            break;
                        case 4:
                            new TreatmentService().DisplayTreatmentsInfo(farm);
                            break;
                        case 5:
                            EditField(farm);
                            break;
                        case 6:
                            RemoveField(farm);
                            break;
                        case 7:
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
            } while (fieldChoice != 7);
        }
    }
}