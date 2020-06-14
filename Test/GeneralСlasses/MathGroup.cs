using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Project_Requirements.Models;

namespace Test_Project_Requirements.GeneralСlasses
{
    public class MathGroup
    { 
        internal static IEnumerable<Sales> GetSales(DateTime startDateTime, DateTime endDateTime, DateGroupType group, DBConnection.ApplicationContext db)
        {
            IEnumerable<Sales> GroupSales;
            switch (group)
            {
                case DateGroupType.Week:
                    {
                        GroupSales = MathGroup.GetHistorySalesWeek(db.HistorySales.Where(x => x.DateSale >= startDateTime).Where(x => x.DateSale <= endDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                case DateGroupType.Month:
                    {
                        GroupSales = MathGroup.GetHistorySalesMonth(db.HistorySales.Where(x => x.DateSale >= startDateTime).Where(x => x.DateSale <= endDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                case DateGroupType.Quarter:
                    {
                        GroupSales = MathGroup.GetHistorySalesQuarter(db.HistorySales.Where(x => x.DateSale >= startDateTime).Where(x => x.DateSale <= endDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
                default:
                    {
                        GroupSales = MathGroup.GetHistorySalesDay(db.HistorySales.Where(x => x.DateSale >= startDateTime).Where(x => x.DateSale <= endDateTime).OrderBy(x => x.DateSale).ToList());
                        break;
                    }
            }
            return GroupSales;
        }
        #region Day
        internal static IEnumerable<Sales> GetHistorySalesDay(List<HistorySale> historySales)
        {
            var SalesList = new List<Sales>();
            foreach (var t in historySales.GroupBy(x => x.DateSale.Date.AddDays(x.DateSale.Day)))
            {
                int SalesTemp = 0;
                decimal AmountDollarsTemp = 0;
                DateTime DateSalesTemp = DateTime.Now; ;

                foreach (HistorySale historySale in t)
                {
                    SalesTemp += historySale.Sale;
                    AmountDollarsTemp += historySale.AmountDollars;
                    DateSalesTemp = historySale.DateSale;
                }
                SalesList.Add(new Sales(DateSalesTemp, SalesTemp, AmountDollarsTemp));
            }
            return SalesList;
        }
        #endregion

        #region Week
        internal static IEnumerable<Sales> GetHistorySalesWeek(List<HistorySale> historySales)
        {
            var SalesList = new List<Sales>();
            foreach (var t in historySales.GroupBy(x => new { x.DateSale.Year, Week = 1 + (x.DateSale.DayOfYear - 1) / 7 }))
            {
                int SalesTemp = 0;
                decimal AmountDollarsTemp = 0;
                DateTime DateSalesTemp = DateTime.Now; ;

                foreach (HistorySale historySale in t)
                {
                    SalesTemp += historySale.Sale;
                    AmountDollarsTemp += historySale.AmountDollars;
                    DateSalesTemp = historySale.DateSale;
                }
                SalesList.Add(new Sales(DateSalesTemp, SalesTemp, AmountDollarsTemp));
            }
            return SalesList;
        }
        #endregion

        #region Month
        internal static IEnumerable<Sales> GetHistorySalesMonth(List<HistorySale> historySales)
        {
            var SalesList = new List<Sales>();
            foreach (var t in historySales.GroupBy(x => new { x.DateSale.Year, x.DateSale.Month }))
            {
                int SalesTemp = 0;
                decimal AmountDollarsTemp = 0;
                DateTime DateSalesTemp = DateTime.Now; ;

                foreach (HistorySale historySale in t)
                {
                    SalesTemp += historySale.Sale;
                    AmountDollarsTemp += historySale.AmountDollars;
                    DateSalesTemp = historySale.DateSale;
                }
                SalesList.Add(new Sales(DateSalesTemp, SalesTemp, AmountDollarsTemp));
            }
            return SalesList;
        }

       
        #endregion

        #region Quarter
        internal static IEnumerable<Sales> GetHistorySalesQuarter(List<HistorySale> historySales)
        {
            var SalesList = new List<Sales>();
            foreach (var t in historySales.GroupBy(x => new { x.DateSale.Year, Quarter = 1 + (x.DateSale.Month - 1) / 3 }))
            {
                int SalesTemp = 0;
                decimal AmountDollarsTemp = 0;
                DateTime DateSalesTemp = DateTime.Now; ;

                foreach (HistorySale historySale in t)
                {
                    SalesTemp += historySale.Sale;
                    AmountDollarsTemp += historySale.AmountDollars;
                    DateSalesTemp = historySale.DateSale;
                }
                SalesList.Add(new Sales(DateSalesTemp, SalesTemp, AmountDollarsTemp));
            }
            return SalesList;
        }
        #endregion
    }
}
