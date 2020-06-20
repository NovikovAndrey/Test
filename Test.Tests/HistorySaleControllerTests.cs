using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Test_Project_Requirements.Controllers;
using Test_Project_Requirements.DBConnection;
using Test_Project_Requirements.Models;
using Xunit;

namespace Test.Tests
{
    public class HistorySaleControllerTest
    {

        [Theory]
        [InlineData(null, null, DateGroupType.Day, 6)]
        [InlineData(null, null, DateGroupType.Week, 6)]
        [InlineData(null, null, DateGroupType.Month, 6)]
        [InlineData(null, null, DateGroupType.Quarter, 4)]

        [InlineData("2020-01-20", null, DateGroupType.Day, 4)]
        [InlineData("2020-01-20", null, DateGroupType.Week, 4)]
        [InlineData("2020-01-20", null, DateGroupType.Month, 4)]
        [InlineData("2020-01-20", null, DateGroupType.Quarter, 2)]

        [InlineData("2020-01-20", "2020-06-20", DateGroupType.Day, 4)]
        [InlineData("2020-01-20", "2020-05-20", DateGroupType.Week, 3)]
        [InlineData("2019-06-20", "2020-06-20", DateGroupType.Month, 5)]
        [InlineData("2020-01-20", "2020-01-20", DateGroupType.Quarter, 0)]

        [InlineData(null, "2020-01-20", DateGroupType.Day, 2)]
        [InlineData(null, "2020-02-20", DateGroupType.Week, 3)]
        [InlineData(null, "2020-04-20", DateGroupType.Month, 5)]
        [InlineData(null, "2020-06-20", DateGroupType.Quarter, 4)]

        public void HistorySaleController_Get_Sales(string StartDT, string EndDT, DateGroupType group, int expCount)
        {
            Mock<ApplicationContext> mockContext = new Mock<ApplicationContext>();
            var list = new List<HistorySale>()
            {
                new HistorySale() {DateSale=DateTime.Parse("2020-06-20") },
                new HistorySale() {DateSale=DateTime.Parse("2020-04-10") },
                new HistorySale() {DateSale=DateTime.Parse("2020-03-15") },
                new HistorySale() {DateSale=DateTime.Parse("2020-02-11") },
                new HistorySale() {DateSale=DateTime.Parse("2019-06-20") },
                new HistorySale() {DateSale=DateTime.Parse("2018-06-20") },
                new HistorySale() {DateSale=DateTime.Parse("2019-06-20") }
            };

            DbSet<HistorySale> dbSetHistorySale = GetQueryableMockDbSet<HistorySale>(list);
            mockContext.Setup(x => x.HistorySales).Returns(dbSetHistorySale);

            HistorySaleController controller = new HistorySaleController(mockContext.Object);
            var result = controller.Get(StartDT, EndDT, group);
            Assert.Equal(expCount, result.Count());
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
