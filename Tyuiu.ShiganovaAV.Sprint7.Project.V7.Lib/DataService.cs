using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib
{
    public class DataService
    {
        public class Apartment
        {
            public int EntranceNumber { get; set; }
            public int ApartmentNumber { get; set; }
            public double TotalArea { get; set; }
            public double LivingArea { get; set; }
            public int RoomsCount { get; set; }
            public string TenantSurname { get; set; }
            public DateTime RegistrationDate { get; set; }
            public int FamilyMembers { get; set; }
            public int ChildrenCount { get; set; }
            public bool HasDebt { get; set; }
            public string Notes { get; set; }
        }

        public List<Apartment> LoadFromFile(string filePath)
        {
            List<Apartment> apartments = new List<Apartment>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // Пропускаем заголовок
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(';');

                    if (data.Length >= 10)
                    {
                        Apartment apartment = new Apartment
                        {
                            EntranceNumber = int.Parse(data[0]),
                            ApartmentNumber = int.Parse(data[1]),
                            TotalArea = double.Parse(data[2], CultureInfo.InvariantCulture),
                            LivingArea = double.Parse(data[3], CultureInfo.InvariantCulture),
                            RoomsCount = int.Parse(data[4]),
                            TenantSurname = data[5],
                            RegistrationDate = DateTime.ParseExact(data[6], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                            FamilyMembers = int.Parse(data[7]),
                            ChildrenCount = int.Parse(data[8]),
                            HasDebt = bool.Parse(data[9]),
                            Notes = data.Length > 10 ? data[10] : ""
                        };

                        apartments.Add(apartment);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке файла: {ex.Message}");
            }

            return apartments;
        }

        public void SaveToFile(string filePath, List<Apartment> apartments)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание");

                    foreach (var apt in apartments)
                    {
                        writer.WriteLine($"{apt.EntranceNumber};{apt.ApartmentNumber};{apt.TotalArea.ToString("F1", CultureInfo.InvariantCulture)};" +
                                         $"{apt.LivingArea.ToString("F1", CultureInfo.InvariantCulture)};{apt.RoomsCount};{apt.TenantSurname};" +
                                         $"{apt.RegistrationDate:dd.MM.yyyy};{apt.FamilyMembers};{apt.ChildrenCount};{apt.HasDebt};{apt.Notes}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        public Dictionary<string, double> GetStatistics(List<Apartment> apartments)
        {
            if (apartments == null || apartments.Count == 0)
            {
                return new Dictionary<string, double>
                {
                    ["КоличествоКвартир"] = 0,
                    ["ОбщаяПлощадьВсех"] = 0,
                    ["СредняяПлощадь"] = 0,
                    ["МаксПлощадь"] = 0,
                    ["МинПлощадь"] = 0,
                    ["КоличествоДолжников"] = 0,
                    ["ВсегоДетей"] = 0,
                    ["ВсегоЧленовСемьи"] = 0,
                    ["СреднийРазмерСемьи"] = 0,
                    ["КоличествоКомнатВсего"] = 0
                };
            }

            return new Dictionary<string, double>
            {
                ["КоличествоКвартир"] = apartments.Count,
                ["ОбщаяПлощадьВсех"] = apartments.Sum(a => a.TotalArea),
                ["СредняяПлощадь"] = apartments.Average(a => a.TotalArea),
                ["МаксПлощадь"] = apartments.Max(a => a.TotalArea),
                ["МинПлощадь"] = apartments.Min(a => a.TotalArea),
                ["КоличествоДолжников"] = apartments.Count(a => a.HasDebt),
                ["ВсегоДетей"] = apartments.Sum(a => a.ChildrenCount),
                ["ВсегоЧленовСемьи"] = apartments.Sum(a => a.FamilyMembers),
                ["СреднийРазмерСемьи"] = apartments.Average(a => a.FamilyMembers),
                ["КоличествоКомнатВсего"] = apartments.Sum(a => a.RoomsCount)
            };
        }

        public List<Apartment> SearchBySurname(List<Apartment> apartments, string surname)
        {
            return apartments
                .Where(a => a.TenantSurname.ToLower().Contains(surname.ToLower()))
                .ToList();
        }

        public List<Apartment> FilterByEntrance(List<Apartment> apartments, int entrance)
        {
            return apartments
                .Where(a => a.EntranceNumber == entrance)
                .ToList();
        }

        public List<Apartment> FilterByDebt(List<Apartment> apartments, bool hasDebt)
        {
            return apartments
                .Where(a => a.HasDebt == hasDebt)
                .ToList();
        }

        public List<Apartment> SortByApartmentNumber(List<Apartment> apartments, bool ascending)
        {
            return ascending
                ? apartments.OrderBy(a => a.ApartmentNumber).ToList()
                : apartments.OrderByDescending(a => a.ApartmentNumber).ToList();
        }

        // Метод для получения данных для графиков по подъездам
        public Dictionary<int, Dictionary<string, double>> GetEntranceStatistics(List<Apartment> apartments)
        {
            var result = new Dictionary<int, Dictionary<string, double>>();

            var groups = apartments.GroupBy(a => a.EntranceNumber);

            foreach (var group in groups)
            {
                result[group.Key] = new Dictionary<string, double>
                {
                    ["Квартир"] = group.Count(),
                    ["ОбщаяПлощадь"] = group.Sum(a => a.TotalArea),
                    ["ЖилаяПлощадь"] = group.Sum(a => a.LivingArea),
                    ["Жильцов"] = group.Sum(a => a.FamilyMembers),
                    ["Детей"] = group.Sum(a => a.ChildrenCount),
                    ["Должников"] = group.Count(a => a.HasDebt),
                    ["Комнат"] = group.Sum(a => a.RoomsCount)
                };
            }

            return result;
        }
    }
}