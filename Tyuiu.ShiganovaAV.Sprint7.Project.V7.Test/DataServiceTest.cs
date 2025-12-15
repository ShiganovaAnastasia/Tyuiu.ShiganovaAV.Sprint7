using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib;
using static Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib.DataService;
namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7.Test
{
    public class DataServiceTest
    {
        private DataService ds = new DataService();
        private List<Apartment> testApartments;

        [TestInitialize]
        public void Initialize()
        {
            testApartments = new List<Apartment>
            {
                new Apartment(1, 1, 45.5, 35.0, 2, "Иванов", new DateTime(2010, 5, 10), 3, 1, false, ""),
                new Apartment(1, 2, 60.0, 45.0, 3, "Петров", new DateTime(2015, 8, 15), 4, 2, true, "Долг 3 месяца"),
                new Apartment(2, 3, 75.0, 55.0, 4, "Сидоров", new DateTime(2018, 3, 20), 5, 3, false, "")
            };
        }

        [TestMethod]
        public void ValidLoadFromFile()
        {
            string path = @"TestData.csv";

            // Создаем тестовый файл
            File.WriteAllText(path,
                "Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание\n" +
                "1;1;45.5;35.0;2;Иванов;10.05.2010;3;1;False;\n" +
                "1;2;60.0;45.0;3;Петров;15.08.2015;4;2;True;Долг 3 месяца");

            var result = ds.LoadFromFile(path);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Иванов", result[0].TenantSurname);
            Assert.AreEqual(60.0, result[1].TotalArea);

            File.Delete(path);
        }

        [TestMethod]
        public void ValidSearchBySurname()
        {
            var result = ds.SearchBySurname(testApartments, "петр");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Петров", result[0].TenantSurname);
        }

        [TestMethod]
        public void ValidFilterByDebt()
        {
            var debtors = ds.FilterByDebt(testApartments, true);
            Assert.AreEqual(1, debtors.Count);
            Assert.AreEqual("Петров", debtors[0].TenantSurname);

            var nonDebtors = ds.FilterByDebt(testApartments, false);
            Assert.AreEqual(2, nonDebtors.Count);
        }

        [TestMethod]
        public void ValidSortByApartmentNumber()
        {
            var sorted = ds.SortByApartmentNumber(testApartments, true);
            Assert.AreEqual(1, sorted[0].ApartmentNumber);
            Assert.AreEqual(3, sorted[2].ApartmentNumber);
        }
    }
}
