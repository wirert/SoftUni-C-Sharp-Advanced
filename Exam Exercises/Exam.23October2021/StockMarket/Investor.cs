using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string	FullName { get; set; }
        public string	EmailAddress { get; set; }
        public decimal	MoneyToInvest { get; set; }
        public string 	BrokerName { get; set; }
        public List<Stock> Portfolio { get; private set; }
        public int Count { get { return Portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stock == null) return $"{companyName} does not exist.";            

            if (sellPrice < stock.PricePerShare) return $"Cannot sell {companyName}.";

            MoneyToInvest += sellPrice;
            Portfolio.Remove(stock);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany()
        {
            return Count == 0 ? null : Portfolio.OrderByDescending(s => s.MarketCapitalization).ElementAt(0);
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
