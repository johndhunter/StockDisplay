using T212_Updates.Domain;
using T212_Updates.Infrastructure;

namespace T212_Updates.Services
{
    public interface ITrading212ApiService
    {
        // Instruments Metadata - https://t212public-api-docs.redoc.ly/#tag/Instruments-Metadata
        Task<Result<List<Exchange>>> GetExchangesAsync();
        Task<Result<List<Instrument>>> GetInstrumentsAsync();

        // Pies - https://t212public-api-docs.redoc.ly/#tag/Pies
        Task<Result<List<Pie>>> GetPiesAsync();
        Task<Result<PieDetail>> GetPieAsync(long pieId); 

        // Equity Orders - https://t212public-api-docs.redoc.ly/#tag/Equity-Orders
        Task<Result<List<Order>>> GetOrdersAsync();
        Task<Result<Order>> GetOrderAsync(string orderId);

        // Account Data - https://t212public-api-docs.redoc.ly/#tag/Account-Data
        Task<Result<AccountCash>> GetAccountCashAsync();
        Task<Result<AccountMetadata>> GetAccountMetadataAsync();

        // Personal Portfolio - https://t212public-api-docs.redoc.ly/#tag/Personal-Portfolio
        Task<Result<List<Position>>> GetPositionsAsync();
        Task<Result<Position>> GetPositionAsync(string positionTickerSymbol);
        Task<Result<Position>> GetPositionByTickerAsync(string tickerSymbol);

        //Historical order data - https://t212public-api-docs.redoc.ly/#tag/Historical-items
    }
}