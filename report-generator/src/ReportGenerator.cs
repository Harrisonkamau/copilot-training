using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the Class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method to get an array of SalesData records
            SalesData[] salesData = report.GenerateSalesData();

            // call the QuarterlySalesReport method to generate and display the quarterly sales report
            report.QuarterlySalesReport(salesData);
        }
        // public struct SalesData. Include the following fields: date sold, department name, product ID, quantity sold, unit price
        public struct SalesData
        {
            public DateOnly dateSold;
            public string departmentName;
            public int productId;
            public int quantitySold;
            public double unitPrice;
        }

        /* the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field of the data structure */
        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random rand = new Random();

            for (int i = 0; i < salesData.Length; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, rand.Next(1, 13), rand.Next(1, 29));
                salesData[i].departmentName = "Department " + rand.Next(1, 11);
                salesData[i].productId = rand.Next(1, 101);
                salesData[i].quantitySold = rand.Next(1, 101);
                salesData[i].unitPrice = rand.NextDouble() * 100;
            }

            return salesData;
        }

        public void QuarterlySalesReport(SalesData[] salesData)
        {
            // group the sales data by department name and calculate the total sales for each department
            Dictionary<string, double> quarterlySales = new Dictionary<string, double>();


            foreach (var sale in salesData)
            {
                // calculate the total sales for each quarter
                string quarter = GetQuarter(sale.dateSold.Month);
                double totalSale = sale.quantitySold * sale.unitPrice;

                if (quarterlySales.ContainsKey(quarter))
                {
                    quarterlySales[quarter] += totalSale;
                }
                else
                {
                    quarterlySales.Add(quarter, totalSale);
                }
            }

            // display the quarterly sales report
            Console.WriteLine("Quarterly Sales Report:");
            Console.WriteLine("=========================");
            foreach (KeyValuePair<string, double> quarter in quarterlySales)
            {
                Console.WriteLine($"{quarter.Key}: ${quarter.Value:F2}");
            }
        }

        private string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return "Q1";
            }
            else if (month >= 4 && month <= 6)
            {
                return "Q2";
            }
            else if (month >= 7 && month <= 9)
            {
                return "Q3";
            }
            else
            {
                return "Q4";
            }
        }
    }
}
