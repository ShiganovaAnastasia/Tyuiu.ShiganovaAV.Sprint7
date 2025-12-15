
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib
{
        public class DataService
        {
        public class Apartment
        {
            public int EntranceNumber { get; set; }       // Номер подъезда
            public int ApartmentNumber { get; set; }      // Номер квартиры
            public double TotalArea { get; set; }         // Общая площадь (м²)
            public double LivingArea { get; set; }        // Полезная площадь (м²)
            public int RoomsCount { get; set; }           // Количество комнат
            public string TenantSurname { get; set; }     // Фамилия квартиросъемщика
            public DateTime RegistrationDate { get; set; } // Дата прописки
            public int FamilyMembers { get; set; }        // Количество членов семьи
            public int ChildrenCount { get; set; }        // Количество детей в семье
            public bool HasDebt { get; set; }             // Есть ли задолженность
            public string Notes { get; set; }             // Примечание

            public Apartment() { }

            public Apartment(int entrance, int aptNumber, double totalArea,
                            double livingArea, int rooms, string surname,
                            DateTime regDate, int family, int children,
                            bool debt, string notes)
            {
                EntranceNumber = entrance;
                ApartmentNumber = aptNumber;
                TotalArea = totalArea;
                LivingArea = livingArea;
                RoomsCount = rooms;
                TenantSurname = surname;
                RegistrationDate = regDate;
                FamilyMembers = family;
                ChildrenCount = children;
                HasDebt = debt;
                Notes = notes;
            }
        }
            public List<Apartment> LoadFromFile(string path)
            {
                List<Apartment> apartments = new List<Apartment>();

                if (!File.Exists(path))
                    throw new FileNotFoundException($"Файл не найден: {path}");

                string[] lines = File.ReadAllLines(path);

                for (int i = 1; i < lines.Length; i++) // Пропускаем заголовок
                {
                    string[] parts = lines[i].Split(';');
                    if (parts.Length >= 11)
                    {
                        Apartment apt = new Apartment
                        {
                            EntranceNumber = int.Parse(parts[0]),
                            ApartmentNumber = int.Parse(parts[1]),
                            TotalArea = double.Parse(parts[2]),
                            LivingArea = double.Parse(parts[3]),
                            RoomsCount = int.Parse(parts[4]),
                            TenantSurname = parts[5],
                            RegistrationDate = DateTime.Parse(parts[6]),
                            FamilyMembers = int.Parse(parts[7]),
                            ChildrenCount = int.Parse(parts[8]),
                            HasDebt = bool.Parse(parts[9]),
                            Notes = parts[10]
                        };
                        apartments.Add(apt);
                    }
                }
                return apartments;
            }

            public void SaveToFile(string path, List<Apartment> apartments)
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    // Заголовок CSV
                    writer.WriteLine("Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;" +
                                    "Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание");

                    foreach (var apt in apartments)
                    {
                        writer.WriteLine($"{apt.EntranceNumber};{apt.ApartmentNumber};" +
                                        $"{apt.TotalArea};{apt.LivingArea};{apt.RoomsCount};" +
                                        $"{apt.TenantSurname};{apt.RegistrationDate:dd.MM.yyyy};" +
                                        $"{apt.FamilyMembers};{apt.ChildrenCount};" +
                                        $"{apt.HasDebt};{apt.Notes}");
                    }
                }
            }

            public List<Apartment> SearchBySurname(List<Apartment> apartments, string surname)
            {
                return apartments.Where(a => a.TenantSurname.Contains(surname, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Apartment> FilterByDebt(List<Apartment> apartments, bool hasDebt)
            {
                return apartments.Where(a => a.HasDebt == hasDebt).ToList();
            }

            public List<Apartment> FilterByEntrance(List<Apartment> apartments, int entrance)
            {
                return apartments.Where(a => a.EntranceNumber == entrance).ToList();
            }

            public List<Apartment> SortByApartmentNumber(List<Apartment> apartments, bool ascending = true)
            {
                return ascending ?
                    apartments.OrderBy(a => a.ApartmentNumber).ToList() :
                    apartments.OrderByDescending(a => a.ApartmentNumber).ToList();
            }

            public List<Apartment> SortByArea(List<Apartment> apartments, bool ascending = true)
            {
                return ascending ?
                    apartments.OrderBy(a => a.TotalArea).ToList() :
                    apartments.OrderByDescending(a => a.TotalArea).ToList();
            }

            // Статистика
            public Dictionary<string, object> GetStatistics(List<Apartment> apartments)
            {
                var stats = new Dictionary<string, object>();

                if (apartments.Count == 0) return stats;

                stats["КоличествоКвартир"] = apartments.Count;
                stats["ОбщаяПлощадьВсех"] = apartments.Sum(a => a.TotalArea);
                stats["СредняяПлощадь"] = apartments.Average(a => a.TotalArea);
                stats["МаксПлощадь"] = apartments.Max(a => a.TotalArea);
                stats["МинПлощадь"] = apartments.Min(a => a.TotalArea);
                stats["КоличествоДолжников"] = apartments.Count(a => a.HasDebt);
                stats["ВсегоДетей"] = apartments.Sum(a => a.ChildrenCount);
                stats["ВсегоЧленовСемьи"] = apartments.Sum(a => a.FamilyMembers);
                stats["СреднийРазмерСемьи"] = apartments.Average(a => a.FamilyMembers);
                stats["КоличествоКомнатВсего"] = apartments.Sum(a => a.RoomsCount);

                return stats;
            }

            // Для графика: распределение квартир по подъездам
            public Dictionary<int, int> GetApartmentsByEntrance(List<Apartment> apartments)
            {
                return apartments.GroupBy(a => a.EntranceNumber)
                                .ToDictionary(g => g.Key, g => g.Count());
            }

            // Для графика: распределение по количеству комнат
            public Dictionary<int, int> GetApartmentsByRooms(List<Apartment> apartments)
            {
                return apartments.GroupBy(a => a.RoomsCount)
                                .ToDictionary(g => g.Key, g => g.Count());
            }
        }
    }
