using System;
using System.Linq;

namespace AgroManager
{
    public class FieldService
    {
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

            if (farm.FieldsList.Any(field => field.FieldNumber == fieldNumber))
            {
                Console.WriteLine("Pole o podanym numerze już istnieje.");
                return;
            }

            Console.Write("Powierzchnia pola w hektarach (ha): ");
            if (double.TryParse(Console.ReadLine(), out double areaInHectares))
            {
                Field newField = new Field
                {
                    FieldNumber = fieldNumber,
                    AreaInHectares = areaInHectares
                };
                farm.FieldsList.Add(newField);

                Console.WriteLine("Nowe pole zostało dodane pomyślnie.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Niepoprawna wartość powierzchni pola. Spróbuj ponownie.");
            }
        }

        public void EditField(Farm farm)
        {
            Console.WriteLine("Edytuj pole:");
            Console.Write("Numer pola do edycji: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            Console.Write("Nowy numer pola: ");
            string? newFieldNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFieldNumber))
            {
                field.FieldNumber = newFieldNumber;
            }

            Console.Write("Nowa powierzchnia pola w hektarach (ha): ");
            if (double.TryParse(Console.ReadLine(), out double newAreaInHectares))
            {
                field.AreaInHectares = newAreaInHectares;
            }

            Console.WriteLine("Pole zostało zaktualizowane pomyślnie.");
        }

        public void RemoveField(Farm farm)
        {
            Console.WriteLine("Usuń pole:");
            Console.Write("Numer pola do usunięcia: ");
            string? fieldNumber = Console.ReadLine();
            Field? field = farm.FieldsList.Find(f => f.FieldNumber == fieldNumber);

            if (field == null)
            {
                Console.WriteLine("Pole o podanym numerze nie istnieje.");
                return;
            }

            farm.FieldsList.Remove(field);
            Console.WriteLine("Pole zostało usunięte pomyślnie.");
        }

        public void DisplayFieldsMenu(Farm farm)
        {
            Console.WriteLine("Przegląd pól:");
            int fieldChoice;
            do
            {
                Console.WriteLine("1. Wyświetl informacje o uprawach na polach");
                Console.WriteLine("2. Wyświetl informacje o zbiorach z pól");
                Console.WriteLine("3. Wyświetl informacje o przeprowadzonych zabiegach na polach");
                Console.WriteLine("4. Edytuj pole");
                Console.WriteLine("5. Usuń pole");
                Console.WriteLine("6. Powrót do menu głównego");
                Console.WriteLine();
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