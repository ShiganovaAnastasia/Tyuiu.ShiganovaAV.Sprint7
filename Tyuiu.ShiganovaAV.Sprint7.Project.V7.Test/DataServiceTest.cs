using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadFromFile_ValidFile_ReturnsData()
        {
            var ds = new DataService();
            string path = "test.csv";

            File.WriteAllText(path,
                "Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание\n" +
                "1;1;45.5;35.0;2;Иванов;10.05.2010;3;1;False;\n");

            var result = ds.Load(path);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Иванов", result[0].Surname);
            Assert.AreEqual(45.5, result[0].TotalArea);

            File.Delete(path);
        }

        [TestMethod]
        public void SearchBySurname_Found_ReturnsMatches()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { Surname = "Иванов" },
                new Apartment { Surname = "Петров" },
                new Apartment { Surname = "Иванова" }
            };

            var result = ds.Search(list, "ива");

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void FilterByDebt_OnlyDebtors_ReturnsCorrect()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { Debt = true },
                new Apartment { Debt = false },
                new Apartment { Debt = true }
            };

            var result = ds.FilterDebt(list, true);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(a => a.Debt));
        }

        [TestMethod]
        public void SortByNumber_Ascending_Works()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { Number = 5 },
                new Apartment { Number = 1 },
                new Apartment { Number = 3 }
            };

            var result = ds.SortByNumber(list, true);

            Assert.AreEqual(1, result[0].Number);
            Assert.AreEqual(5, result[2].Number);
        }

        [TestMethod]
        public void GetStats_EmptyList_ReturnsZeros()
        {
            var ds = new DataService();
            var list = new List<Apartment>();

            var stats = ds.GetStats(list);

            Assert.AreEqual(0, stats["Квартир"]);
            Assert.AreEqual(0, stats["ОбщаяПлощадь"]);
        }

        [TestMethod]
        public void GetStats_ValidList_CalculatesCorrectly()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { TotalArea = 50, Family = 3, Children = 1, Debt = false, Rooms = 2 },
                new Apartment { TotalArea = 70, Family = 4, Children = 2, Debt = true, Rooms = 3 }
            };

            var stats = ds.GetStats(list);

            Assert.AreEqual(2, stats["Квартир"]);
            Assert.AreEqual(120, stats["ОбщаяПлощадь"]);
            Assert.AreEqual(60, stats["СрПлощадь"]);
            Assert.AreEqual(1, stats["Должники"]);
            Assert.AreEqual(3, stats["Дети"]);
            Assert.AreEqual(7, stats["Жильцы"]);
            Assert.AreEqual(3.5, stats["СрСемья"]);
            Assert.AreEqual(5, stats["Комнаты"]);
        }

        [TestMethod]
        public void FilterByEntrance_SpecificEntrance_ReturnsFiltered()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { Entrance = 1 },
                new Apartment { Entrance = 2 },
                new Apartment { Entrance = 1 }
            };

            var result = ds.FilterEntrance(list, 1);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(a => a.Entrance == 1));
        }

        [TestMethod]
        public void GetEntranceStats_ValidData_ReturnsCorrect()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment { Entrance = 1, TotalArea = 50, Family = 2, Debt = false, Rooms = 2 },
                new Apartment { Entrance = 1, TotalArea = 60, Family = 3, Debt = true, Rooms = 3 },
                new Apartment { Entrance = 2, TotalArea = 70, Family = 4, Debt = false, Rooms = 3 }
            };

            var result = ds.GetEntranceStats(list);

            Assert.AreEqual(2, result[1].Apartments);
            Assert.AreEqual(110, result[1].TotalArea);
            Assert.AreEqual(5, result[1].Residents);
            Assert.AreEqual(1, result[1].Debtors);
            Assert.AreEqual(5, result[1].Rooms);
            Assert.AreEqual(1, result[2].Apartments);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadFromFile_MissingFile_ThrowsException()
        {
            var ds = new DataService();
            ds.Load("missing.csv");
        }

        [TestMethod]
        public void SaveToFile_ValidData_CreatesFile()
        {
            var ds = new DataService();
            var list = new List<Apartment>
            {
                new Apartment
                {
                    Entrance = 1,
                    Number = 10,
                    TotalArea = 55.5,
                    LivingArea = 40.0,
                    Rooms = 3,
                    Surname = "Тестов",
                    RegDate = new DateTime(2020, 1, 1),
                    Family = 4,
                    Children = 2,
                    Debt = false,
                    Notes = "тест"
                }
            };

            string path = "save_test.csv";
            ds.Save(path, list);

            Assert.IsTrue(File.Exists(path));

            var content = File.ReadAllLines(path);
            Assert.AreEqual(2, content.Length);
            Assert.IsTrue(content[1].Contains("Тестов"));

            File.Delete(path);
        }
    }
}