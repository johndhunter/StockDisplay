using StockDisplay.Domain;

namespace StockDisplay.Services
{
    public interface ITrading212ApiService
    {
        // Instruments Metadata - https://t212public-api-docs.redoc.ly/#tag/Instruments-Metadata
        Task<List<Exchange>> GetExchangesAsync();
        Task<List<Instrument>> GetInstrumentsAsync();

        // Pies - https://t212public-api-docs.redoc.ly/#tag/Pies
        Task<List<Pie>> GetPiesAsync();
        Task<PieDetail> GetPieAsync(int pieId); 

        // Equity Orders - https://t212public-api-docs.redoc.ly/#tag/Equity-Orders
        Task<List<Order>> GetOrdersAsync();
        Task <Order> GetOrderAsync(string orderId);

        // Account Data - https://t212public-api-docs.redoc.ly/#tag/Account-Data
        Task<AccountCash> GetAccountCashAsync();
        Task<AccountMetadata> GetAccountMetadataAsync();

        // Personal Portfolio - https://t212public-api-docs.redoc.ly/#tag/Personal-Portfolio
        Task<List<Position>> GetPositionsAsync();
        Task<Position> GetPositionAsync(string positionTickerSymbol);
        Task<Position> GetPositionByTickerAsync(string tickerSymbol);

        //Historical order data - https://t212public-api-docs.redoc.ly/#tag/Historical-items
    }
}