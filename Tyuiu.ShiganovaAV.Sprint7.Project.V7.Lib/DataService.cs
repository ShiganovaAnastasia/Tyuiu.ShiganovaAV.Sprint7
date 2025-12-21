using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib
{
    public class Apartment
    {
        public int Entrance { get; set; }
        public int Number { get; set; }
        public double TotalArea { get; set; }
        public double LivingArea { get; set; }
        public int Rooms { get; set; }
        public string Surname { get; set; }
        public DateTime RegDate { get; set; }
        public int Family { get; set; }
        public int Children { get; set; }
        public bool Debt { get; set; }
        public string Notes { get; set; }
    }

    public class Stats
    {
        public int Apartments { get; set; }
        public double TotalArea { get; set; }
        public double LivingArea { get; set; }
        public int Residents { get; set; }
        public int Children { get; set; }
        public int Debtors { get; set; }
        public int Rooms { get; set; }
    }

    public class DataService
    {
        public List<Apartment> Load(string path)
        {
            var list = new List<Apartment>();

            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден", path);

            var lines = File.ReadAllLines(path);

            int startIndex = lines[0].Contains("Подъезд") ? 1 : 0;

            for (int i = startIndex; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var parts = lines[i].Split(';');
                if (parts.Length < 10) continue;

                try
                {
                    var apartment = new Apartment
                    {
                        Entrance = int.Parse(parts[0].Trim()),
                        Number = int.Parse(parts[1].Trim()),
                        TotalArea = double.Parse(parts[2].Trim().Replace(',', '.'), CultureInfo.InvariantCulture),
                        LivingArea = double.Parse(parts[3].Trim().Replace(',', '.'), CultureInfo.InvariantCulture),
                        Rooms = int.Parse(parts[4].Trim()),
                        Surname = parts[5].Trim(),
                        RegDate = DateTime.ParseExact(parts[6].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        Family = int.Parse(parts[7].Trim()),
                        Children = int.Parse(parts[8].Trim()),
                        Debt = bool.Parse(parts[9].Trim().ToLower()),
                        Notes = parts.Length > 10 ? parts[10].Trim() : ""
                    };

                    if (apartment.LivingArea > apartment.TotalArea)
                        throw new ArgumentException("Жилая площадь больше общей");

                    if (apartment.Children > apartment.Family)
                        throw new ArgumentException("Количество детей больше количества членов семьи");

                    list.Add(apartment);
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Ошибка в строке {i + 1}: {ex.Message}");
                }
            }
            return list;
        }

        public void Save(string path, List<Apartment> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание");

                foreach (var a in list)
                {
                    writer.WriteLine(
                        $"{a.Entrance};" +
                        $"{a.Number};" +
                        $"{a.TotalArea.ToString("F1", CultureInfo.InvariantCulture)};" +
                        $"{a.LivingArea.ToString("F1", CultureInfo.InvariantCulture)};" +
                        $"{a.Rooms};" +
                        $"{a.Surname};" +
                        $"{a.RegDate:dd.MM.yyyy};" +
                        $"{a.Family};" +
                        $"{a.Children};" +
                        $"{a.Debt.ToString().ToLower()};" +
                        $"{a.Notes}");
                }
            }
        }

        public Dictionary<string, double> GetStats(List<Apartment> list)
        {
            if (list == null || !list.Any())
                return new Dictionary<string, double>
                {
                    ["Квартир"] = 0,
                    ["ОбщаяПлощадь"] = 0,
                    ["СрПлощадь"] = 0,
                    ["МаксПлощадь"] = 0,
                    ["МинПлощадь"] = 0,
                    ["Должники"] = 0,
                    ["Дети"] = 0,
                    ["Жильцы"] = 0,
                    ["СрСемья"] = 0,
                    ["Комнаты"] = 0
                };

            return new Dictionary<string, double>
            {
                ["Квартир"] = list.Count,
                ["ОбщаяПлощадь"] = Math.Round(list.Sum(a => a.TotalArea), 1),
                ["СрПлощадь"] = Math.Round(list.Average(a => a.TotalArea), 1),
                ["МаксПлощадь"] = Math.Round(list.Max(a => a.TotalArea), 1),
                ["МинПлощадь"] = Math.Round(list.Min(a => a.TotalArea), 1),
                ["Должники"] = list.Count(a => a.Debt),
                ["Дети"] = list.Sum(a => a.Children),
                ["Жильцы"] = list.Sum(a => a.Family),
                ["СрСемья"] = Math.Round(list.Average(a => a.Family), 1),
                ["Комнаты"] = list.Sum(a => a.Rooms)
            };
        }

        public List<Apartment> Search(List<Apartment> list, string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                return list;

            return list
                .Where(a => a.Surname.IndexOf(surname, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<Apartment> FilterEntrance(List<Apartment> list, int entrance)
        {
            return list.Where(a => a.Entrance == entrance).ToList();
        }

        public List<Apartment> FilterDebt(List<Apartment> list, bool hasDebt)
        {
            return list.Where(a => a.Debt == hasDebt).ToList();
        }

        public List<Apartment> SortByNumber(List<Apartment> list, bool asc)
        {
            return asc ?
                list.OrderBy(a => a.Number).ToList() :
                list.OrderByDescending(a => a.Number).ToList();
        }

        public List<Apartment> SortByArea(List<Apartment> list, bool asc)
        {
            return asc ?
                list.OrderBy(a => a.TotalArea).ToList() :
                list.OrderByDescending(a => a.TotalArea).ToList();
        }

        public List<Apartment> SortByRooms(List<Apartment> list, bool asc)
        {
            return asc ?
                list.OrderBy(a => a.Rooms).ToList() :
                list.OrderByDescending(a => a.Rooms).ToList();
        }

        public List<Apartment> SortByDate(List<Apartment> list, bool asc)
        {
            return asc ?
                list.OrderBy(a => a.RegDate).ToList() :
                list.OrderByDescending(a => a.RegDate).ToList();
        }

        public Dictionary<int, Stats> GetEntranceStats(List<Apartment> list)
        {
            var result = new Dictionary<int, Stats>();
            var groups = list.GroupBy(a => a.Entrance);

            foreach (var g in groups)
            {
                result[g.Key] = new Stats
                {
                    Apartments = g.Count(),
                    TotalArea = Math.Round(g.Sum(a => a.TotalArea), 1),
                    LivingArea = Math.Round(g.Sum(a => a.LivingArea), 1),
                    Residents = g.Sum(a => a.Family),
                    Children = g.Sum(a => a.Children),
                    Debtors = g.Count(a => a.Debt),
                    Rooms = g.Sum(a => a.Rooms)
                };
            }
            return result;
        }

        public List<Apartment> FilterByChildren(List<Apartment> list, bool hasChildren)
        {
            if (hasChildren)
                return list.Where(a => a.Children > 0).ToList();
            else
                return list.Where(a => a.Children == 0).ToList();
        }
    }
}