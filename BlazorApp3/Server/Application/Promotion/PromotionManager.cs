namespace BlazorApp3.Server.Application.Promotion
{
    public class PromotionManager : IPromotionManager
    {
        public decimal GetDefaultAmount(string currency)
        {
            if (currency == "BTC")
            {
                return 2;
            }

            return 0;
        }
    }
}
